Public Class maRecibos
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _Transaccion As String
    Private _IdRecibo As String
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

    Public Property IdRecibo As String
        Get
            Return ViewState("IdFactura")
        End Get
        Set(value As String)
            ViewState("IdFactura") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarDropDownListNombreCliente()
            cargarDropDownListEstado()
            cargarVariablesSession()
            evaluarAccion()
            deshabilitarBotones()
        End If
    End Sub

    Protected Sub maRecibos_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Protected Sub cargarDropDownListNombreCliente()
        Dim vGestor As New wsPersona.wsTbPersona
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            'Se carga el dropDownList con los clientes que existen en la base de datos
            vDataSet = vGestor.TbPersonaConsultarPersonas()

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
        ddlEstado.Items.Add(New ListItem("Activo", 1))
        ddlEstado.Items.Add(New ListItem("Inactivo", 2))
    End Sub

    Protected Sub cargarVariablesSession()
        Transaccion = Session("vTransaccion")
        IdRecibo = Session("vIdRecibo")
        'Despues de tomarlas de las variables de session se remueven para no acumular variables en session
        Session.Remove("vTransaccion")
        Session.Remove("vIdRecivo")
    End Sub

    Protected Sub evaluarAccion()
        Select Case Transaccion
            Case "A"
                btnAccion.Text = "Registrar"
                btnAccion.CssClass = "btn btn-success"
            Case "M"
                btnAccion.Text = "Modificar"
                btnAccion.CssClass = "btn btn-warning"
                cargarReciboID()
                cargarGridViewDetallesRecibo()
            Case "E"
                btnAccion.Text = "Eliminar"
                btnAccion.CssClass = "btn btn-danger"
                cargarReciboID()
                cargarGridViewDetallesRecibo()
        End Select
    End Sub

    Protected Sub deshabilitarBotones()
        Select Case Transaccion
            Case "A"
                txtIdRecibo.Enabled = False
                txtIdRecibo.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtMontoTotal.Enabled = False
                txtMontoTotal.CssClass = "form-control"
                txtDescripcion.Enabled = False
                txtDescripcion.CssClass = "form-control"
            Case "M"
                txtIdRecibo.Enabled = False
                txtIdRecibo.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtMontoTotal.Enabled = False
                txtMontoTotal.CssClass = "form-control"
                txtDescripcion.Enabled = False
                txtDescripcion.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
            Case "E"
                txtIdRecibo.Enabled = False
                txtIdRecibo.CssClass = "form-control"
                ddlNombreCliente.Enabled = False
                ddlNombreCliente.CssClass = "form-control"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                txtFechaEmision.Enabled = False
                txtFechaEmision.CssClass = "form-control"
                txtDescripcion.Enabled = False
                txtDescripcion.CssClass = "form-control"
                txtMontoTotal.Enabled = False
                txtMontoTotal.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
        End Select
    End Sub

    Protected Sub cargarReciboID()
        Dim vRecibo As New wsRecibo.Recibo
        Dim vGestor As New wsRecibo.wsTbRecibo
        Dim metodosUtiles As New utiles
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vRecibo.IdRecibo = IdRecibo

            vRecibo = vGestor.consultarReciboBusquedaMantenimiento(vRecibo)

            txtIdRecibo.Text = vRecibo.IdRecibo
            ddlNombreCliente.Text = vRecibo.Correo.Trim
            ddlEstado.Text = vRecibo.IdEstado
            txtFechaEmision.Text = metodosUtiles.retornarFechaIngles(vRecibo.FechaEmision)
            txtDescripcion.Text = (vRecibo.Descripcion)
            txtMontoTotal.Text = vRecibo.MontoTotal
            
        Catch vExc As Exception
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vRecibo = Nothing
        End Try
    End Sub

    Protected Sub cargarGridViewDetallesRecibo()
        Dim vGestor As New wsDetalleRecibo.wsTbDetalleRecibo
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vDataSet = vGestor.TbDetalleReciboConsultarDetallesRecibo(IdRecibo)
            grdListaDetalleRecibo.DataSource = vDataSet
            grdListaDetalleRecibo.DataBind()

            If vDataSet.Tables(0).Rows.Count = 0 Then
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = "No hay facturas agregadas por el momento."
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
        End Try
    End Sub

    Protected Sub limpiarCampos()
        txtIdRecibo.Text = ""
        txtFechaEmision.Text = ""
        txtDescripcion.Text = ""
        txtMontoTotal.Text = ""

    End Sub

End Class