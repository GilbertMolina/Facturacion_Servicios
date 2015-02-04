Imports System.Data
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports System.IO


Public Class rptRecibosImpresos
    Inherits System.Web.UI.Page
    Private _Correo As String
    Dim metodosUtiles As New utiles
    Dim vAdapter As New DataSetRecibosTableAdapters.SP__Reporte_RecibosTableAdapter
    Dim vTabla As New DataSetRecibos.SP__Reporte_RecibosDataTable

#Region "Métodos de acceso a las propiedades"

    Public Property Correo() As String
        Get
            Return _Correo
        End Get
        Set(ByVal value As String)
            _Correo = value
        End Set
    End Property

#End Region

#Region "Metodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarVariablesSession()
        If Not Page.IsPostBack Then
            generaReporte(Correo)
        End If
    End Sub

    Protected Sub cargarVariablesSession()
        Correo = Session("vCorreoElectronico")
    End Sub

    Public Sub generaReporte(ByVal Correo As String)

        ReporteRecibos.LocalReport.DataSources.Clear()
        vAdapter.FillRecibos(vTabla, Correo)
        ReporteRecibos.LocalReport.DataSources.Add(New ReportDataSource("DataSetFacturas", CType(vTabla, DataTable)))
        ReporteRecibos.DataBind()
        ReporteRecibos.Visible = True
    End Sub

    Protected Sub maImpuestos_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub


    Protected Sub BT_Generar_Click(sender As Object, e As EventArgs) Handles BT_Generar.Click
        Dim vFechIni As Date
        Dim vFechFin As Date

        vFechIni = metodosUtiles.retornarFechaIngles(TB_FechIni.Text)
        vFechFin = metodosUtiles.retornarFechaIngles(TB_FechFin.Text)
        reporteFiltrado(Correo, vFechIni, vFechFin)

    End Sub

    Public Sub reporteFiltrado(ByVal FechIni As Date, ByVal FechFin As Date, ByVal Correo As String)

        ReporteRecibos.LocalReport.DataSources.Clear()
        vAdapter.FillByFecha(vTabla, Correo, FechIni, FechFin)
        ReporteRecibos.LocalReport.DataSources.Add(New ReportDataSource("DataSetRecibos", CType(vTabla, DataTable)))
        ReporteRecibos.DataBind()
        ReporteRecibos.Visible = True
        ReporteRecibos.ServerReport.GetDataSources()

    End Sub



#End Region

End Class