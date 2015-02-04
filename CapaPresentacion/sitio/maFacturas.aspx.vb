Public Class maFacturas
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _Transaccion As String
    Private _IdFactura As String
    Private _localData As DataTable
#End Region

#Region "Métodos de acceso a las propiedades"
    Public Property Transaccion As String
        Get
            Return ViewState("Transaccion")
        End Get
        Set(value As String)
            ViewState("Transaccion") = value
        End Set
    End Property

    Public Property IdFactura As String
        Get
            Return ViewState("IdFactura")
        End Get
        Set(value As String)
            ViewState("IdFactura") = value
        End Set
    End Property
    Public Property localData As DataTable
        Get
            Return ViewState("DatosGridView")
        End Get
        Set(value As DataTable)
            ViewState("DatosGridView") = value
        End Set
    End Property
#End Region

#Region "Métodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim metodosUtiles As New utiles
            txtFechaEmision.Text = metodosUtiles.retornarFechaIngles(Convert.ToString(Date.Now))
            cargarDrownDownList()
            cargarVariablesSession()
            evaluarAccion()
            deshabilitarBotones()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As System.EventArgs) Handles btnLimpiar.Click
        limpiarCamposFactura()
        limpiarMensajesError()
    End Sub

    Protected Sub btnAccion_Click(sender As Object, e As EventArgs) Handles btnAccion.Click
        ejecutarAccion()
    End Sub

    Protected Sub imgbtnActualizar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnActualizar.Click
        actualizarMontoTotalServicio()
    End Sub

    Private Sub imgbtnAgregar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAgregar.Click
        limpiarMensajesError()
        agregarDetalleFactura()
        limpiarCamposDetalleFactura()
    End Sub

    Private Sub grdListaDetalleFactura_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdListaDetalleFactura.PageIndexChanging
        grdListaDetalleFactura.PageIndex = e.NewPageIndex
        grdListaDetalleFactura.DataSource = localData
        grdListaDetalleFactura.DataBind()
    End Sub

    Private Sub grdListaDetalleFactura_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdListaDetalleFactura.RowCommand
        Dim vFilaActual As Integer = CInt(e.CommandArgument)
        If e.CommandName = "Eliminar" Then
            eliminarDetalleFactura(vFilaActual)
        End If
    End Sub

    Protected Sub evaluarAccion()
        Dim metodosUtiles As New utiles
        Select Case Transaccion
            Case "A"
                btnAccion.Text = "Registrar"
                btnAccion.CssClass = "btn btn-success"
                cargarNumeroFacturaSiguiente()
            Case "M"
                btnAccion.Text = "Modificar"
                btnAccion.CssClass = "btn btn-warning"
                pnDetalleFactura.CssClass = "panel panel-default"
                cargarFacturaPorID()
            Case "I"
                btnAccion.Text = "Imprimir"
                btnAccion.CssClass = "btn btn-back"
                pnDetalleFactura.CssClass = "panel panel-default hidden"
                cargarFacturaPorID()
            Case "E"
                btnAccion.Text = "Anular"
                btnAccion.CssClass = "btn btn-danger"
                pnDetalleFactura.CssClass = "panel panel-default hidden"
                cargarFacturaPorID()
        End Select
    End Sub

    Protected Sub cargarFacturaPorID()
        Dim vFactura As New wsFactura.Factura
        Dim vGestor As New wsFactura.wsTbFactura
        Dim metodosUtiles As New utiles
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vFactura.IdFactura = IdFactura

            vFactura = vGestor.TbFacturaConsultarFacturaBusquedaMantenimiento(vFactura)

            txtIdFactura.Text = vFactura.IdFactura
            ddlNombreCliente.Text = vFactura.Correo.Trim
            ddlEstado.Text = vFactura.IdEstado
            txtFechaEmision.Text = metodosUtiles.retornarFechaIngles(vFactura.FechaEmision)
            txtFechaVencimiento.Text = metodosUtiles.retornarFechaIngles(vFactura.FechaVencimiento)
            txtMontoTotalPagado.Text = vFactura.MontoCancelado

            actualizarMontoTotalFactura()
            cargarGridViewDetalleFactura()
        Catch vExc As Exception
            pnGridViewSinDatos.CssClass = "panel panel-default"
            lbGridViewSinDatos.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vFactura = Nothing
        End Try
    End Sub

    Protected Sub cargarNumeroFacturaSiguiente()
        Dim vGestor As New wsFactura.wsTbFactura
        Dim vNumeroFacturaSiguiente As Integer
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vNumeroFacturaSiguiente = vGestor.TbFacturaConsultarFacturaNumeroSiguiente()

            txtIdFactura.Text = vNumeroFacturaSiguiente
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
        End Try
    End Sub

    Protected Sub ejecutarAccion()
        Dim vFactura As New wsFactura.Factura
        Dim vGestor As New wsFactura.wsTbFactura
        Dim metodosUtiles As New utiles
        Dim vFecha As Integer = 0
        Dim vResultado As String = ""
        Dim vMensajePanel As String = ""
        Try
            vFactura.IdFactura = IdFactura
            vFactura.Correo = ddlNombreCliente.Text
            vFactura.IdEstado = CInt(ddlEstado.Text)
            vFactura.FechaEmision = metodosUtiles.retornarFechaEspanol(txtFechaEmision.Text)
            If txtFechaVencimiento.Text <> "" Then
                vFactura.FechaVencimiento = metodosUtiles.retornarFechaEspanol(txtFechaVencimiento.Text)
                vFecha = 1
            End If
            vFactura.MontoTotal = CDbl(txtMontoTotalFactura.Text)

            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            Select Case Transaccion
                Case "A"
                    vResultado = vGestor.TbFacturaInsertarFactura(vFactura, vFecha)
                    vMensajePanel = "agregado"
                Case "M"
                    vResultado = vGestor.TbFacturaActualizarFactura(vFactura)
                    vMensajePanel = "modificado"
                Case "E"
                    vResultado = vGestor.TbFacturaAnularFactura(vFactura)
                    vMensajePanel = "anulado"
                Case "I"
                    vResultado = vGestor.TbFacturaImprimirFactura(vFactura)
                    vMensajePanel = "impreso"
            End Select

            If vResultado = "" Then
                If Transaccion = "E" And vResultado = "" Then
                    Response.Redirect("listadoFacturas.aspx")
                ElseIf Transaccion = "I" And vResultado = "" Then
                    Response.Redirect("listadoFacturas.aspx")
                Else
                    pnErrorCargarFacturaSuccess.CssClass = "panel panel-default"
                    lbErrorCargarFacturaSuccess.Text = "Se ha " & vMensajePanel & " exitosamente la factura."
                    pnDetalleFactura.CssClass = "panel panel-default"
                End If
            Else
                pnErrorCargarFactura.CssClass = "panel panel-default"
                lbErrorCargarFactura.Text = vResultado
            End If
        Catch vExc As Exception
            pnErrorCargarFactura.CssClass = "panel panel-default"
            lbErrorCargarFactura.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
        End Try
    End Sub

    Protected Sub actualizarMontoTotalFactura()
        Dim vFactura As New wsFactura.Factura
        Dim vGestor As New wsFactura.wsTbFactura
        Dim vMontoTotalFactura As Double
        Dim vResultado As String = ""
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vMontoTotalFactura = vGestor.TbFacturaConsultarFacturaMontoTotal(CInt(txtIdFactura.Text))

            txtMontoTotalFactura.Text = vMontoTotalFactura
            txtMontoTotalFactura.Text = txtMontoTotalFactura.Text

            Try
                vFactura.IdFactura = CInt(txtIdFactura.Text)
                vFactura.MontoTotal = vMontoTotalFactura

                vResultado = vGestor.TbFacturaActualizarFacturaMontoTotal(vFactura)
            Catch vExc As Exception
                pnErrorCargarFactura.CssClass = "panel panel-default"
                lbErrorCargarFactura.Text = vExc.Message
            End Try

        Catch vExc As Exception
            pnErrorCargarFactura.CssClass = "panel panel-default"
            lbErrorCargarFactura.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
        End Try
    End Sub

    Protected Function cargarImpuestoPorID(ByVal pIdImpuesto As Integer) As Double
        Dim vImpuesto As New wsImpuesto.Impuesto
        Dim vGestor As New wsImpuesto.wsTbImpuesto
        Dim vPorcentajeImpuesto As Double
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vImpuesto.IdImpuesto = pIdImpuesto

            vImpuesto = vGestor.TbImpuestoConsultarImpuestoBusquedaMantenimiento(vImpuesto)

            vPorcentajeImpuesto = vImpuesto.PorcentajeImpuesto
        Catch vExc As Exception
            pnGridViewSinDatos.CssClass = "panel panel-default"
            lbGridViewSinDatos.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vImpuesto = Nothing
        End Try
        Return vPorcentajeImpuesto
    End Function

    Protected Sub cargarGridViewDetalleFactura()
        Dim vGestor As New wsDetalleFactura.wsTbDetalleFactura
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vDataSet = vGestor.TbDetalleFacturaConsultarDetallesFactura(CInt(txtIdFactura.Text))
            grdListaDetalleFactura.DataSource = vDataSet
            grdListaDetalleFactura.DataBind()

            If vDataSet.Tables(0).Rows.Count = 0 Then
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = "No hay servicios agregados a la factura por el momento."
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
        End Try
    End Sub

    Protected Sub agregarDetalleFactura()
        Dim vDetalleFactura As New wsDetalleFactura.DetalleFactura
        Dim vGestor As New wsDetalleFactura.wsTbDetalleFactura
        Dim vResultado As String = ""
        If txtMontoServicio.Text <> "" Then
            Try
                vDetalleFactura.IdFactura = CInt(txtIdFactura.Text)
                vDetalleFactura.IdServicio = ddlServicio.Text
                vDetalleFactura.PrecioUnitario = CDbl(txtMontoServicio.Text)
                vDetalleFactura.Cantidad = CInt(txtCantidad.Text)

                vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                vGestor.Timeout = -1

                vResultado = vGestor.TbDetalleFacturaInsertarDetalleFactura(vDetalleFactura)

                If vResultado = "" Then
                    cargarGridViewDetalleFactura()
                Else
                    pnGridViewSinDatos.CssClass = "panel panel-default"
                    lbGridViewSinDatos.Text = vResultado
                End If

                actualizarMontoTotalFactura()
                cargarDropDownListServicios()
            Catch vExc As Exception
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = vExc.Message
            End Try
        Else
            pnGridViewSinDatos.CssClass = "panel panel-default"
            lbGridViewSinDatos.Text = "Debe actualizar el campo de Monto Servicio."
        End If
    End Sub

    Protected Sub eliminarDetalleFactura(ByVal pFilaActual As Integer)
        Dim vDetalleFactura As New wsDetalleFactura.DetalleFactura
        Dim vGestor As New wsDetalleFactura.wsTbDetalleFactura
        Dim vResultado As String = ""
        Try
            vDetalleFactura.IdFactura = txtIdFactura.Text
            vDetalleFactura.IdDetalleFactura = grdListaDetalleFactura.Rows(pFilaActual).Cells(1).Text

            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vResultado = vGestor.TbDetalleFacturaEliminarDetalleFactura(vDetalleFactura)

            If vResultado = "" Then
                cargarGridViewDetalleFactura()
            Else
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = vResultado
            End If

            actualizarMontoTotalFactura()
        Catch vExc As Exception
            pnGridViewSinDatos.CssClass = "panel panel-default"
            lbGridViewSinDatos.Text = vExc.Message
        End Try
    End Sub

    Protected Sub actualizarMontoTotalServicio()
        Dim vServicio As New wsServicio.Servicio
        Dim vGestor As New wsServicio.wsTbServicio
        Dim vPrecioServicio As Double
        Dim vPorcentajeImpuesto As String
        Dim vImpuestoServicioAplicado As Double
        Dim vMontoTotal As Double
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vServicio.IdServicio = ddlServicio.Text

            vServicio = vGestor.TbServicioConsultarServicio(vServicio)

            vPrecioServicio = vServicio.PrecioUnitario
            vPorcentajeImpuesto = cargarImpuestoPorID(vServicio.IdImpuesto)     'Se carga el porcentaje del impuesto pasandole como parametro el ID de Impuesto
            vImpuestoServicioAplicado = vPrecioServicio * vPorcentajeImpuesto   'Se saca el impuesto según el precio del producto
            If vImpuestoServicioAplicado <> 0 Then
                vImpuestoServicioAplicado = vImpuestoServicioAplicado.ToString.Substring(0, (vImpuestoServicioAplicado.ToString.Length - 2))    'Se quitan los 0 que estan demás de la derecha
            End If
            vMontoTotal = vPrecioServicio + vImpuestoServicioAplicado           'Se suma el impuesto al precio
            txtMontoServicio.Text = txtCantidad.Text * vMontoTotal              'Se multiplica la cantidad por el precio del producto
        Catch vExc As Exception
            pnGridViewSinDatos.CssClass = "panel panel-default"
            lbGridViewSinDatos.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vServicio = Nothing
        End Try
    End Sub

    Protected Sub cargarDrownDownList()
        cargarDropDownListNombreCliente()
        cargarDropDownListEstado()
        cargarDropDownListServicios()
    End Sub

    Protected Sub cargarDropDownListNombreCliente()
        Dim vGestor As New wsPersona.wsTbPersona
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            'Se carga el dropDownList con los clientes que existen en la base de datos
            vDataSet = vGestor.TbPersonaConsultarClientes()

            ddlNombreCliente.Items.Clear()
            For Each dr As DataRow In vDataSet.Tables(0).Rows
                ddlNombreCliente.Items.Add(New ListItem(dr("Nombre Completo").ToString, dr("Correo").ToString.Trim))
            Next
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            If Not (vDataSet Is Nothing) Then
                vDataSet.Dispose()
            End If
        End Try
    End Sub

    Protected Sub cargarDropDownListEstado()
        ddlEstado.Items.Clear()
        ddlEstado.Items.Add(New ListItem("Nuevo(a)", 3))
        ddlEstado.Items.Add(New ListItem("Impreso(a)", 4))
        If Transaccion = "M" Then
            ddlEstado.Items.Add(New ListItem("Anulado(a)", 5))
        End If
    End Sub

    Protected Sub cargarDropDownListServicios()
        Dim vGestor As New wsServicio.wsTbServicio
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            'Se carga el dropDownList con los cl ientes que existen en la base de datos
            vDataSet = vGestor.TbServicioConsultarServicios()

            ddlServicio.Items.Clear()
            For Each dr As DataRow In vDataSet.Tables(0).Rows
                ddlServicio.Items.Add(New ListItem(dr("Descripción").ToString, dr("Id Servicio").ToString.Trim))
            Next
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            If Not (vDataSet Is Nothing) Then
                vDataSet.Dispose()
            End If
        End Try
    End Sub

    Protected Sub cargarVariablesSession()
        Transaccion = Session("vTransaccion")
        IdFactura = Session("vIdFactura")
        'Despues de tomarlas de las variables de session se remueven para no acumular variables en session
        Session.Remove("vTransaccion")
        Session.Remove("vIdFactura")
    End Sub

    Protected Sub deshabilitarBotones()
        Select Case Transaccion
            Case "A"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                txtIdFactura.Enabled = False
                txtIdFactura.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtMontoTotalFactura.Enabled = False
                txtMontoTotalFactura.CssClass = "form-control"
                txtMontoTotalPagado.Enabled = False
                txtMontoTotalPagado.CssClass = "form-control"
            Case "I"
                txtIdFactura.Enabled = False
                txtIdFactura.CssClass = "form-control"
                ddlNombreCliente.Enabled = False
                ddlNombreCliente.CssClass = "form-control"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtFechaVencimiento.Enabled = False
                txtFechaVencimiento.CssClass = "form-control"
                txtMontoTotalFactura.Enabled = False
                txtMontoTotalFactura.CssClass = "form-control"
                txtMontoTotalPagado.Enabled = False
                txtMontoTotalPagado.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
            Case "M"
                txtIdFactura.Enabled = False
                txtIdFactura.CssClass = "form-control"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtMontoTotalFactura.Enabled = False
                txtMontoTotalFactura.CssClass = "form-control"
                txtMontoTotalPagado.Enabled = False
                txtMontoTotalPagado.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
            Case "E"
                txtIdFactura.Enabled = False
                txtIdFactura.CssClass = "form-control"
                ddlNombreCliente.Enabled = False
                ddlNombreCliente.CssClass = "form-control"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtFechaVencimiento.Enabled = False
                txtFechaVencimiento.CssClass = "form-control"
                txtMontoTotalFactura.Enabled = False
                txtMontoTotalFactura.CssClass = "form-control"
                txtMontoTotalPagado.Enabled = False
                txtMontoTotalPagado.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
        End Select
    End Sub

    Protected Sub limpiarCamposFactura()
        txtFechaEmision.Text = ""
        txtFechaVencimiento.Text = ""
        txtMontoTotalFactura.Text = ""
        cargarDropDownListNombreCliente()
        cargarDropDownListEstado()
    End Sub

    Protected Sub limpiarCamposDetalleFactura()
        txtCantidad.Text = ""
        txtMontoServicio.Text = ""
    End Sub

    Protected Sub limpiarMensajesError()
        pnErrorCargarFactura.CssClass = "panel panel-default hidden"
        pnGridViewSinDatos.CssClass = "panel panel-default hidden"
    End Sub

    Protected Sub maFacturas_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class