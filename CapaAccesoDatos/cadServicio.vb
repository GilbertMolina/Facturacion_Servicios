Imports System.Data.SqlClient
Imports Objetos

Public Class cadServicio

#Region "Métodos de matenimiento"
    Public Function consultarServicios() As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbServicio_Mostrar", vConn.Conexion)
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

    Public Function consultarServicio(ByVal pServicio As Servicio) As Servicio
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vServicio As New Servicio
        Try
            vConn.Comando = New SqlCommand("SP_TbServicio_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdServicio", pServicio.IdServicio))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vServicio.IdServicio = CInt(dr("PK_IdServicio").ToString)
                    vServicio.Descripcion = dr("Descripcion").ToString
                    vServicio.PrecioUnitario = CLng(dr("PrecioUnitario").ToString)
                    vServicio.IdImpuesto = CInt(dr("FK_IdImpuesto").ToString)
                    vServicio.IdEstado = CInt(dr("FK_IdEstado").ToString)
                Next
            Else
                vServicio.IdServicio = "-1"
            End If
            Return vServicio
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vServicio.IdServicio = "-1"
            Return vServicio
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

    Public Sub insertarServicio(ByVal pServicio As Servicio)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbServicio_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure            
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pServicio.Descripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@PrecioUnitario", pServicio.PrecioUnitario))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdImpuesto", pServicio.IdImpuesto))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pServicio.IdEstado))            
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

    Public Sub actualizarServicio(ByVal pServicio As Servicio)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbServicio_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdServicio", pServicio.IdServicio))
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pServicio.Descripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@PrecioUnitario", pServicio.PrecioUnitario))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdImpuesto", pServicio.IdImpuesto))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pServicio.IdEstado))
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

    Public Sub eliminarServicio(ByVal pServicio As Servicio)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbServicio_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdServicio", pServicio.IdServicio))
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

    Public Function consultarServiciosFiltros(ByVal pDescripcion As String, ByVal pPrecioUnitario As Double) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbServicio_MostrarFiltrado", vConn.Conexion)
            vConn.Comando.CommandTimeout = 600
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pDescripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@PrecioUnitario", pPrecioUnitario))
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


#End Region

End Class
