Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports CapaNegocio
Imports Objetos

' Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class wsTbFactura
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Facturas por medio de un DataSet.")> _
    Public Function TbFacturaConsultarFacturas(ByVal pTipoFactura As Integer) As DataSet
        Dim vCnFactura As New cnFactura
        Dim vDataset As New DataSet
        Try
            vDataset = vCnFactura.consultarFacturas(pTipoFactura)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Personas pasandole como filtros el número de factura o el nombre completo de un cliente y retorna un DataSet.")> _
    Public Function TbFacturaConsultarFacturasFiltros(ByVal pIdFactura As Integer, ByVal pNombreCliente As String) As DataSet
        Dim vCnFactura As New cnFactura
        Dim vDataset As New DataSet
        Try
            vDataset = vCnFactura.consultarFacturasFiltros(pIdFactura, pNombreCliente)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Facturas de un cliente por medio de un DataSet.")> _
    Public Function TbFacturaconsultarFacturasReportes(ByVal pPersona As Persona, ByVal FechIni As Date, ByVal FechFin As Date) As DataSet
        Dim vCnFactura As New cnFactura
        Dim vDataset As New DataSet
        Try
            vDataset = vCnFactura.consultarFacturasReportes(pPersona, FechIni, FechFin)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta a una Factura por su ID y retorna a una Factura.")> _
    Public Function TbFacturaConsultarFacturaBusquedaMantenimiento(ByVal pFactura As Factura) As Factura
        Dim vCnFactura As New cnFactura
        Try
            pFactura = vCnFactura.consultarFacturaBusquedaMantenimiento(pFactura)
            Return pFactura
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pFactura
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta el número de factura siguiente.")> _
    Public Function TbFacturaConsultarFacturaNumeroSiguiente() As Integer
        Dim vCnFactura As New cnFactura
        Dim vNumeroFacturaSiguiente As Integer
        Try
            vNumeroFacturaSiguiente = vCnFactura.consultarFacturaNumeroSiguiente()
            Return vNumeroFacturaSiguiente
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vNumeroFacturaSiguiente
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta el monto total de la factura.")> _
    Public Function TbFacturaConsultarFacturaMontoTotal(ByVal pIdFactura As Integer) As Double
        Dim vCnFactura As New cnFactura
        Dim vMontoTotalFactura As Integer
        Try
            vMontoTotalFactura = vCnFactura.consultarFacturaMontoTotal(pIdFactura)
            Return vMontoTotalFactura
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vMontoTotalFactura
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta a una Factura.")> _
    Public Function TbFacturaInsertarFactura(ByVal pFactura As Factura, ByVal pFecha As Integer) As String
        Dim vCnFactura As New cnFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnFactura.insertarFactura(pFactura, pFecha)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza a una Factura.")> _
    Public Function TbFacturaActualizarFactura(ByVal pFactura As Factura) As String
        Dim vCnFactura As New cnFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnFactura.actualizarFactura(pFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que anula a una Factura.")> _
    Public Function TbFacturaActualizarFacturaMontoTotal(ByVal pFactura As Factura) As String
        Dim vCnFactura As New cnFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnFactura.actualizarFacturaMontoTotal(pFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que imprime a una Factura.")> _
    Public Function TbFacturaImprimirFactura(ByVal pFactura As Factura) As String
        Dim vCnFactura As New cnFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnFactura.imprimirFactura(pFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que anula a una Factura.")> _
    Public Function TbFacturaAnularFactura(ByVal pFactura As Factura) As String
        Dim vCnFactura As New cnFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnFactura.anularFactura(pFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnFactura Is Nothing) Then
                vCnFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class