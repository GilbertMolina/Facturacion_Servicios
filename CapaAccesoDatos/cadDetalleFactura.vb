Imports System.Data.SqlClient
Imports Objetos

Public Class cadDetalleFactura

#Region "Métodos de matenimiento"
    Public Function consultarDetallesFactura(ByVal pIdFactura As Integer) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleFactura_Mostrar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", CInt(pIdFactura)))
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

    Public Function consultarDetalleFactura(ByVal pDetalleFactura As DetalleFactura) As DetalleFactura
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vDetalleFactura As New DetalleFactura
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleFactura_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pDetalleFactura.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdDetalleFactura", pDetalleFactura.IdDetalleFactura))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vDetalleFactura.IdDetalleFactura = CInt(dr("PK_IdDetalleFactura").ToString)
                    vDetalleFactura.IdFactura = CInt(dr("PK_IdFactura").ToString)
                    vDetalleFactura.IdServicio = CInt(dr("FK_IdServicio").ToString)
                    vDetalleFactura.PrecioUnitario = CDbl(dr("PrecioUnitario").ToString)
                    vDetalleFactura.Cantidad = CInt(dr("Cantidad").ToString)
                Next
            Else
                vDetalleFactura.IdDetalleFactura = -1
            End If
            Return vDetalleFactura
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vDetalleFactura.IdDetalleFactura = -1
            Return vDetalleFactura
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

    Public Sub insertarDetalleFactura(ByVal pDetalleFactura As DetalleFactura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleFactura_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pDetalleFactura.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdServicio", pDetalleFactura.IdServicio))
            vConn.Comando.Parameters.Add(New SqlParameter("@PrecioUnitario", pDetalleFactura.PrecioUnitario))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cantidad", pDetalleFactura.Cantidad))
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

    Public Sub actualizarDetalleFactura(ByVal pDetalleFactura As DetalleFactura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleFactura_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdDetalleFactura", pDetalleFactura.IdDetalleFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pDetalleFactura.IdFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdServicio", pDetalleFactura.IdServicio))
            vConn.Comando.Parameters.Add(New SqlParameter("@PrecioUnitario", pDetalleFactura.PrecioUnitario))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cantidad", pDetalleFactura.Cantidad))
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

    Public Sub eliminarDetalleFactura(ByVal pDetalleFactura As DetalleFactura)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbDetalleFactura_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdDetalleFactura", pDetalleFactura.IdDetalleFactura))
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdFactura", pDetalleFactura.IdFactura))
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
