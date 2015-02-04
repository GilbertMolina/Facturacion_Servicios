Imports CapaAccesoDatos
Imports Objetos

Public Class cnServicio

#Region "Variable de instancia"
    Dim vCadServicio As New cadServicio
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarServicios() As DataSet
        Return vCadServicio.consultarServicios()
    End Function

    Public Function consultarServiciosFiltros(ByVal pDescripcion As String, ByVal pPrecioUnitario As Double) As DataSet
        Return vCadServicio.consultarServiciosFiltros(pDescripcion, pPrecioUnitario)
    End Function

    Public Function consultarServicio(ByVal pServicio As Servicio) As Servicio
        Return vCadServicio.consultarServicio(pServicio)
    End Function

    Public Function insertarServicio(ByVal pServicio As Servicio) As String
        Dim vServicioConsultado As New Servicio
        Dim vResultado As String = ""
        Try
            vServicioConsultado = pServicio
            vServicioConsultado = vCadServicio.consultarServicio(vServicioConsultado)
            If vServicioConsultado.IdServicio = "-1" Then
                vCadServicio.insertarServicio(pServicio)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadServicio Is Nothing) Then
                vCadServicio = Nothing
            End If
            If Not (vServicioConsultado Is Nothing) Then
                vServicioConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarServicio(ByVal pServicio As Servicio) As String
        Dim vServicioConsultado As New Servicio
        Dim vResultado As String = ""
        Try
            vServicioConsultado = pServicio
            vServicioConsultado = vCadServicio.consultarServicio(vServicioConsultado)
            If vServicioConsultado.IdServicio <> "-1" Then
                vCadServicio.actualizarServicio(pServicio)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadServicio Is Nothing) Then
                vCadServicio = Nothing
            End If
            If Not (vServicioConsultado Is Nothing) Then
                vServicioConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarServicio(ByVal pServicio As Servicio) As String
        Dim vServicioConsultado As New Servicio
        Dim vResultado As String = ""
        Try
            vServicioConsultado = pServicio
            vServicioConsultado = vCadServicio.consultarServicio(vServicioConsultado)
            If vServicioConsultado.IdServicio <> "-1" Then
                vCadServicio.eliminarServicio(pServicio)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadServicio Is Nothing) Then
                vCadServicio = Nothing
            End If
            If Not (vServicioConsultado Is Nothing) Then
                vServicioConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
