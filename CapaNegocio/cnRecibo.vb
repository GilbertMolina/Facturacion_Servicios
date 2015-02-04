Imports CapaAccesoDatos
Imports Objetos

Public Class cnRecibo

#Region "Variable de instancia"
    Dim vCadRecibo As New cadRecibo
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarRecibos() As DataSet
        Return vCadRecibo.consultarRecibos()
    End Function

    Public Function consultarReciboID(ByVal pRecibo As Recibo) As DataSet
        Return vCadRecibo.consultarReciboID(pRecibo)
    End Function

    Public Function consultarReciboBusquedaMantenimiento(ByVal pRecibo As Recibo) As Recibo
        Return vCadRecibo.consultarReciboBusquedaMantenimiento(pRecibo)
    End Function

    Public Function insertarRecibo(ByVal pRecibo As Recibo) As String
        Dim vReciboConsultado As New Recibo
        Dim vResultado As String = ""
        Try
            vReciboConsultado = pRecibo
            vReciboConsultado = vCadRecibo.consultarReciboBusquedaMantenimiento(vReciboConsultado)
            If vReciboConsultado.IdRecibo = "-1" Then
                vCadRecibo.insertarRecibo(pRecibo)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadRecibo Is Nothing) Then
                vCadRecibo = Nothing
            End If
            If Not (vReciboConsultado Is Nothing) Then
                vReciboConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarRecibo(ByVal pRecibo As Recibo) As String
        Dim vReciboConsultado As New Recibo
        Dim vResultado As String = ""
        Try
            vReciboConsultado = pRecibo
            vReciboConsultado = vCadRecibo.consultarReciboBusquedaMantenimiento(vReciboConsultado)
            If vReciboConsultado.IdRecibo <> "-1" Then
                vCadRecibo.actualizarRecibo(pRecibo)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadRecibo Is Nothing) Then
                vCadRecibo = Nothing
            End If
            If Not (vReciboConsultado Is Nothing) Then
                vReciboConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarRecibo(ByVal pRecibo As Recibo) As String
        Dim vReciboConsultado As New Recibo
        Dim vResultado As String = ""
        Try
            vReciboConsultado = pRecibo
            vReciboConsultado = vCadRecibo.consultarReciboBusquedaMantenimiento(vReciboConsultado)
            If vReciboConsultado.IdRecibo <> "-1" Then
                vCadRecibo.eliminarRecibo(pRecibo)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadRecibo Is Nothing) Then
                vCadRecibo = Nothing
            End If
            If Not (vReciboConsultado Is Nothing) Then
                vReciboConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
