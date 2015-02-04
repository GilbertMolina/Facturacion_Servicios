Imports System.Data
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports System.IO

Public Class rptFacturasImpresas
    Inherits System.Web.UI.Page

    Private _Correo As String
    Dim metodosUtiles As New utiles

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

        ReporteFacturas.LocalReport.DataSources.Clear()
        Dim vAdapter As New DataSetFacturasTableAdapters.SP_Reporte_FacturasTableAdapter
        Dim vTabla As New DataSetFacturas.SP_Reporte_FacturasDataTable

        vAdapter.FillFacturas(vTabla, Correo)
        ReporteFacturas.LocalReport.DataSources.Add(New ReportDataSource("DataSetFacturas", CType(vTabla, DataTable)))

        ReporteFacturas.DataBind()
        ReporteFacturas.Visible = True
    End Sub

    Protected Sub maImpuestos_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
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

        ReporteFacturas.LocalReport.DataSources.Clear()
        Dim vAdapter As New DataSetFacturasTableAdapters.SP_Reporte_FacturasTableAdapter
        Dim vTabla As New DataSetFacturas.SP_Reporte_FacturasDataTable
        vAdapter.FillByFecha(vTabla, Correo, FechIni, FechFin)
        ReporteFacturas.LocalReport.DataSources.Add(New ReportDataSource("DataSetFacturas", CType(vTabla, DataTable)))
        ReporteFacturas.DataBind()
        ReporteFacturas.Visible = True

    End Sub

#End Region

    
End Class