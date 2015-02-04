Public Class listadoImpuestos
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

#Region "Metodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarGridView()
        End If
    End Sub

    Protected Sub imgbtnBuscar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBuscar.Click
        limpiarMensajesError()
        cargarGridViewFiltros()
    End Sub

    Protected Sub imgbtnLimpiar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnLimpiar.Click
        limpiarMensajesError()
        limpiarCampos()
        cargarGridView()
    End Sub

    Protected Sub imgbtnAgregar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAgregar.Click
        Session("vTransaccion") = "A"
        Response.Redirect("maImpuestos.aspx")
    End Sub

    Private Sub grdListaImpuestos_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdListaImpuestos.PageIndexChanging
        grdListaImpuestos.PageIndex = e.NewPageIndex
        grdListaImpuestos.DataSource = localData
        grdListaImpuestos.DataBind()
    End Sub

    Private Sub grdListaImpuestos_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdListaImpuestos.RowCommand
        Dim vFilaActual As Integer = CInt(e.CommandArgument)
        If e.CommandName = "Eliminar" Then
            Session("vTransaccion") = "E"
            Session("vIdImpuesto") = grdListaImpuestos.Rows(vFilaActual).Cells(2).Text.Trim
            Response.Redirect("maImpuestos.aspx")
        End If
        If e.CommandName = "Modificar" Then
            Session("vTransaccion") = "M"
            Session("vIdImpuesto") = grdListaImpuestos.Rows(vFilaActual).Cells(2).Text.Trim
            Response.Redirect("maImpuestos.aspx")
        End If
    End Sub

    Protected Sub cargarGridView()
        Dim vGestor As New wsImpuesto.wsTbImpuesto
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vDataSet = vGestor.TbImpuestoConsultarImpuestos
            localData = vDataSet
            grdListaImpuestos.DataSource = vDataSet
            grdListaImpuestos.DataBind()

            If vDataSet.Tables(0).Rows.Count = 0 Then
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = "No hay impuestos agregados por el momento."
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
        Dim vGestor As New wsImpuesto.wsTbImpuesto
        Dim vDataSet As New DataSet
        Dim vPorcentajeTemporal As Double
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            If txtPorcentajeBusqueda.Text = "" Then
                vPorcentajeTemporal = 0
            ElseIf IsNumeric(txtPorcentajeBusqueda.Text) Then
                vPorcentajeTemporal = txtPorcentajeBusqueda.Text
            End If

            vDataSet = vGestor.TbImpuestoConsultarImpuestosFiltros(txtDescripcionBusqueda.Text.Trim, vPorcentajeTemporal)
            localData = vDataSet
            grdListaImpuestos.DataSource = vDataSet
            grdListaImpuestos.DataBind()

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
        txtDescripcionBusqueda.Text = ""
        txtPorcentajeBusqueda.Text = ""
    End Sub

    Protected Sub limpiarMensajesError()
        pnGridViewSinDatos.CssClass = "panel panel-default hidden"
    End Sub

    Protected Sub listadoImpuestos_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class