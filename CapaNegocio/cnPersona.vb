Imports CapaAccesoDatos
Imports Objetos

Public Class cnPersona

#Region "Variable de instancia"
    Dim vCadPersona As New cadPersona
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarPersonas() As DataSet
        Return vCadPersona.consultarPersonas()
    End Function
    Public Function consultarClientes() As DataSet
        Return vCadPersona.consultarClientes()
    End Function

    Public Function consultarPersonasFiltros(ByVal pCedula As String, ByVal pNombreCompleto As String) As DataSet
        Return vCadPersona.consultarPersonasFiltros(pCedula, pNombreCompleto)
    End Function

    Public Function consultarClientesFiltros(ByVal pCedula As String, ByVal pNombreCompleto As String) As DataSet
        Return vCadPersona.consultarClientesFiltros(pCedula, pNombreCompleto)
    End Function

    Public Function consultarPersonaLogin(ByVal pPersona As Persona) As Persona
        Return vCadPersona.consultarPersonaLogin(pPersona)
    End Function

    Public Function consultarPersonaBusquedaContraseña(ByVal pPersona As Persona) As Persona
        Return vCadPersona.consultarPersonaBusquedaContraseña(pPersona)
    End Function

    Public Function consultarPersonaBusquedaMantenimiento(ByVal pPersona As Persona) As Persona
        Return vCadPersona.consultarPersonaMantenimiento(pPersona)
    End Function

    Public Function insertarPersona(ByVal pPersona As Persona) As String
        Dim vPersonaConsultada As New Persona
        Dim vResultado As String = ""
        Try
            vPersonaConsultada = pPersona
            vPersonaConsultada = vCadPersona.consultarPersonaMantenimiento(vPersonaConsultada)
            If vPersonaConsultada.Correo = "-1" Then
                vCadPersona.insertarPersona(pPersona)
                vResultado = ""
            Else
                vResultado = "Ya se encuentra una persona agregada con el mismo número de cédula o el mismo correo, o ambos."
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vResultado = "Ocurrió un error a la hora de agregar a la persona."
        Finally
            If Not (vCadPersona Is Nothing) Then
                vCadPersona = Nothing
            End If
            If Not (vPersonaConsultada Is Nothing) Then
                vPersonaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarPersona(ByVal pPersona As Persona) As String
        Dim vPersonaConsultada As New Persona
        Dim vResultado As String = ""
        Try
            vPersonaConsultada = pPersona
            vPersonaConsultada = vCadPersona.consultarPersonaMantenimiento(vPersonaConsultada)
            If vPersonaConsultada.Correo <> "-1" Then
                vCadPersona.actualizarPersona(pPersona)
                vResultado = ""
            Else
                vResultado = "La persona no se encuentra agregada."
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vResultado = "Ocurrió un error a la hora de modificar a la persona."
        Finally
            If Not (vCadPersona Is Nothing) Then
                vCadPersona = Nothing
            End If
            If Not (vPersonaConsultada Is Nothing) Then
                vPersonaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarPersonaContraseña(ByVal pPersona As Persona) As String
        Dim vResultado As String = ""
        Try
            vCadPersona.actualizarPersonaContraseña(pPersona)
            vResultado = ""
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vResultado = "Ocurrió un error a la hora de modificar a la persona."
        Finally
            If Not (vCadPersona Is Nothing) Then
                vCadPersona = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarPersona(ByVal pPersona As Persona) As String
        Dim vPersonaConsultada As New Persona
        Dim vResultado As String = ""
        Try
            vPersonaConsultada = pPersona
            vPersonaConsultada = vCadPersona.consultarPersonaMantenimiento(vPersonaConsultada)
            If vPersonaConsultada.Correo <> "-1" Then
                vCadPersona.eliminarPersona(pPersona)
                vResultado = ""
            Else
                vResultado = "La persona no se encuentra agregada."
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vResultado = "Ocurrió un error a la hora de desactivar a la persona."
        Finally
            If Not (vCadPersona Is Nothing) Then
                vCadPersona = Nothing
            End If
            If Not (vPersonaConsultada Is Nothing) Then
                vPersonaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
