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
Public Class wsTbRecibo
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Recibos por medio de un DataSet.")> _
    Public Function TbReciboConsultarRecibos() As DataSet
        Dim vCnRecibo As New cnRecibo
        Dim vDataset As New DataSet
        Try
            vDataset = vCnRecibo.consultarRecibos()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnRecibo Is Nothing) Then
                vCnRecibo = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Recibo por su ID y retorna un Recibo.")> _
    Public Function consultarReciboBusquedaMantenimiento(ByVal pRecibo As Recibo) As Recibo
        Dim vCnRecibo As New cnRecibo
        Try
            pRecibo = vCnRecibo.consultarReciboBusquedaMantenimiento(pRecibo)
            Return pRecibo
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pRecibo
        Finally
            If Not (vCnRecibo Is Nothing) Then
                vCnRecibo = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Recibo por su ID y retorna un Recibo.")> _
    Public Function TbReciboConsultarReciboID(ByVal pRecibo As Recibo) As DataSet
        Dim vCnRecibo As New cnRecibo
        Dim vDataSet As New DataSet
        Try
            vDataSet = vCnRecibo.consultarReciboID(pRecibo)
            Return vDataSet
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataSet
        Finally
            If Not (vCnRecibo Is Nothing) Then
                vCnRecibo = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta un Recibo.")> _
    Public Function TbReciboInsertarRecibo(ByVal pRecibo As Recibo) As String
        Dim vCnRecibo As New cnRecibo
        Dim vResultado As String = ""
        Try
            vResultado = vCnRecibo.insertarRecibo(pRecibo)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnRecibo Is Nothing) Then
                vCnRecibo = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza un Recibo.")> _
    Public Function TbReciboActualizarRecibo(ByVal pRecibo As Recibo) As String
        Dim vCnRecibo As New cnRecibo
        Dim vResultado As String = ""
        Try
            vResultado = vCnRecibo.actualizarRecibo(pRecibo)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnRecibo Is Nothing) Then
                vCnRecibo = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina un Recibo.")> _
    Public Function TbReciboEliminarRecibo(ByVal pRecibo As Recibo) As String
        Dim vCnRecibo As New cnRecibo
        Dim vResultado As String = ""
        Try
            vResultado = vCnRecibo.eliminarRecibo(pRecibo)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnRecibo Is Nothing) Then
                vCnRecibo = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class