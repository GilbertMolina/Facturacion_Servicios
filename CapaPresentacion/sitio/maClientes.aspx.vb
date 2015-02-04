Public Class maClientes
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _Transaccion As String
    Private _Correo As String
    Private _Cedula As String
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

    Public Property Correo As String
        Get
            Return ViewState("Correo")
        End Get
        Set(value As String)
            ViewState("Correo") = value
        End Set
    End Property

    Public Property Cedula As String
        Get
            Return ViewState("Cedula")
        End Get
        Set(value As String)
            ViewState("Cedula") = value
        End Set
    End Property
#End Region

#Region "Métodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarDropDownListSexo()
            cargarDropDownListEstado()
            cargarVariablesSession()
            evaluarAccion()
            deshabilitarBotones()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As System.EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub btnAccion_Click(sender As Object, e As System.EventArgs) Handles btnAccion.Click
        ejecutarAccion()
    End Sub

    Protected Sub cargarDropDownListSexo()
        ddlSexo.Items.Clear()
        ddlSexo.Items.Add(New ListItem("Masculino", "M"))
        ddlSexo.Items.Add(New ListItem("Femenino", "F"))
    End Sub

    Protected Sub cargarDropDownListEstado()
        ddlEstado.Items.Clear()
        ddlEstado.Items.Add(New ListItem("Activo", 1))
        ddlEstado.Items.Add(New ListItem("Inactivo", 2))
    End Sub

    Protected Sub cargarVariablesSession()
        Transaccion = Session("vTransaccion")
        Correo = Session("vCorreoConsulta")
        Cedula = Session("vCedulaConsulta")
        'Despues de tomarlas de las variables de session se remueven para no acumular variables en session
        Session.Remove("vTransaccion")
        Session.Remove("vCorreoConsulta")
        Session.Remove("vCedulaConsulta")
    End Sub

    Protected Sub evaluarAccion()
        Select Case Transaccion
            Case "A"
                btnAccion.Text = "Registrar"
                btnAccion.CssClass = "btn btn-success"
            Case "M"
                btnAccion.Text = "Modificar"
                btnAccion.CssClass = "btn btn-warning"
                cargarUsuarioPorID()
            Case "E"
                btnAccion.Text = "Eliminar"
                btnAccion.CssClass = "btn btn-danger"
                cargarUsuarioPorID()
        End Select
    End Sub

    Protected Sub deshabilitarBotones()
        Select Case Transaccion
            Case "M"
                If Session("vIdRol") = 2 Then
                    txtRol.Enabled = False
                    txtRol.CssClass = "form-control"
                End If
                txtCorreo.Enabled = False
                txtCorreo.CssClass = "form-control"
                txtCedula.Enabled = False
                txtCedula.CssClass = "form-control"
                txtContraseña.Enabled = False
                txtContraseña.CssClass = "form-control"
                txtContraseñaConfirmar.Enabled = False
                txtContraseñaConfirmar.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
            Case "E"
                txtCorreo.Enabled = False
                txtCorreo.CssClass = "form-control"
                txtCedula.Enabled = False
                txtCedula.CssClass = "form-control"
                txtNombreUsuario.Enabled = False
                txtNombreUsuario.CssClass = "form-control"
                txtPrimerApellido.Enabled = False
                txtPrimerApellido.CssClass = "form-control"
                txtSegundoApellido.Enabled = False
                txtSegundoApellido.CssClass = "form-control"
                txtFechaNacimiento.Enabled = False
                txtFechaNacimiento.CssClass = "form-control"
                txtDireccion.Enabled = False
                txtDireccion.CssClass = "form-control"
                txtTelefono.Enabled = False
                txtTelefono.CssClass = "form-control"
                ddlSexo.Enabled = False
                ddlSexo.CssClass = "form-control"
                txtContraseña.Enabled = False
                txtContraseña.CssClass = "form-control"
                txtContraseñaConfirmar.Enabled = False
                txtContraseñaConfirmar.CssClass = "form-control"
                txtRol.Enabled = False
                txtRol.CssClass = "form-control"
                ddlEstado.Enabled = False
                ddlEstado.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
        End Select
    End Sub

    Protected Sub cargarUsuarioPorID()
        Dim vPersona As New wsPersona.Persona
        Dim vGestor As New wsPersona.wsTbPersona
        Dim metodosUtiles As New utiles
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vPersona.Correo = Correo
            vPersona.Cedula = Cedula

            vPersona = vGestor.TbPersonaConsultarPersonaBusquedaMantenimiento(vPersona)

            txtCorreo.Text = vPersona.Correo
            txtCedula.Text = vPersona.Cedula
            txtNombreUsuario.Text = vPersona.Nombre
            txtPrimerApellido.Text = vPersona.Apellido1
            txtSegundoApellido.Text = vPersona.Apellido2
            txtFechaNacimiento.Text = metodosUtiles.retornarFechaIngles(vPersona.FechaNacimiento)
            txtDireccion.Text = vPersona.Direccion
            txtTelefono.Text = vPersona.Telefono
            ddlSexo.Text = vPersona.Sexo
            ddlEstado.Text = vPersona.IdEstado
        Catch vExc As Exception
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vPersona = Nothing
        End Try
    End Sub

    Protected Sub ejecutarAccion()
        Dim vPersona As New wsPersona.Persona
        Dim vGestor As New wsPersona.wsTbPersona
        Dim metodosUtiles As New utiles
        Dim vResultado As String = ""

        If validarCamposLLenos() Then
            If metodosUtiles.validarEmailCorrecto(txtCorreo.Text) Then
                If txtContraseña.Text = txtContraseñaConfirmar.Text Then
                    Try
                        vPersona.Correo = txtCorreo.Text.Trim
                        vPersona.Cedula = txtCedula.Text.Trim
                        vPersona.Nombre = txtNombreUsuario.Text.Trim
                        vPersona.Apellido1 = txtPrimerApellido.Text.Trim
                        vPersona.Apellido2 = txtSegundoApellido.Text.Trim
                        vPersona.FechaNacimiento = metodosUtiles.retornarFechaEspanol(txtFechaNacimiento.Text)
                        vPersona.Direccion = txtDireccion.Text
                        vPersona.Telefono = txtTelefono.Text
                        vPersona.Sexo = ddlSexo.Text
                        vPersona.Contrasena = txtContraseña.Text
                        vPersona.IdRol = 6      'Se pasa un "6" ya que lo que se esta registrando es un Cliente
                        vPersona.IdEstado = ddlEstado.Text

                        vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                        vGestor.Timeout = -1

                        Select Case Transaccion
                            Case "A"
                                vResultado = vGestor.TbPersonaInsertarPersona(vPersona)
                            Case "M"
                                vResultado = vGestor.TbPersonaActualizarPersona(vPersona)
                            Case "E"
                                vResultado = vGestor.TbPersonaEliminarPersona(vPersona)
                        End Select

                        If vResultado = "" Then
                            Response.Redirect("listadoClientes.aspx", False)
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
                    lbErrorInicioSesion.Text = "La confirmación de la contraseña no es correcta."
                End If
            Else
                pnErrorInicioSesion.CssClass = "panel panel-default"
                lbErrorInicioSesion.Text = "Digite un correo electrónico válido."
            End If
        Else
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = "Debe de digitar todos los campos del formulario."
        End If
    End Sub

    Protected Function validarCamposLLenos()
        Dim vResultado As Boolean = False
        Select Case Transaccion
            Case "A"
                If txtCorreo.Text <> "" And txtCedula.Text <> "" And txtNombreUsuario.Text <> "" And txtPrimerApellido.Text <> "" And txtSegundoApellido.Text <> "" And txtFechaNacimiento.Text <> "" And txtDireccion.Text <> "" And txtTelefono.Text <> "" And txtContraseña.Text <> "" And txtContraseñaConfirmar.Text <> "" Then
                    vResultado = True
                Else
                    vResultado = False
                End If
            Case "E"
                If txtCorreo.Text <> "" And txtCedula.Text <> "" And txtNombreUsuario.Text <> "" And txtPrimerApellido.Text <> "" And txtSegundoApellido.Text <> "" And txtFechaNacimiento.Text <> "" And txtDireccion.Text <> "" And txtTelefono.Text <> "" Then
                    vResultado = True
                Else
                    vResultado = False
                End If
            Case "M"
                If txtCorreo.Text <> "" And txtCedula.Text <> "" And txtNombreUsuario.Text <> "" And txtPrimerApellido.Text <> "" And txtSegundoApellido.Text <> "" And txtFechaNacimiento.Text <> "" And txtDireccion.Text <> "" And txtTelefono.Text <> "" Then
                    vResultado = True
                Else
                    vResultado = False
                End If
        End Select
        Return vResultado
    End Function

    Protected Sub limpiarCampos()
        txtCorreo.Text = ""
        txtCedula.Text = ""
        txtNombreUsuario.Text = ""
        txtPrimerApellido.Text = ""
        txtSegundoApellido.Text = ""
        txtFechaNacimiento.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        ddlSexo.Text = "M"
        txtContraseña.Text = ""
        txtContraseñaConfirmar.Text = ""
        txtRol.Text = "6"
        ddlEstado.Text = "1"
    End Sub

    Protected Sub maClientes_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class