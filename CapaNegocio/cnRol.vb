Imports CapaAccesoDatos
Imports Objetos

Public Class cnRol

#Region "Variable de instancia"
    Dim vCadRol As New cadRol
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarRoles() As DataSet
        Return vCadRol.consultarRoles()
    End Function

    Public Function consultarRol(ByVal pRol As Rol) As Rol
        Return vCadRol.consultarRol(pRol)
    End Function

    Public Function insertarRol(ByVal pRol As Rol) As String
        Dim vRolConsultado As New Rol
        Dim vResultado As String = ""
        Try
            vRolConsultado = pRol
            vRolConsultado = vCadRol.consultarRol(vRolConsultado)
            If vRolConsultado.IdRol = "-1" Then
                vCadRol.insertarRol(pRol)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadRol Is Nothing) Then
                vCadRol = Nothing
            End If
            If Not (vRolConsultado Is Nothing) Then
                vRolConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarRol(ByVal pRol As Rol) As String
        Dim vRolConsultado As New Rol
        Dim vResultado As String = ""
        Try
            vRolConsultado = pRol
            vRolConsultado = vCadRol.consultarRol(vRolConsultado)
            If vRolConsultado.IdRol <> "-1" Then
                vCadRol.actualizarRol(pRol)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadRol Is Nothing) Then
                vCadRol = Nothing
            End If
            If Not (vRolConsultado Is Nothing) Then
                vRolConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarRol(ByVal pRol As Rol) As String
        Dim vRolConsultado As New Rol
        Dim vResultado As String = ""
        Try
            vRolConsultado = pRol
            vRolConsultado = vCadRol.consultarRol(vRolConsultado)
            If vRolConsultado.IdRol <> "-1" Then
                vCadRol.eliminarRol(pRol)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadRol Is Nothing) Then
                vCadRol = Nothing
            End If
            If Not (vRolConsultado Is Nothing) Then
                vRolConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
