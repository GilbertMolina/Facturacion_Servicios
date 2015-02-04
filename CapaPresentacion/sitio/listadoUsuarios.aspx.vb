Public Class listadoUsuarios
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _localData As DataSet
#End Region

#Region "Métodos de acceso a las propiedades"
    Public Property localData As DataSet
        Get
            Return ViewState("DatosGridView")
        End Get
        Set(value As DataSet)
            ViewState("DatosGridView") = value
        End Set
    End Property
#End Region

#Region "Métodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarGridView()
        End If
    End Sub

    Private Sub imgbtnBuscar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBuscar.Click
        limpiarMensajesError()
        cargarGridViewFiltros()
    End Sub

    Private Sub imgbtnLimpiar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnLimpiar.Click
        limpiarMensajesError()
        limpiarCampos()
        cargarGridView()
    End Sub

    Private Sub imgbtnAgregar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAgregar.Click
        Session("vTransaccion") = "A"
        Response.Redirect("maUsuarios.aspx")
    End Sub

    Private Sub grdListaUsuarios_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdListaUsuarios.PageIndexChanging
        grdListaUsuarios.PageIndex = e.NewPageIndex
        grdListaUsuarios.DataSource = localData
        grdListaUsuarios.DataBind()
    End Sub

    Private Sub grdListaUsuarios_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdListaUsuarios.RowCommand
        Dim vFilaActual As Integer = CInt(e.CommandArgument)
        If e.CommandName = "Eliminar" Then
            Session("vTransaccion") = "E"
            Session("vCorreoConsulta") = grdListaUsuarios.Rows(vFilaActual).Cells(2).Text.Trim
            Session("vCedulaConsulta") = grdListaUsuarios.Rows(vFilaActual).Cells(3).Text.Trim
            Response.Redirect("maUsuarios.aspx")
        End If
        If e.CommandName = "Modificar" Then
            Session("vTransaccion") = "M"
            Session("vCorreoConsulta") = grdListaUsuarios.Rows(vFilaActual).Cells(2).Text.Trim
            Session("vCedulaConsulta") = grdListaUsuarios.Rows(vFilaActual).Cells(3).Text.Trim
            Response.Redirect("maUsuarios.aspx")
        End If
    End Sub

    Protected Sub cargarGridView()
        Dim vGestor As New wsPersona.wsTbPersona
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vDataSet = vGestor.TbPersonaConsultarPersonas
            localData = vDataSet
            grdListaUsuarios.DataSource = vDataSet
            grdListaUsuarios.DataBind()

            If vDataSet.Tables(0).Rows.Count = 0 Then
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = "No hay usuarios agregados por el momento."
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
        End Try
    End Sub

    Protected Sub cargarGridViewFiltros()
        Dim vGestor As New wsPersona.wsTbPersona
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vDataSet = vGestor.TbPersonaConsultarPersonasFiltros(txtCedulaBusqueda.Text.Trim, txtNombreUsuarioBusqueda.Text.Trim)
            localData = vDataSet
            grdListaUsuarios.DataSource = vDataSet
            grdListaUsuarios.DataBind()

            If vDataSet.Tables(0).Rows.Count = 0 Then
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = "Su búsqueda no retornó ningún resultado."
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
        txtCedulaBusqueda.Text = ""
        txtNombreUsuarioBusqueda.Text = ""
    End Sub

    Protected Sub limpiarMensajesError()
        pnGridViewSinDatos.CssClass = "panel panel-default hidden"
    End Sub

    Protected Sub listadoUsuarios_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class