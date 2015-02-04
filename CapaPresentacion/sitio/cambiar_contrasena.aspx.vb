Public Class cambiar_contrasena
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _Correo As String
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property Correo As String
        Get
            Return ViewState("Correo")
        End Get
        Set(value As String)
            ViewState("Correo") = value
        End Set
    End Property
#End Region

#Region "Metodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
        limpiarMensajesError()
    End Sub

    Protected Sub btnRecordar_Click(sender As Object, e As EventArgs) Handles btnRecordar.Click
        limpiarMensajesError()
        cambiarContrasena()
    End Sub

    Protected Sub cambiarContrasena()
        Dim vPersona As New wsPersona.Persona
        Dim vPersonaConsultada As New wsPersona.Persona
        Dim vGestor As New wsPersona.wsTbPersona
        Dim vResultado As String = ""

        Try
            If txtContraseñaAnterior.Text <> "" And txtContraseñaNueva.Text <> "" And txtContraseñaNuevaConfirmar.Text <> "" Then

                vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                vGestor.Timeout = -1

                vPersonaConsultada.Correo = Correo
                vPersonaConsultada.Contrasena = txtContraseñaAnterior.Text
                vPersonaConsultada = vGestor.TbPersonaConsultarPersonaLogin(vPersonaConsultada)
                If vPersonaConsultada.Correo <> "-1" Then
                    If txtContraseñaNueva.Text = txtContraseñaNuevaConfirmar.Text Then
                        vPersona.Correo = Correo
                        vPersona.Contrasena = txtContraseñaNueva.Text

                        vResultado = vGestor.TbPersonaActualizarPersonaContraseña(vPersona)

                        If vResultado = "" Then
                            pnErrorContraseñasSuccess.CssClass = "panel panel-default"
                            lbErrorContraseñasSuccess.Text = "Se ha cambiado exitosamente su contraseña."
                        Else
                            pnErrorContraseñasFail.CssClass = "panel panel-default"
                            lbErrorContraseñasFail.Text = vResultado
                        End If
                    Else
                        pnErrorContraseñasFail.CssClass = "panel panel-default"
                        lbErrorContraseñasFail.Text = "La confirmación de la contraseña no es correcta."
                    End If
                Else
                    pnErrorContraseñasFail.CssClass = "panel panel-default"
                    lbErrorContraseñasFail.Text = "La contraseña anterior no coincide con la actual, verifiquela por favor."
                End If
            Else
                pnErrorContraseñasFail.CssClass = "panel panel-default"
                lbErrorContraseñasFail.Text = "Debe de digitar todos los campos del formulario."
            End If
        Catch vExc As Exception
            pnErrorContraseñasFail.CssClass = "panel panel-default"
            lbErrorContraseñasFail.Text = vExc.Message
        End Try
    End Sub

    Protected Sub limpiarCampos()
        txtContraseñaAnterior.Text = ""
        txtContraseñaNueva.Text = ""
        txtContraseñaNuevaConfirmar.Text = ""
    End Sub

    Protected Sub limpiarMensajesError()
        pnErrorContraseñasFail.CssClass = "panel panel-default hidden"
        pnErrorContraseñasSuccess.CssClass = "panel panel-default hidden"
    End Sub

    Protected Sub maUsuarios_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
            Correo = Session("vCorreoElectronico")  'Se asigna lo que tiene la variable de session que contiene el correo a la propiedad Correo y hacer uso de la propiedad
        End If
    End Sub
#End Region

End Class