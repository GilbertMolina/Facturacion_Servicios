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
Public Class wsTbImpuesto
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Impuestos por medio de un DataSet.")> _
    Public Function TbImpuestoConsultarImpuestos() As DataSet
        Dim vCnImpuesto As New cnImpuesto
        Dim vDataset As New DataSet
        Try
            vDataset = vCnImpuesto.consultarImpuestos()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnImpuesto Is Nothing) Then
                vCnImpuesto = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Impuestos pasandole como filtros la descripción o el porcentaje de impuesto y retorna un DataSet.")> _
    Public Function TbImpuestoConsultarImpuestosFiltros(ByVal pDescripcion As String, ByVal pPorcentajeImpuesto As Double) As DataSet
        Dim vCnImpuesto As New cnImpuesto
        Dim vDataset As New DataSet
        Try
            vDataset = vCnImpuesto.consultarImpuestosFiltros(pDescripcion, pPorcentajeImpuesto)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnImpuesto Is Nothing) Then
                vCnImpuesto = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Impuesto por su ID y retorna un Impuesto.")> _
    Public Function TbImpuestoConsultarImpuestoBusquedaMantenimiento(ByVal pImpuesto As Impuesto) As Impuesto
        Dim vCnImpuesto As New cnImpuesto
        Try
            pImpuesto = vCnImpuesto.consultarImpuestoBusquedaMantenimiento(pImpuesto)
            Return pImpuesto
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pImpuesto
        Finally
            If Not (vCnImpuesto Is Nothing) Then
                vCnImpuesto = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta un Impuesto.")> _
    Public Function TbImpuestoInsertarImpuesto(ByVal pImpuesto As Impuesto) As String
        Dim vCnImpuesto As New cnImpuesto
        Dim vResultado As String = ""
        Try
            vResultado = vCnImpuesto.insertarImpuesto(pImpuesto)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnImpuesto Is Nothing) Then
                vCnImpuesto = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza un Impuesto.")> _
    Public Function TbImpuestoActualizarImpuesto(ByVal pImpuesto As Impuesto) As String
        Dim vCnIMpuesto As New cnImpuesto
        Dim vResultado As String = ""
        Try
            vResultado = vCnIMpuesto.actualizarImpuesto(pImpuesto)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnIMpuesto Is Nothing) Then
                vCnIMpuesto = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina un Impuesto.")> _
    Public Function TbIMpuestoEliminarImpuesto(ByVal pImpuesto As Impuesto) As String
        Dim vCnImpuesto As New cnImpuesto
        Dim vResultado As String = ""
        Try
            vResultado = vCnImpuesto.eliminarImpuesto(pImpuesto)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnImpuesto Is Nothing) Then
                vCnImpuesto = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class