Public Class _default
    Inherits System.Web.UI.Page

#Region "Métodos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        limpiarMensajesError()
        iniciarSesion()
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
        limpiarMensajesError()
    End Sub

    Protected Sub iniciarSesion()
        Dim vPersona As New wsPersona.Persona
        Dim vGestor As New wsPersona.wsTbPersona
        Dim metodosUtiles As New utiles

        If txtCorreo.Text <> "" And txtContraseña.Text <> "" Then
            If metodosUtiles.validarEmailCorrecto(txtCorreo.Text.Trim) Then
                Try
                    vPersona.Correo = txtCorreo.Text.Trim
                    vPersona.Contrasena = txtContraseña.Text

                    vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                    vGestor.Timeout = -1

                    vPersona = vGestor.TbPersonaConsultarPersonaLogin(vPersona)
                    If vPersona.Correo <> "-1" And vPersona.IdEstado = "1" Then   'Estado: 1=Activo | 2=Inactivo
                        Session("vCorreoElectronico") = vPersona.Correo.Trim
                        Session("vCedula") = vPersona.Cedula.Trim
                        Session("vNombreUsuario") = vPersona.Nombre.Trim
                        Session("vPrimerApellido") = vPersona.Apellido1.Trim
                        Session("vSegundoApellido") = vPersona.Apellido2.Trim
                        Session("vIdRol") = vPersona.IdRol
                        Session("vIdEstado") = vPersona.IdEstado
                        Response.Redirect("inicio.aspx", False)
                    Else
                        pnErrorInicioSesion.CssClass = "panel panel-default"
                        If vPersona.Correo = "-1" Then
                            lbErrorInicioSesion.Text = "Usuario o contraseña incorrectos."
                        Else
                            If vPersona.IdEstado = "2" Then
                                lbErrorInicioSesion.Text = "El usuario se encuentra inhabilitado, por favor contacte con el personal de soporte."
                            End If
                        End If
                    End If
                Catch vExc As Exception
                    Throw New Exception(vExc.Message, vExc)
                Finally
                    If Not (vGestor Is Nothing) Then
                        vGestor.Dispose()
                    End If
                    vPersona = Nothing
                End Try
            Else
                pnErrorInicioSesion.CssClass = "panel panel-default"
                lbErrorInicioSesion.Text = "Digite un correo electrónico válido."
            End If
        Else
            If txtCorreo.Text = "" Or txtContraseña.Text = "" Then
                pnErrorInicioSesion.CssClass = "panel panel-default"
                lbErrorInicioSesion.Text = "Debe introducir ambos campos."
            End If
        End If

    End Sub

    Protected Sub limpiarMensajesError()
        pnErrorInicioSesion.CssClass = "panel panel-default hidden"
    End Sub

    Protected Sub limpiarCampos()
        txtCorreo.Text = ""
        txtContraseña.Text = ""
    End Sub
#End Region

End Class