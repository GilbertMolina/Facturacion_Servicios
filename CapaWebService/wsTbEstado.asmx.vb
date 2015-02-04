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
Public Class wsTbEstado
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Estados por medio de un DataSet.")> _
    Public Function TbPersonaConsultarEstados() As DataSet
        Dim vCnEstado As New cnEstado
        Dim vDataset As New DataSet
        Try
            vDataset = vCnEstado.consultarEstados()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnEstado Is Nothing) Then
                vCnEstado = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Estado por su ID y retorna a un Estado.")> _
    Public Function TbEstadoConsultarEstado(ByVal pEstado As Estado) As Estado
        Dim vCnEstado As New cnEstado
        Try
            pEstado = vCnEstado.consultarEstado(pEstado)
            Return pEstado
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pEstado
        Finally
            If Not (vCnEstado Is Nothing) Then
                vCnEstado = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta un Estado.")> _
    Public Function TbEstadoInsertarEstado(ByVal pEstado As Estado) As String
        Dim vCnEstado As New cnEstado
        Dim vResultado As String = ""
        Try
            vResultado = vCnEstado.insertarEstado(pEstado)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnEstado Is Nothing) Then
                vCnEstado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza un Estado.")> _
    Public Function TbEstadoActualizarEstado(ByVal pEstado As Estado) As String
        Dim vCnEstado As New cnEstado
        Dim vResultado As String = ""
        Try
            vResultado = vCnEstado.actualizarEstado(pEstado)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnEstado Is Nothing) Then
                vCnEstado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina un Estado.")> _
    Public Function TbEstadoEliminarEstado(ByVal pEstado As Estado) As String
        Dim vCnEstado As New cnEstado
        Dim vResultado As String = ""
        Try
            vResultado = vCnEstado.eliminarEstado(pEstado)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnEstado Is Nothing) Then
                vCnEstado = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class