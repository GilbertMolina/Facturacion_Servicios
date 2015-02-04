Imports CapaAccesoDatos
Imports Objetos

Public Class cnDetalleFactura

#Region "Variable de instancia"
    Dim vCadDetalleFactura As New cadDetalleFactura
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarDetallesFactura(ByVal pIdFactura As Integer) As DataSet
        Return vCadDetalleFactura.consultarDetallesFactura(pIdFactura)
    End Function

    Public Function consultarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As DetalleFactura
        Return vCadDetalleFactura.consultarDetalleFactura(pDetalleFactura)
    End Function

    Public Function insertarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As String
        Dim vDetalleFacturaConsultado As New DetalleFactura
        Dim vResultado As String = ""
        Try
            vDetalleFacturaConsultado = pDetalleFactura
            vDetalleFacturaConsultado = vCadDetalleFactura.consultarDetalleFactura(vDetalleFacturaConsultado)
            If vDetalleFacturaConsultado.IdDetalleFactura = -1 Then
                vCadDetalleFactura.insertarDetalleFactura(pDetalleFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadDetalleFactura Is Nothing) Then
                vCadDetalleFactura = Nothing
            End If
            If Not (vDetalleFacturaConsultado Is Nothing) Then
                vDetalleFacturaConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As String
        Dim vDetalleFacturaConsultado As New DetalleFactura
        Dim vResultado As String = ""
        Try
            vDetalleFacturaConsultado = pDetalleFactura
            vDetalleFacturaConsultado = vCadDetalleFactura.consultarDetalleFactura(vDetalleFacturaConsultado)
            If vDetalleFacturaConsultado.IdDetalleFactura <> -1 Then
                vCadDetalleFactura.actualizarDetalleFactura(pDetalleFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadDetalleFactura Is Nothing) Then
                vCadDetalleFactura = Nothing
            End If
            If Not (vDetalleFacturaConsultado Is Nothing) Then
                vDetalleFacturaConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As String
        Dim vDetalleFacturaConsultado As New DetalleFactura
        Dim vResultado As String = ""
        Try
            vDetalleFacturaConsultado = pDetalleFactura
            vDetalleFacturaConsultado = vCadDetalleFactura.consultarDetalleFactura(vDetalleFacturaConsultado)
            If vDetalleFacturaConsultado.IdDetalleFactura <> -1 Then
                vCadDetalleFactura.eliminarDetalleFactura(pDetalleFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadDetalleFactura Is Nothing) Then
                vCadDetalleFactura = Nothing
            End If
            If Not (vDetalleFacturaConsultado Is Nothing) Then
                vDetalleFacturaConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
