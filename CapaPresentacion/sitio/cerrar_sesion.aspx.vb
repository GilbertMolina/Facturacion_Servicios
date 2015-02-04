Public Class cerrar_sesion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cerrar_sesion_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Session.Remove(Session("vCorreoElectronico"))
        Session.Remove(Session("vNombreUsuario"))
        Session.Remove(Session("vPrimerApellido"))
        Session.Remove(Session("vSegundoApellido"))
        Session.Remove(Session("vIdRol"))
        Session.Remove(Session("vIdEstado"))
        Session.RemoveAll()
        Response.Redirect("default.aspx")
    End Sub

End Class