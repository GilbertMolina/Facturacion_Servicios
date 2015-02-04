Imports CapaAccesoDatos
Imports Objetos

Public Class cnEstado

#Region "Variable de instancia"
    Dim vCadEstado As New cadEstado
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarEstados() As DataSet
        Return vCadEstado.consultarEstados()
    End Function

    Public Function consultarEstado(ByVal pEstado As Estado) As Estado
        Return vCadEstado.consultarEstado(pEstado)
    End Function

    Public Function insertarEstado(ByVal pEstado As Estado) As String
        Dim vEstadoConsultado As New Estado
        Dim vResultado As String = ""
        Try
            vEstadoConsultado = pEstado
            vEstadoConsultado = vCadEstado.consultarEstado(vEstadoConsultado)
            If vEstadoConsultado.IdEstado = -1 Then
                vCadEstado.insertarEstado(pEstado)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadEstado Is Nothing) Then
                vCadEstado = Nothing
            End If
            If Not (vEstadoConsultado Is Nothing) Then
                vEstadoConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarEstado(ByVal pEstado As Estado) As String
        Dim vEstadoConsultado As New Estado
        Dim vResultado As String = ""
        Try
            vEstadoConsultado = pEstado
            vEstadoConsultado = vCadEstado.consultarEstado(vEstadoConsultado)
            If vEstadoConsultado.IdEstado <> -1 Then
                vCadEstado.actualizarEstado(pEstado)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadEstado Is Nothing) Then
                vCadEstado = Nothing
            End If
            If Not (vEstadoConsultado Is Nothing) Then
                vEstadoConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarEstado(ByVal pEstado As Estado) As String
        Dim vEstadoConsultado As New Estado
        Dim vResultado As String = ""
        Try
            vEstadoConsultado = pEstado
            vEstadoConsultado = vCadEstado.consultarEstado(vEstadoConsultado)
            If vEstadoConsultado.IdEstado <> -1 Then
                vCadEstado.eliminarEstado(pEstado)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadEstado Is Nothing) Then
                vCadEstado = Nothing
            End If
            If Not (vEstadoConsultado Is Nothing) Then
                vEstadoConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
