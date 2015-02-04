Imports System.Data.SqlClient
Imports Objetos

Public Class cadFactura

#Region "Métodos de matenimiento"
    Public Function consultarFacturas(ByVal pTipoFactura As Integer) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_Mostrar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@TipoFactura", pTipoFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vDataSet)
            Return vDataSet
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataSet
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            If Not (vConn.DataAdapter Is Nothing) Then
                vConn.DataAdapter.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Function

    Public Function consultarFacturaNumeroSiguiente() As Integer
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Dim vNumeroFacturaRetornado As String = ""
        Dim vNumeroFacturaSiguiente As Integer
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_NumeroFacturaSiguiente", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vDataSet)
            For Each dr As DataRow In vDataSet.Tables(0).Rows
                vNumeroFacturaRetornado = dr("NumeroFacturaSiguiente").ToString
            Next
            If String.IsNullOrEmpty(vNumeroFacturaRetornado) Then
                vNumeroFacturaSiguiente = 1
            Else
                vNumeroFacturaSiguiente = vNumeroFacturaRetornado
            End If
            Return vNumeroFacturaSiguiente
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vNumeroFacturaSiguiente
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            If Not (vConn.DataAdapter Is Nothing) Then
                vConn.DataAdapter.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Function


    Public Function consultarFacturaMontoTotal(ByVal pIdFactura As Integer) As Double
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Dim vMontoTotalFacturaRetornado As String = ""
        Dim vMontoTotalFactura As Integer
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_TotalFactura", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pIdFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vDataSet)
            For Each dr As DataRow In vDataSet.Tables(0).Rows
                vMontoTotalFacturaRetornado = dr("Total Factura").ToString
            Next
            If String.IsNullOrEmpty(vMontoTotalFacturaRetornado) Then
                vMontoTotalFactura = 0
            Else
                vMontoTotalFactura = vMontoTotalFacturaRetornado
            End If
            Return vMontoTotalFactura
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vMontoTotalFactura
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            If Not (vConn.DataAdapter Is Nothing) Then
                vConn.DataAdapter.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Function

    Public Function consultarFacturasFiltros(ByVal pIdFactura As Integer, ByVal pNombreCliente As String) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_MostrarFiltrado", vConn.Conexion)
            vConn.Comando.CommandTimeout = 600
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pIdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@NombreCompleto", pNombreCliente))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vDataSet)
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vDataSet Is Nothing) Then
                vDataSet.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
        Return vDataSet
    End Function

    Public Function consultarFacturasReportes(ByVal pPersona As Persona, ByVal FechIni As Date, ByVal FechFin As Date) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_Reporte_Facturas", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pPersona.Cedula))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaIni", FechIni))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaIni", FechFin))

            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vDataset)
            Return vDataset
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            Return vDataset
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            If Not (vConn.DataAdapter Is Nothing) Then
                vConn.DataAdapter.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Function

    Public Function consultarFacturaBusquedaMantenimiento(ByVal pFactura As Factura) As Factura
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vFactura As New Factura
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_Busqueda_Mantenimiento", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pFactura.IdFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vFactura.IdFactura = CInt(dr("PK_IdFactura").ToString)
                    vFactura.Correo = dr("FK_Correo").ToString
                    vFactura.FechaEmision = CDate(dr("FechaEmision").ToString)
                    If dr("FechaVencimiento").ToString <> "" Then
                        vFactura.FechaVencimiento = CDate(dr("FechaVencimiento").ToString)
                    End If
                    vFactura.MontoTotal = CDbl(dr("MontoTotal").ToString)
                    vFactura.MontoCancelado = CDbl(dr("MontoCancelado").ToString)
                    vFactura.SaldoActual = CDbl(dr("SaldoActual").ToString)
                    vFactura.IdEstado = CInt(dr("FK_IdEstado").ToString)
                Next
            Else
                vFactura.IdFactura = -1
            End If
            Return vFactura
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vFactura.IdFactura = -1
            Return vFactura
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            If Not (vTable Is Nothing) Then
                vTable.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Function

    Public Sub insertarFactura(ByVal pFactura As Factura, ByVal pFecha As Integer)   '0: Sin Fecha, 1: Con fecha
        Dim vConn As New ConexionSQL
        Try
            If pFecha = 1 Then
                vConn.Comando = New SqlCommand("SP_TbFactura_InsertarConFechaVencimiento", vConn.Conexion)
            ElseIf pFecha = 0 Then
                vConn.Comando = New SqlCommand("SP_TbFactura_InsertarSinFechaVencimiento", vConn.Conexion)
            End If
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_Correo", pFactura.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaEmision", pFactura.FechaEmision))
            If pFecha = 1 Then
                vConn.Comando.Parameters.Add(New SqlParameter("@FechaVencimiento", pFactura.FechaVencimiento))
            End If
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoTotal", pFactura.MontoTotal))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoCancelado", pFactura.MontoCancelado))
            vConn.Comando.Parameters.Add(New SqlParameter("@SaldoActual", pFactura.SaldoActual))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pFactura.IdEstado))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.Comando.ExecuteReader()
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Sub

    Public Sub actualizarFactura(ByVal pFactura As Factura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pFactura.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_Correo", pFactura.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaEmision", pFactura.FechaEmision))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaVencimiento", pFactura.FechaVencimiento))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoTotal", pFactura.MontoTotal))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoCancelado", pFactura.MontoCancelado))
            vConn.Comando.Parameters.Add(New SqlParameter("@SaldoActual", pFactura.SaldoActual))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pFactura.IdEstado))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.Comando.ExecuteReader()
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Sub

    Public Sub actualizarFacturaMontoTotal(ByVal pFactura As Factura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_ActualizarMontoTotal", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pFactura.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoTotal", pFactura.MontoTotal))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.Comando.ExecuteReader()
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Sub

    Public Sub imprimirFactura(ByVal pFactura As Factura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_Imprimir", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pFactura.IdFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.Comando.ExecuteReader()
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Sub

    Public Sub anularFactura(ByVal pFactura As Factura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbFactura_Anular", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pFactura.IdFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.Comando.ExecuteReader()
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vConn.Comando Is Nothing) Then
                vConn.Comando.Dispose()
            End If
            vConn.CerrarConexion()
        End Try
    End Sub
#End Region

End Class
