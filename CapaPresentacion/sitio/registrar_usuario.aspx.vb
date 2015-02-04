Public Class registrar_usuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarDropDownListSexo()
            cargarDropDownListRol()
            cargarDropDownListEstado()
        End If
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
        limpiarMensajesError()
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        limpiarMensajesError()
        registrarUsuario()
        limpiarCampos()
    End Sub

    Protected Sub cargarDropDownListSexo()
        ddlSexo.Items.Clear()
        ddlSexo.Items.Add(New ListItem("Masculino", "M"))
        ddlSexo.Items.Add(New ListItem("Femenino", "F"))
    End Sub

    Protected Sub cargarDropDownListRol()
        ddlRol.Items.Clear()
        ddlRol.Items.Add(New ListItem("Cliente", 6))
    End Sub

    Protected Sub cargarDropDownListEstado()
        ddlEstado.Items.Clear()
        ddlEstado.Items.Add(New ListItem("Activo", 1))
    End Sub

    Protected Sub registrarUsuario()
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
                        vPersona.IdRol = ddlRol.Text
                        vPersona.IdEstado = ddlEstado.Text

                        vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                        vGestor.Timeout = -1

                        vResultado = vGestor.TbPersonaInsertarPersona(vPersona)

                        If vResultado = "" Then
                            pnErrorInicioSesionSuccess.CssClass = "panel panel-default"
                            lbErrorInicioSesionSuccess.Text = "Se ha registrado exitosamente el usuario, puede proceder a iniciar sesión."
                        Else
                            pnErrorInicioSesionFail.CssClass = "panel panel-default"
                            lbErrorInicioSesionFail.Text = vResultado
                        End If
                    Catch vExc As Exception
                        pnErrorInicioSesionFail.CssClass = "panel panel-default"
                        lbErrorInicioSesionFail.Text = vExc.Message
                    End Try
                Else
                    pnErrorInicioSesionFail.CssClass = "panel panel-default"
                    lbErrorInicioSesionFail.Text = "La confirmación de la contraseña no es correcta."
                End If
            Else
                pnErrorInicioSesionFail.CssClass = "panel panel-default"
                lbErrorInicioSesionFail.Text = "Digite un correo electrónico válido."
            End If
        Else
            pnErrorInicioSesionFail.CssClass = "panel panel-default"
            lbErrorInicioSesionFail.Text = "Debe de digitar todos los campos del formulario."
        End If
    End Sub

    Protected Function validarCamposLLenos()
        Dim vResultado As Boolean = False
        If txtCorreo.Text <> "" And txtCedula.Text <> "" And txtNombreUsuario.Text <> "" And txtPrimerApellido.Text <> "" And txtSegundoApellido.Text <> "" And txtFechaNacimiento.Text <> "" And txtDireccion.Text <> "" And txtTelefono.Text <> "" And txtContraseña.Text <> "" And txtContraseñaConfirmar.Text <> "" Then
            vResultado = True
        Else
            vResultado = False
        End If
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
        ddlRol.Text = "6"
        ddlEstado.Text = "1"
    End Sub

    Protected Sub limpiarMensajesError()
        pnErrorInicioSesionFail.CssClass = "panel panel-default hidden"
        pnErrorInicioSesionSuccess.CssClass = "panel panel-default hidden"
    End Sub

End Class