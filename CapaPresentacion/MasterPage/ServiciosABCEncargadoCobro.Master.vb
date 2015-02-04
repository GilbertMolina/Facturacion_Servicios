Public Class ServiciosABCEncargadoCobro
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbNombreUsuario.Text = String.Format("{0} {1}", Session("vNombreUsuario"), Session("vPrimerApellido"))
    End Sub

End Class