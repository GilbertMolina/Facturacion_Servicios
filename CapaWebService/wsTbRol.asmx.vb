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
Public Class wsTbRol
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Roles por medio de un DataSet.")> _
    Public Function TbRolConsultarRoles() As DataSet
        Dim vCnRol As New cnRol
        Dim vDataset As New DataSet
        Try
            vDataset = vCnRol.consultarRoles()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnRol Is Nothing) Then
                vCnRol = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta un Rol por su ID y retorna un Rol.")> _
    Public Function TbRolConsultarRol(ByVal pRol As Rol) As Rol
        Dim vCnRol As New cnRol
        Try
            pRol = vCnRol.consultarRol(pRol)
            Return pRol
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pRol
        Finally
            If Not (vCnRol Is Nothing) Then
                vCnRol = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta un Rol.")> _
    Public Function TbRolInsertarRol(ByVal pRol As Rol) As String
        Dim vCnRol As New cnRol
        Dim vResultado As String = ""
        Try
            vResultado = vCnRol.insertarRol(pRol)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnRol Is Nothing) Then
                vCnRol = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza un Rol.")> _
    Public Function TbRolActualizarRol(ByVal pRol As Rol) As String
        Dim vCnRol As New cnRol
        Dim vResultado As String = ""
        Try
            vResultado = vCnRol.actualizarRol(pRol)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnRol Is Nothing) Then
                vCnRol = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina un Rol.")> _
    Public Function TbRolEliminarRol(ByVal pRol As Rol) As String
        Dim vCnRol As New cnRol
        Dim vResultado As String = ""
        Try
            vResultado = vCnRol.eliminarRol(pRol)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnRol Is Nothing) Then
                vCnRol = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class