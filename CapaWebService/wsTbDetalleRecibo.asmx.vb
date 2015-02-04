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
Public Class wsTbDetalleRecibo
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Detalles de un Recibo por su ID de Recibo, por medio de un DataSet.")> _
    Public Function TbDetalleReciboConsultarDetallesRecibo(ByVal pIdRecibo As Integer) As DataSet
        Dim vCnDetalleRecibo As New cnDetalleRecibo
        Dim vDataset As New DataSet
        Try
            vDataset = vCnDetalleRecibo.consultarDetallesRecibo(CInt(pIdRecibo))
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnDetalleRecibo Is Nothing) Then
                vCnDetalleRecibo = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Detalle de Recibo por su ID de Recibo y ID del Detalle, retorna un Detalle de Recibo.")> _
    Public Function TbDetalleReciboConsultarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As DetalleRecibo
        Dim vCnDetalleRecibo As New cnDetalleRecibo
        Try
            pDetalleRecibo = vCnDetalleRecibo.consultarDetalleRecibo(pDetalleRecibo)
            Return pDetalleRecibo
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pDetalleRecibo
        Finally
            If Not (vCnDetalleRecibo Is Nothing) Then
                vCnDetalleRecibo = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta un Estado.")> _
    Public Function TbDetalleReciboInsertarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As String
        Dim vCnDetalleRecibo As New cnDetalleRecibo
        Dim vResultado As String = ""
        Try
            vResultado = vCnDetalleRecibo.insertarDetalleRecibo(pDetalleRecibo)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnDetalleRecibo Is Nothing) Then
                vCnDetalleRecibo = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza un Estado.")> _
    Public Function TbDetalleReciboActualizarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As String
        Dim vCnDetalleRecibo As New cnDetalleRecibo
        Dim vResultado As String = ""
        Try
            vResultado = vCnDetalleRecibo.actualizarDetalleRecibo(pDetalleRecibo)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnDetalleRecibo Is Nothing) Then
                vCnDetalleRecibo = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina un Estado.")> _
    Public Function TbDetalleReciboEliminarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As String
        Dim vCnDetalleRecibo As New cnDetalleRecibo
        Dim vResultado As String = ""
        Try
            vResultado = vCnDetalleRecibo.eliminarDetalleRecibo(pDetalleRecibo)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnDetalleRecibo Is Nothing) Then
                vCnDetalleRecibo = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class