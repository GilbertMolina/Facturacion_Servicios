Imports System.Data.SqlClient
Imports Objetos

Public Class cadRecibo

#Region "Métodos de matenimiento"
    Public Function consultarRecibos() As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbRecibo_Mostrar", vConn.Conexion)
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

    Public Function consultarReciboBusquedaMantenimiento(ByVal pRecibo As Recibo) As Recibo
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vRecibo As New Recibo
        Try
            vConn.Comando = New SqlCommand("SP_TbRecibo_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pRecibo.IdRecibo))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vRecibo.IdRecibo = CInt(dr("PK_IdRecibo").ToString)
                    vRecibo.FechaEmision = dr("FechaEmision").ToString
                    vRecibo.Correo = dr("FK_Correo").ToString
                    vRecibo.Descripcion = dr("Descripcion").ToString
                    vRecibo.MontoTotal = dr("MontoTotal").ToString
                    vRecibo.IdEstado = dr("FK_IdEstado").ToString
                Next
            Else
                vRecibo.IdRecibo = "-1"
            End If
            Return vRecibo
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vRecibo.IdRecibo = "-1"
            Return vRecibo
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

    Public Function consultarReciboID(ByVal pRecibo As Recibo) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Dim vRecibo As New Recibo
        Try
            vConn.Comando = New SqlCommand("SP_TbRecibo_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pRecibo.IdRecibo))
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

    Public Sub insertarRecibo(ByVal pRecibo As Recibo)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbRecibo_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pRecibo.IdRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaEmision", pRecibo.FechaEmision))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_Correo", pRecibo.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pRecibo.Descripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoTotal", pRecibo.MontoTotal))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pRecibo.IdEstado))
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

    Public Sub actualizarRecibo(ByVal pRecibo As Recibo)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbRecibo_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pRecibo.IdRecibo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaEmision", pRecibo.FechaEmision))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_Correo", pRecibo.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pRecibo.Descripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@MontoTotal", pRecibo.MontoTotal))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pRecibo.IdEstado))
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

    Public Sub eliminarRecibo(ByVal pRecibo As Recibo)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbRecibo_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdRecibo", pRecibo.IdRecibo))
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
