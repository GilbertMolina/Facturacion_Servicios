Imports System.Data.SqlClient
Imports Objetos

Public Class cadPersona

#Region "Métodos de matenimiento"
    Public Function consultarPersonas() As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_Mostrar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
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

    Public Function consultarClientes() As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_MostrarClientes", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
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

    Public Function consultarPersonasFiltros(ByVal pCedula As String, ByVal pNombreCompleto As String) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_MostrarFiltrado", vConn.Conexion)
            vConn.Comando.CommandTimeout = 600
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pCedula))
            vConn.Comando.Parameters.Add(New SqlParameter("@NombreCompleto", pNombreCompleto))
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

    Public Function consultarClientesFiltros(ByVal pCedula As String, ByVal pNombreCompleto As String) As DataSet
        Dim vConn As New ConexionSQL
        Dim vDataSet As New DataSet
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_MostrarClientesFiltrado", vConn.Conexion)
            vConn.Comando.CommandTimeout = 600
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pCedula))
            vConn.Comando.Parameters.Add(New SqlParameter("@NombreCompleto", pNombreCompleto))
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

    Public Function consultarPersonaLogin(ByVal pPersona As Persona) As Persona
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vPersona As New Persona
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_Login", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Contrasena", pPersona.Contrasena))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vPersona.Correo = dr("PK_Correo").ToString.Trim
                    vPersona.Cedula = dr("Cedula").ToString.Trim
                    vPersona.Nombre = dr("Nombre").ToString.Trim
                    vPersona.Apellido1 = dr("Apellido1").ToString.Trim
                    vPersona.Apellido2 = dr("Apellido2").ToString.Trim
                    vPersona.FechaNacimiento = CDate(dr("FechaNacimiento").ToString.Trim)
                    vPersona.Direccion = dr("Direccion").ToString.Trim
                    vPersona.Telefono = dr("Telefono").ToString.Trim
                    vPersona.Sexo = dr("Sexo").ToString.Trim
                    vPersona.Contrasena = dr("Contrasena").ToString.Trim
                    vPersona.IdRol = CInt(dr("FK_IdRol").ToString.Trim)
                    vPersona.IdEstado = CInt(dr("FK_IdEstado").ToString.Trim)
                Next
            Else
                vPersona.Correo = "-1"
            End If
            Return vPersona
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vPersona.Correo = "-1"
            Return vPersona
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

    Public Function consultarPersonaBusquedaContraseña(ByVal pPersona As Persona) As Persona
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vPersona As New Persona
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_RecordarContrasena", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pPersona.Cedula))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vPersona.Correo = dr("PK_Correo").ToString.Trim
                    vPersona.Cedula = dr("Cedula").ToString.Trim
                    vPersona.Nombre = dr("Nombre").ToString.Trim
                    vPersona.Apellido1 = dr("Apellido1").ToString.Trim
                    vPersona.Apellido2 = dr("Apellido2").ToString.Trim
                    vPersona.FechaNacimiento = CDate(dr("FechaNacimiento").ToString.Trim)
                    vPersona.Direccion = dr("Direccion").ToString.Trim
                    vPersona.Telefono = dr("Telefono").ToString.Trim
                    vPersona.Sexo = dr("Sexo").ToString.Trim
                    vPersona.Contrasena = dr("Contrasena").ToString.Trim
                    vPersona.IdRol = CInt(dr("FK_IdRol").ToString.Trim)
                    vPersona.IdEstado = CInt(dr("FK_IdEstado").ToString.Trim)
                Next
            Else
                vPersona.Correo = "-1"
            End If
            Return vPersona
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vPersona.Correo = "-1"
            Return vPersona
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

    Public Function consultarPersonaMantenimiento(ByVal pPersona As Persona) As Persona
        Dim vConn As New ConexionSQL
        Dim vTable As New DataTable
        Dim vPersona As New Persona
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_Busqueda_Mantenimiento", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pPersona.Cedula))
            If vConn.Conexion.State = ConnectionState.Closed Then
                vConn.AbrirConexion()
            End If
            vConn.DataAdapter.SelectCommand = vConn.Comando
            vConn.DataAdapter.Fill(vTable)
            If vTable.Rows.Count > 0 Then
                For Each dr As DataRow In vTable.Rows
                    vPersona.Correo = dr("PK_Correo").ToString.Trim
                    vPersona.Cedula = dr("Cedula").ToString.Trim
                    vPersona.Nombre = dr("Nombre").ToString.Trim
                    vPersona.Apellido1 = dr("Apellido1").ToString.Trim
                    vPersona.Apellido2 = dr("Apellido2").ToString.Trim
                    vPersona.FechaNacimiento = CDate(dr("FechaNacimiento").ToString.Trim)
                    vPersona.Direccion = dr("Direccion").ToString.Trim
                    vPersona.Telefono = dr("Telefono").ToString.Trim
                    vPersona.Sexo = dr("Sexo").ToString.Trim
                    vPersona.Contrasena = dr("Contrasena").ToString.Trim
                    vPersona.IdRol = CInt(dr("FK_IdRol").ToString.Trim)
                    vPersona.IdEstado = CInt(dr("FK_IdEstado").ToString.Trim)
                Next
            Else
                vPersona.Correo = "-1"
            End If
            Return vPersona
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
            vPersona.Correo = "-1"
            Return vPersona
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

    Public Sub insertarPersona(ByVal pPersona As Persona)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_Insertar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pPersona.Cedula))
            vConn.Comando.Parameters.Add(New SqlParameter("@Nombre", pPersona.Nombre))
            vConn.Comando.Parameters.Add(New SqlParameter("@Apellido1", pPersona.Apellido1))
            vConn.Comando.Parameters.Add(New SqlParameter("@Apellido2", pPersona.Apellido2))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaNacimiento", pPersona.FechaNacimiento))
            vConn.Comando.Parameters.Add(New SqlParameter("@Direccion", pPersona.Direccion))
            vConn.Comando.Parameters.Add(New SqlParameter("@Telefono", pPersona.Telefono))
            vConn.Comando.Parameters.Add(New SqlParameter("@Sexo", pPersona.Sexo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Contrasena", pPersona.Contrasena))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdRol", pPersona.IdRol))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pPersona.IdEstado))
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

    Public Sub actualizarPersona(ByVal pPersona As Persona)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_Actualizar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pPersona.Cedula))
            vConn.Comando.Parameters.Add(New SqlParameter("@Nombre", pPersona.Nombre))
            vConn.Comando.Parameters.Add(New SqlParameter("@Apellido1", pPersona.Apellido1))
            vConn.Comando.Parameters.Add(New SqlParameter("@Apellido2", pPersona.Apellido2))
            vConn.Comando.Parameters.Add(New SqlParameter("@FechaNacimiento", pPersona.FechaNacimiento))
            vConn.Comando.Parameters.Add(New SqlParameter("@Direccion", pPersona.Direccion))
            vConn.Comando.Parameters.Add(New SqlParameter("@Telefono", pPersona.Telefono))
            vConn.Comando.Parameters.Add(New SqlParameter("@Sexo", pPersona.Sexo))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdRol", pPersona.IdRol))
            vConn.Comando.Parameters.Add(New SqlParameter("@FK_IdEstado", pPersona.IdEstado))
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

    Public Sub actualizarPersonaContraseña(ByVal pPersona As Persona)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_ActualizarContrasena", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Contrasena", pPersona.Contrasena))
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

    Public Sub eliminarPersona(ByVal pPersona As Persona)
        Dim vConn As New ConexionSQL
        Try
            vConn.Comando = New SqlCommand("SP_TbPersona_Eliminar", vConn.Conexion)
            vConn.Comando.CommandType = CommandType.StoredProcedure
            vConn.Comando.Parameters.Add(New SqlParameter("@PK_Correo", pPersona.Correo))
            vConn.Comando.Parameters.Add(New SqlParameter("@Cedula", pPersona.Cedula))
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
