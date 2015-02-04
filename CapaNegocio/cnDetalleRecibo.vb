Imports CapaAccesoDatos
Imports Objetos

Public Class cnDetalleRecibo

#Region "Variable de instancia"
    Dim vCadDetalleRecibo As New cadDetalleRecibo
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarDetallesRecibo(ByVal pIdRecibo As Integer) As DataSet
        Return vCadDetalleRecibo.consultarDetallesRecibo(pIdRecibo)
    End Function

    Public Function consultarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As DetalleRecibo
        Return vCadDetalleRecibo.consultarDetalleRecibo(pDetalleRecibo)
    End Function

    Public Function insertarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As String
        Dim vDetalleReciboConsultado As New DetalleRecibo
        Dim vResultado As String = ""
        Try
            vDetalleReciboConsultado = pDetalleRecibo
            vDetalleReciboConsultado = vCadDetalleRecibo.consultarDetalleRecibo(vDetalleReciboConsultado)
            If vDetalleReciboConsultado.IdDetalleRecibo = -1 Then
                vCadDetalleRecibo.insertarDetalleRecibo(pDetalleRecibo)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadDetalleRecibo Is Nothing) Then
                vCadDetalleRecibo = Nothing
            End If
            If Not (vDetalleReciboConsultado Is Nothing) Then
                vDetalleReciboConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As String
        Dim vDetalleReciboConsultado As New DetalleRecibo
        Dim vResultado As String = ""
        Try
            vDetalleReciboConsultado = pDetalleRecibo
            vDetalleReciboConsultado = vCadDetalleRecibo.consultarDetalleRecibo(vDetalleReciboConsultado)
            If vDetalleReciboConsultado.IdDetalleRecibo <> -1 Then
                vCadDetalleRecibo.actualizarDetalleRecibo(pDetalleRecibo)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadDetalleRecibo Is Nothing) Then
                vCadDetalleRecibo = Nothing
            End If
            If Not (vDetalleReciboConsultado Is Nothing) Then
                vDetalleReciboConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As String
        Dim vDetalleReciboConsultado As New DetalleRecibo
        Dim vResultado As String = ""
        Try
            vDetalleReciboConsultado = pDetalleRecibo
            vDetalleReciboConsultado = vCadDetalleRecibo.consultarDetalleRecibo(vDetalleReciboConsultado)
            If vDetalleReciboConsultado.IdDetalleRecibo <> -1 Then
                vCadDetalleRecibo.eliminarDetalleRecibo(pDetalleRecibo)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadDetalleRecibo Is Nothing) Then
                vCadDetalleRecibo = Nothing
            End If
            If Not (vDetalleReciboConsultado Is Nothing) Then
                vDetalleReciboConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
