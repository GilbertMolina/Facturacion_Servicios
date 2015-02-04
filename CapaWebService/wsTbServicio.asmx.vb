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
Public Class wsTbServicio
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Servicios por medio de un DataSet.")> _
    Public Function TbServicioConsultarServicios() As DataSet
        Dim vCnServicio As New cnServicio
        Dim vDataset As New DataSet
        Try
            vDataset = vCnServicio.consultarServicios()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnServicio Is Nothing) Then
                vCnServicio = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Servicio por su ID y retorna un Servicio.")> _
    Public Function TbServicioConsultarServicio(ByVal pServicio As Servicio) As Servicio
        Dim vCnServicio As New cnServicio
        Try
            pServicio = vCnServicio.consultarServicio(pServicio)
            Return pServicio
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pServicio
        Finally
            If Not (vCnServicio Is Nothing) Then
                vCnServicio = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Servicios pasandole como filtros la descripción o el precio unitario y retorna un DataSet.")> _
    Public Function TbServicioConsultarServiciosFiltros(ByVal pDescripcion As String, ByVal pPrecioUnitario As Double) As DataSet
        Dim vCnServicio As New cnServicio
        Dim vDataset As New DataSet
        Try
            vDataset = vCnServicio.consultarServiciosFiltros(pDescripcion, pPrecioUnitario)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnServicio Is Nothing) Then
                vCnServicio = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta un Servicio.")> _
    Public Function TbServicioInsertarServicio(ByVal pServicio As Servicio) As String
        Dim vCnServicio As New cnServicio
        Dim vResultado As String = ""
        Try
            vResultado = vCnServicio.insertarServicio(pServicio)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnServicio Is Nothing) Then
                vCnServicio = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza un Servicio.")> _
    Public Function TbServicioActualizarServicio(ByVal pServicio As Servicio) As String
        Dim vCnServicio As New cnServicio
        Dim vResultado As String = ""
        Try
            vResultado = vCnServicio.actualizarServicio(pServicio)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnServicio Is Nothing) Then
                vCnServicio = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina un Servicio.")> _
    Public Function TbServicioEliminarServicio(ByVal pServicio As Servicio) As String
        Dim vCnServicio As New cnServicio
        Dim vResultado As String = ""
        Try
            vResultado = vCnServicio.eliminarServicio(pServicio)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnServicio Is Nothing) Then
                vCnServicio = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class