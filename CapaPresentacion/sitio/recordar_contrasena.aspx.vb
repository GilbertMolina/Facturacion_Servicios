Public Class recordar_contrasena
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Protected Sub limpiarCampos()
        txtCorreo.Text = ""
        txtCedula.Text = ""
        limpiarMensajesError()
    End Sub

    Protected Sub btnRecordar_Click(sender As Object, e As EventArgs) Handles btnRecordar.Click
        limpiarMensajesError()
        recordarContrasena()

    End Sub

    Protected Sub recordarContrasena()
        Dim vGestor As New wsPersona.wsTbPersona
        Dim vPersona As New wsPersona.Persona
        Dim metodosUtiles As New utiles
        Dim vResultado As String

        If txtCorreo.Text <> "" And txtCedula.Text <> "" Then
            If metodosUtiles.validarEmailCorrecto(txtCorreo.Text) Then
                Try
                    vPersona.Correo = txtCorreo.Text
                    vPersona.Cedula = txtCedula.Text

                    vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                    vGestor.Timeout = -1

                    vPersona = vGestor.TbPersonaConsultarPersonaBusquedaContraseña(vPersona)

                    If vPersona.Correo <> "-1" Then
                        Dim vCorreo As New System.Net.Mail.MailMessage()
                        Dim vSMTP As New System.Net.Mail.SmtpClient

                        vCorreo.From = New System.Net.Mail.MailAddress("proyectoserviciosabc@gmail.com")
                        vCorreo.To.Add(Trim(vPersona.Correo))
                        vCorreo.Subject = "Solicitud de recordar contraseña en Servicios ABC"
                        vCorreo.IsBodyHtml = True
                        vCorreo.Body = String.Format("<html>" & _
                                                     "<body>" & _
                                                     "<p>Sr(a) {0} {1},<br /><br />" & _
                                                     "Usted ha solicitado recordar su contraseña en Servicios ABC, los datos son los siguientes.<br /><br />" & _
                                                     "Usuario: <strong>{2}</strong><br /><br />" & _
                                                     "Contraseña: <strong>{3}</strong><br /><br />" & _
                                                     "Que tenga buen día.<br /><br />" & _
                                                     "Saludos cordiales" & _
                                                     "</p>" & _
                                                     "</body>" & _
                                                     "</html>",
                                                     vPersona.Nombre.Trim, vPersona.Apellido1.Trim, vPersona.Correo, vPersona.Contrasena)

                        vSMTP.Host = ("smtp.gmail.com")
                        vSMTP.Port = 587
                        vSMTP.Credentials = New System.Net.NetworkCredential("proyectoserviciosabc@gmail.com", "ServiciosABC123")
                        vSMTP.EnableSsl = True

                        Try
                            vSMTP.Send(vCorreo)
                            vResultado = "Se ha enviado exitosamente su contraseña a su correo electrónico registrado."
                            pnErrorInicioSesionSuccess.CssClass = "panel panel-default"
                            lbErrorInicioSesionSuccess.Text = vResultado
                        Catch vExc As Exception
                            vResultado = vExc.Message
                            pnErrorInicioSesionFail.CssClass = "panel panel-default"
                            lbErrorInicioSesionFail.Text = vResultado
                        End Try
                    Else
                        vResultado = "El número de cédula no coincide."
                        pnErrorInicioSesionFail.CssClass = "panel panel-default"
                        lbErrorInicioSesionFail.Text = vResultado
                    End If
                Catch vExc As Exception
                    vResultado = vExc.Message
                    pnErrorInicioSesionFail.CssClass = "panel panel-default"
                    lbErrorInicioSesionFail.Text = vResultado
                End Try
            Else
                vResultado = "Digite un correo electrónico válido."
                pnErrorInicioSesionFail.CssClass = "panel panel-default"
                lbErrorInicioSesionFail.Text = vResultado
            End If
        Else
            vResultado = "Debe de digitar todos los campos del formulario."
            pnErrorInicioSesionFail.CssClass = "panel panel-default"
            lbErrorInicioSesionFail.Text = vResultado
        End If

    End Sub

    Protected Sub limpiarMensajesError()
        pnErrorInicioSesionFail.CssClass = "panel panel-default hidden"
        pnErrorInicioSesionSuccess.CssClass = "panel panel-default hidden"
    End Sub

End Class