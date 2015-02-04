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
Public Class wsTbDetalleFactura
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Detalles de una Factura por su ID de Factura, por medio de un DataSet.")> _
    Public Function TbDetalleFacturaConsultarDetallesFactura(ByVal pIdFactura As Integer) As DataSet
        Dim vCnDetalleFactura As New cnDetalleFactura
        Dim vDataset As New DataSet
        Try
            vDataset = vCnDetalleFactura.consultarDetallesFactura(CInt(pIdFactura))
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnDetalleFactura Is Nothing) Then
                vCnDetalleFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Detalle de Factura por su ID de Factura y ID del Detalle, retorna a un Detalle de Factura.")> _
    Public Function TbDetalleFacturaConsultarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As DetalleFactura
        Dim vCnDetalleFactura As New cnDetalleFactura
        Try
            pDetalleFactura = vCnDetalleFactura.consultarDetalleFactura(pDetalleFactura)
            Return pDetalleFactura
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pDetalleFactura
        Finally
            If Not (vCnDetalleFactura Is Nothing) Then
                vCnDetalleFactura = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta una Factura.")> _
    Public Function TbDetalleFacturaInsertarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As String
        Dim vCnDetalleFactura As New cnDetalleFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnDetalleFactura.insertarDetalleFactura(pDetalleFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnDetalleFactura Is Nothing) Then
                vCnDetalleFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza una Factura.")> _
    Public Function TbDetalleFacturaActualizarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As String
        Dim vCnDetalleFactura As New cnDetalleFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnDetalleFactura.actualizarDetalleFactura(pDetalleFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnDetalleFactura Is Nothing) Then
                vCnDetalleFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina una Factura.")> _
    Public Function TbDetalleFacturaEliminarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As String
        Dim vCnDetalleFactura As New cnDetalleFactura
        Dim vResultado As String = ""
        Try
            vResultado = vCnDetalleFactura.eliminarDetalleFactura(pDetalleFactura)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnDetalleFactura Is Nothing) Then
                vCnDetalleFactura = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class