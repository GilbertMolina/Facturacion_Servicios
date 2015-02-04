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
Public Class wsTbPersona
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Método que consulta la lista de Personas por medio de un DataSet.")> _
    Public Function TbPersonaConsultarPersonas() As DataSet
        Dim vCnPersona As New cnPersona
        Dim vDataset As New DataSet
        Try
            vDataset = vCnPersona.consultarPersonas()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Clientes por medio de un DataSet.")> _
    Public Function TbPersonaConsultarClientes() As DataSet
        Dim vCnPersona As New cnPersona
        Dim vDataset As New DataSet
        Try
            vDataset = vCnPersona.consultarClientes()
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Personas pasandole como filtros el numero de cedula o el nombre completo de un usuario y retorna un DataSet.")> _
    Public Function TbPersonaConsultarPersonasFiltros(ByVal pCedula As String, ByVal pNombreCompleto As String) As DataSet
        Dim vCnPersona As New cnPersona
        Dim vDataset As New DataSet
        Try
            vDataset = vCnPersona.consultarPersonasFiltros(pCedula, pNombreCompleto)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta la lista de Clientes pasandole como filtros el numero de cedula o el nombre completo y retorna un DataSet.")> _
    Public Function TbPersonaConsultarClientesFiltros(ByVal pCedula As String, ByVal pNombreCompleto As String) As DataSet
        Dim vCnPersona As New cnPersona
        Dim vDataset As New DataSet
        Try
            vDataset = vCnPersona.consultarClientesFiltros(pCedula, pNombreCompleto)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta a una Persona por su correo y contraseña y retorna a una Persona.")> _
    Public Function TbPersonaConsultarPersonaLogin(ByVal pPersona As Persona) As Persona
        Dim vCnPersona As New cnPersona
        Try
            pPersona = vCnPersona.consultarPersonaLogin(pPersona)
            Return pPersona
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pPersona
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta a una Persona para recordar un contraseña y retorna a una Persona.")> _
    Public Function TbPersonaConsultarPersonaBusquedaContraseña(ByVal pPersona As Persona) As Persona
        Dim vCnPersona As New cnPersona
        Try
            pPersona = vCnPersona.consultarPersonaBusquedaContraseña(pPersona)
            Return pPersona
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pPersona
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que consulta a una Persona por su correo y cedula y retorna a una Persona.")> _
    Public Function TbPersonaConsultarPersonaBusquedaMantenimiento(ByVal pPersona As Persona) As Persona
        Dim vCnPersona As New cnPersona
        Try
            pPersona = vCnPersona.consultarPersonaBusquedaMantenimiento(pPersona)
            Return pPersona
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return pPersona
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
    End Function

    <WebMethod(Description:="Método que inserta a una Persona.")> _
    Public Function TbPersonaInsertarPersona(ByVal pPersona As Persona) As String
        Dim vCnPersona As New cnPersona
        Dim vResultado As String = ""
        Try
            vResultado = vCnPersona.insertarPersona(pPersona)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza a una Persona.")> _
    Public Function TbPersonaActualizarPersona(ByVal pPersona As Persona) As String
        Dim vCnPersona As New cnPersona
        Dim vResultado As String = ""
        Try
            vResultado = vCnPersona.actualizarPersona(pPersona)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que actualiza la contraseña de una Persona.")> _
    Public Function TbPersonaActualizarPersonaContraseña(ByVal pPersona As Persona) As String
        Dim vCnPersona As New cnPersona
        Dim vResultado As String = ""
        Try
            vResultado = vCnPersona.actualizarPersonaContraseña(pPersona)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
        Return vResultado
    End Function

    <WebMethod(Description:="Método que elimina a una Persona.")> _
    Public Function TbPersonaEliminarPersona(ByVal pPersona As Persona) As String
        Dim vCnPersona As New cnPersona
        Dim vResultado As String = ""
        Try
            vResultado = vCnPersona.eliminarPersona(pPersona)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCnPersona Is Nothing) Then
                vCnPersona = Nothing
            End If
        End Try
        Return vResultado
    End Function

End Class