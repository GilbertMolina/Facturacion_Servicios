Imports CapaPresentacion.utiles

Public Class inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbNombreCompletoUsuario.Text = String.Format("{0} {1} {2}", Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"))
        Select Case Session("vIdRol")
            Case 1
                lbRolAsignado.Text = "Super Administrador"
            Case 2
                lbRolAsignado.Text = "Administrador"
            Case 3
                lbRolAsignado.Text = "Agente de Cobros Registro Facturas"
            Case 4
                lbRolAsignado.Text = "Agente de Cobros Registro Recibos"
            Case 5
                lbRolAsignado.Text = "Encargado Seguimiento Cobros"
            Case 6
                lbRolAsignado.Text = "Cliente"
        End Select
    End Sub

    'Este método hay que copiarlo en todas las páginas para que cargue el correcto MasterPage y por consiguiente la correcta Barra de Navegación
    Private Sub inicio_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub

End Class