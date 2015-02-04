Imports System.Data.SqlClient
Imports Objetos

Public Class cadEstado

#Region "Métodos de matenimiento"
    Public Function consultarEstados() As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbEstado_Mostrar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
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

    Public Function consultarEstado(ByVal pEstado As Estado) As Estado
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vEstado As New Estado
        Try
            vConn.Comando = New SqlCommand("SP_TbEstado_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdEstado", pEstado.IdEstado))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vEstado.IdEstado = CInt(dr("PK_IdEstado").ToString)
                    vEstado.Descripcion = dr("Descripcion").ToString
                Next
            Else
                vEstado.IdEstado = -1
            End If
            Return vEstado
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vEstado.IdEstado = -1
            Return vEstado
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

    Public Sub insertarEstado(ByVal pEstado As Estado)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbEstado_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pEstado.Descripcion))
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

    Public Sub actualizarEstado(ByVal pEstado As Estado)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbEstado_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdEstado", pEstado.IdEstado))
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pEstado.Descripcion))
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

    Public Sub eliminarEstado(ByVal pEstado As Estado)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbEstado_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdEstado", pEstado.IdEstado))
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
