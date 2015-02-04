Imports System.Data.SqlClient

Public Class ConexionSQL

#Region "Propiedades"
    Private _ConexionString As String
    Private _Comando As SqlCommand
    Private _Conexion As SqlConnection
    Private _DataAdapter As SqlDataAdapter
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property ConexionString As String
        Get
            Return _ConexionString
        End Get
        Set(value As String)
            _ConexionString = value
        End Set
    End Property
    Public Property Comando As SqlCommand
        Get
            Return _Comando
        End Get
        Set(value As SqlCommand)
            _Comando = value
        End Set
    End Property
    Public Property Conexion As SqlConnection
        Get
            Return _Conexion
        End Get
        Set(value As SqlConnection)
            _Conexion = value
        End Set
    End Property
    Public Property DataAdapter As SqlDataAdapter
        Get
            Return _DataAdapter
        End Get
        Set(value As SqlDataAdapter)
            _DataAdapter = value
        End Set
    End Property
#End Region

#Region "Métodos de establecer conexión"
    Public Sub AbrirConexion()
        Me.Conexion.Open()
    End Sub
    Public Sub CerrarConexion()
        Me.Conexion.Close()
    End Sub
#End Region

#Region "Constructores"
    Public Sub New()
        Me.DataAdapter = New SqlDataAdapter()
        Me.ConexionString = My.Settings.vConexionString.ToString
        Me.Conexion = New SqlConnection(Me.ConexionString)
    End Sub
#End Region

End Class
