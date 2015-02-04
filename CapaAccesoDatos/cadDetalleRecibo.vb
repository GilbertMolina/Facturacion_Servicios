Imports System.Data.SqlClient
Imports Objetos

Public Class cadDetalleRecibo

#Region "Métodos de matenimiento"
    Public Function consultarDetallesRecibo(ByVal pIdRecibo As Integer) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleRecibo_Mostrar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", CInt(pIdRecibo)))
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

    Public Function consultarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo) As DetalleRecibo
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vDetalleRecibo As New DetalleRecibo
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleRecibo_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pDetalleRecibo.IdRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdDetalleRecibo", pDetalleRecibo.IdDetalleRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdFactura", pDetalleRecibo.IdFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vDetalleRecibo.IdRecibo = CInt(dr("PK_IdRecibo").ToString)
                    vDetalleRecibo.IdDetalleRecibo = CInt(dr("PK_IdDetalleRecibo").ToString)
                    vDetalleRecibo.IdFactura = CInt(dr("FK_IdFactura").ToString)
                    vDetalleRecibo.MontoCancelado = CDbl(dr("MontoCancelado").ToString)
                Next
            Else
                vDetalleRecibo.IdDetalleRecibo = -1
            End If
            Return vDetalleRecibo
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vDetalleRecibo.IdDetalleRecibo = -1
            Return vDetalleRecibo
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

    Public Sub insertarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleRecibo_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pDetalleRecibo.IdRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdFactura", pDetalleRecibo.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoCancelado", pDetalleRecibo.MontoCancelado))
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

    Public Sub actualizarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleRecibo_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pDetalleRecibo.IdRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdDetalleRecibo", pDetalleRecibo.IdDetalleRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdFactura", pDetalleRecibo.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoCancelado", pDetalleRecibo.MontoCancelado))
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

    Public Sub eliminarDetalleRecibo(ByVal pDetalleRecibo As DetalleRecibo)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleRecibo_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pDetalleRecibo.IdRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdDetalleRecibo", pDetalleRecibo.IdDetalleRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdFactura", pDetalleRecibo.IdFactura))
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
