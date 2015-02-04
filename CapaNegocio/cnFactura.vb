Imports CapaAccesoDatos
Imports Objetos

Public Class cnFactura

#Region "Variable de instancia"
    Dim vCadFactura As New cadFactura
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarFacturas(ByVal pTipoFactura As Integer) As DataSet
        Return vCadFactura.consultarFacturas(pTipoFactura)
    End Function
    Public Function consultarFacturasFiltros(ByVal pIdFactura As Integer, ByVal pNombreCliente As String) As DataSet
        Return vCadFactura.consultarFacturasFiltros(pIdFactura, pNombreCliente)
    End Function

    Public Function consultarFacturaBusquedaMantenimiento(ByVal pFactura As Factura) As Factura
        Return vCadFactura.consultarFacturaBusquedaMantenimiento(pFactura)
    End Function

    Public Function consultarFacturaNumeroSiguiente() As Integer
        Return vCadFactura.consultarFacturaNumeroSiguiente()
    End Function

    Public Function consultarFacturaMontoTotal(ByVal pIdFactura As Integer) As Double
        Return vCadFactura.consultarFacturaMontoTotal(pIdFactura)
    End Function

    Public Function consultarFacturasReportes(ByVal pPersona As Persona, ByVal FechIni As Date, ByVal FechFin As Date) As DataSet
        Return vCadFactura.consultarFacturasReportes(pPersona, FechIni, FechFin)
    End Function

    Public Function insertarFactura(ByVal pFactura As Factura, ByVal pFecha As Integer) As String
        Dim vFacturaConsultada As New Factura
        Dim vResultado As String = ""
        Try
            vCadFactura.insertarFactura(pFactura, pFecha)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadFactura Is Nothing) Then
                vCadFactura = Nothing
            End If
            If Not (vFacturaConsultada Is Nothing) Then
                vFacturaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarFactura(ByVal pFactura As Factura) As String
        Dim vFacturaConsultada As New Factura
        Dim vResultado As String = ""
        Try
            vFacturaConsultada = pFactura
            vFacturaConsultada = vCadFactura.consultarFacturaBusquedaMantenimiento(vFacturaConsultada)
            If vFacturaConsultada.IdFactura <> -1 Then
                vCadFactura.actualizarFactura(pFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadFactura Is Nothing) Then
                vCadFactura = Nothing
            End If
            If Not (vFacturaConsultada Is Nothing) Then
                vFacturaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarFacturaMontoTotal(ByVal pFactura As Factura) As String
        Dim vFacturaConsultada As New Factura
        Dim vResultado As String = ""
        Try
            vFacturaConsultada = pFactura
            vFacturaConsultada = vCadFactura.consultarFacturaBusquedaMantenimiento(vFacturaConsultada)
            If vFacturaConsultada.IdFactura <> -1 Then
                vCadFactura.actualizarFacturaMontoTotal(pFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadFactura Is Nothing) Then
                vCadFactura = Nothing
            End If
            If Not (vFacturaConsultada Is Nothing) Then
                vFacturaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function imprimirFactura(ByVal pFactura As Factura) As String
        Dim vFacturaConsultada As New Factura
        Dim vResultado As String = ""
        Try
            vFacturaConsultada = pFactura
            vFacturaConsultada = vCadFactura.consultarFacturaBusquedaMantenimiento(vFacturaConsultada)
            If vFacturaConsultada.IdFactura <> -1 Then
                vCadFactura.imprimirFactura(pFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadFactura Is Nothing) Then
                vCadFactura = Nothing
            End If
            If Not (vFacturaConsultada Is Nothing) Then
                vFacturaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function anularFactura(ByVal pFactura As Factura) As String
        Dim vFacturaConsultada As New Factura
        Dim vResultado As String = ""
        Try
            vFacturaConsultada = pFactura
            vFacturaConsultada = vCadFactura.consultarFacturaBusquedaMantenimiento(vFacturaConsultada)
            If vFacturaConsultada.IdFactura <> -1 Then
                vCadFactura.anularFactura(pFactura)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadFactura Is Nothing) Then
                vCadFactura = Nothing
            End If
            If Not (vFacturaConsultada Is Nothing) Then
                vFacturaConsultada = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
