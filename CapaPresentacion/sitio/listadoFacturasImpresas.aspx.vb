Public Class listadoFacturasImpresas
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _localData As DataTable
#End Region

#Region "Métodos de acceso a las propiedades"
    Public Property localData As DataTable
        Get
            Return ViewState("DatosGridView")
        End Get
        Set(value As DataTable)
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

    Private Sub grdListaFacturas_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdListaFacturas.PageIndexChanging
        grdListaFacturas.PageIndex = e.NewPageIndex
        grdListaFacturas.DataSource = localData
        grdListaFacturas.DataBind()
        modificarCampoFechaGridView()
    End Sub

    Protected Sub cargarGridView()
        Dim vGestor As New wsFactura.wsTbFactura
        Dim vDataSet As New DataSet
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vDataSet = vGestor.TbFacturaConsultarFacturas(4)    'Facturas impresas
            grdListaFacturas.DataSource = vDataSet
            grdListaFacturas.DataBind()

            modificarCampoFechaGridView()

            If vDataSet.Tables(0).Rows.Count = 0 Then
                pnGridViewSinDatos.CssClass = "panel panel-default"
                lbGridViewSinDatos.Text = "No hay facturas impresas por el momento."
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
        Dim vGestor As New wsFactura.wsTbFactura
        Dim vDataSet As New DataSet
        Dim vIdFacturaTemporal As Double
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            If txtIdFactura.Text = "" Then
                vIdFacturaTemporal = 0
            ElseIf IsNumeric(txtIdFactura.Text) Then
                vIdFacturaTemporal = txtIdFactura.Text
            End If

            vDataSet = vGestor.TbFacturaConsultarFacturasFiltros(vIdFacturaTemporal, txtNombreCliente.Text.Trim)
            grdListaFacturas.DataSource = vDataSet
            grdListaFacturas.DataBind()

            modificarCampoFechaGridView()

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

    Protected Sub modificarCampoFechaGridView()
        For i As Integer = 0 To grdListaFacturas.Rows.Count - 1
            grdListaFacturas.Rows(i).Cells(4).Text = grdListaFacturas.Rows(i).Cells(4).Text.Split(" ")(0)   'Se le quita la hora al campo fecha de emisión para que quede de tipo: 08/07/2014
            grdListaFacturas.Rows(i).Cells(5).Text = grdListaFacturas.Rows(i).Cells(5).Text.Split(" ")(0)   'Se le quita la hora al campo fecha de vencimiento para que quede de tipo: 08/08/2014
        Next
    End Sub

    Protected Sub limpiarCampos()
        txtIdFactura.Text = ""
        txtNombreCliente.Text = ""
    End Sub

    Protected Sub limpiarMensajesError()
        pnGridViewSinDatos.CssClass = "panel panel-default hidden"
    End Sub

    Protected Sub listadoFacturas_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class