Public Class maServicios
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _Transaccion As String
    Private _IdServicio As Integer
#End Region

#Region "Métodos de acceso a las propiedades"
    Public Property Transaccion As String
        Get
            Return ViewState("Transaccion")
        End Get
        Set(ByVal value As String)
            ViewState("Transaccion") = value
        End Set
    End Property

    Public Property IdServicio As Integer
        Get
            Return ViewState("IdServicio")
        End Get
        Set(ByVal value As Integer)
            ViewState("IdServicio") = value
        End Set
    End Property
#End Region

#Region "Metodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarDropDownListImpuesto()
            cargarDropDownListEstado()
            cargarVariablesSession()
            evaluarAccion()
            deshabilitarBotones()
        End If
    End Sub

    Protected Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub btnAccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccion.Click
        ejecutarAccion()
    End Sub

    Protected Sub cargarDropDownListImpuesto()
        Dim vGestor As New wsImpuesto.wsTbImpuesto
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            'Se carga el dropDownList con los impuestos que existen en la base de datos
            vDataSet = vGestor.TbImpuestoConsultarImpuestos()

            ddlImpuesto.Items.Clear()
            For Each dr As DataRow In vDataSet.Tables(0).Rows
                ddlImpuesto.Items.Add(New ListItem(dr("Descripción").ToString, CInt(dr("ID Impuesto").ToString)))
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
        IdServicio = Session("vIdServicio")
        'Despues de tomarlas de las variables de session se remueven para no acumular variables en session
        Session.Remove("vTransaccion")
        Session.Remove("vIdServicio")
    End Sub

    Protected Sub evaluarAccion()
        Select Case Transaccion
            Case "A"
                btnAccion.Text = "Registrar"
                btnAccion.CssClass = "btn btn-success"
            Case "M"
                btnAccion.Text = "Modificar"
                btnAccion.CssClass = "btn btn-warning"
                cargarServicioPorID()
            Case "E"
                btnAccion.Text = "Eliminar"
                btnAccion.CssClass = "btn btn-danger"
                cargarServicioPorID()
        End Select
    End Sub

    Protected Sub deshabilitarBotones()
        Select Case Transaccion
            Case "E"
                txtDescripcion.Enabled = False
                txtDescripcion.CssClass = "form-control"
                txtPrecioUnitario.Enabled = False
                txtPrecioUnitario.CssClass = "form-control"
                ddlImpuesto.Enabled = False
                ddlImpuesto.CssClass = "form-control"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
        End Select
    End Sub

    Protected Sub cargarServicioPorID()
        Dim vServicio As New wsServicio.Servicio
        Dim vGestor As New wsServicio.wsTbServicio
        Dim metodosUtiles As New utiles
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vServicio.IdServicio = IdServicio

            vServicio = vGestor.TbServicioConsultarServicio(vServicio)

            txtDescripcion.Text = vServicio.Descripcion
            txtPrecioUnitario.Text = vServicio.PrecioUnitario
            ddlImpuesto.Text = vServicio.IdImpuesto
            ddlEstado.Text = vServicio.IdEstado
        Catch vExc As Exception
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vServicio = Nothing
        End Try
    End Sub

    Protected Sub ejecutarAccion()
        Dim vServicio As New wsServicio.Servicio
        Dim vGestor As New wsServicio.wsTbServicio
        Dim vResultado As String = ""

        If validarCamposLLenos() Then
            Try
                vServicio.IdServicio = IdServicio
                vServicio.Descripcion = txtDescripcion.Text.Trim
                vServicio.PrecioUnitario = txtPrecioUnitario.Text.Trim
                vServicio.IdImpuesto = ddlImpuesto.Text
                vServicio.IdEstado = ddlEstado.Text

                vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                vGestor.Timeout = -1

                Select Case Transaccion
                    Case "A"
                        vResultado = vGestor.TbServicioInsertarServicio(vServicio)
                    Case "M"
                        vResultado = vGestor.TbServicioActualizarServicio(vServicio)
                    Case "E"
                        vResultado = vGestor.TbServicioEliminarServicio(vServicio)
                End Select

                If vResultado = "" Then
                    Response.Redirect("listadoServicios.aspx", False)
                Else
                    pnErrorInicioSesion.CssClass = "panel panel-default"
                    lbErrorInicioSesion.Text = vResultado
                End If

            Catch vExc As Exception
                pnErrorInicioSesion.CssClass = "panel panel-default"
                lbErrorInicioSesion.Text = vExc.Message
            End Try
        Else
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = "Debe de digitar todos los campos del formulario."
        End If
    End Sub

    Protected Function validarCamposLLenos()
        Dim vResultado As Boolean = False
        If txtDescripcion.Text <> "" And txtPrecioUnitario.Text <> "" Then
            vResultado = True
        Else
            vResultado = False
        End If
        Return vResultado
    End Function

    Protected Sub limpiarCampos()
        txtDescripcion.Text = ""
        txtPrecioUnitario.Text = ""
    End Sub

    Protected Sub maServicios_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class