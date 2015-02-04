Imports System.Data.SqlClient
Imports Objetos

Public Class cadImpuesto

#Region "Métodos de matenimiento"
    Public Function consultarImpuestos() As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataset As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbImpuesto_Mostrar", vConn.Conexion)
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

    Public Function consultarImpuestosFiltros(ByVal pDescripcion As String, ByVal pPorcentajeImpuesto As Double) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbImpuesto_MostrarFiltrado", vConn.Conexion)
            vConn.Comando.CommandTimeout = 600
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pDescripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@PorcentajeImpuesto", pPorcentajeImpuesto))
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

    Public Function consultarImpuestoBusquedaMantenimiento(ByVal pImpuesto As Impuesto) As Impuesto
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vImpuesto As New Impuesto
        Try
            vConn.Comando = New SqlCommand("SP_TbImpuesto_Buscar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdImpuesto", pImpuesto.IdImpuesto))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vImpuesto.IdImpuesto = CInt(dr("PK_IdImpuesto").ToString)
                    vImpuesto.Descripcion = dr("Descripcion").ToString
                    vImpuesto.PorcentajeImpuesto = dr("PorcentajeImpuesto").ToString
                Next
            Else
                vImpuesto.IdImpuesto = "-1"
            End If
            Return vImpuesto
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vImpuesto.IdImpuesto = "-1"
            Return vImpuesto
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

    Public Sub insertarImpuesto(ByVal pImpuesto As Impuesto)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbImpuesto_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pImpuesto.Descripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@PorcentajeImpuesto", pImpuesto.PorcentajeImpuesto))
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

    Public Sub actualizarImpuesto(ByVal pImpuesto As Impuesto)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbImpuesto_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdImpuesto", pImpuesto.IdImpuesto))
            vConn.Comando.Parameters.Add(New SqlParameter("@Descripcion", pImpuesto.Descripcion))
            vConn.Comando.Parameters.Add(New SqlParameter("@PorcentajeImpuesto", pImpuesto.PorcentajeImpuesto))
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

    Public Sub eliminarImpuesto(ByVal pImpuesto As Impuesto)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbImpuesto_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_IdImpuesto", pImpuesto.IdImpuesto))
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
