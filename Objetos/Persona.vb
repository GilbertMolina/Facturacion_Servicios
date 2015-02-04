Public Class Persona

#Region "Propiedades"
    Private _Correo As String
    Private _Cedula As String
    Private _Nombre As String
    Private _Apellido1 As String
    Private _Apellido2 As String
    Private _FechaNacimiento As Date
    Private _Direccion As String
    Private _Telefono As String
    Private _Sexo As String
    Private _Contrasena As String
    Private _IdRol As Integer
    Private _IdEstado As Integer
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
        End Set
    End Property
    Public Property Cedula As String
        Get
            Return _Cedula
        End Get
        Set(value As String)
            _Cedula = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property
    Public Property Apellido1 As String
        Get
            Return _Apellido1
        End Get
        Set(value As String)
            _Apellido1 = value
        End Set
    End Property
    Public Property Apellido2 As String
        Get
            Return _Apellido2
        End Get
        Set(value As String)
            _Apellido2 = value
        End Set
    End Property
    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            _FechaNacimiento = value
        End Set
    End Property
    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property
    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property
    Public Property Sexo As String
        Get
            Return _Sexo
        End Get
        Set(value As String)
            _Sexo = value
        End Set
    End Property
    Public Property Contrasena As String
        Get
            Return _Contrasena
        End Get
        Set(value As String)
            _Contrasena = value
        End Set
    End Property
    Public Property IdRol As Integer
        Get
            Return _IdRol
        End Get
        Set(value As Integer)
            _IdRol = value
        End Set
    End Property
    Public Property IdEstado As Integer
        Get
            Return _IdEstado
        End Get
        Set(value As Integer)
            _IdEstado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
    Public Sub New(ByVal pCorreo As String, ByVal pCedula As String, ByVal pNombre As String, ByVal pApellido1 As String, _
                   ByVal pApellido2 As String, ByVal pFechaNacimiento As Date, ByVal pDireccion As String, ByVal pTelefono As String, _
                   ByVal pSexo As String, ByVal pContrasena As String, ByVal pIdRol As Integer, ByVal pIdEstado As Integer)
        Me.Correo = pCorreo
        Me.Cedula = pCedula
        Me.Nombre = pNombre
        Me.Apellido1 = pApellido1
        Me.Apellido2 = pApellido2
        Me.FechaNacimiento = pFechaNacimiento
        Me.Direccion = pDireccion
        Me.Telefono = pTelefono
        Me.Sexo = pSexo
        Me.Contrasena = pContrasena
        Me.IdRol = pIdRol
        Me.IdEstado = pIdEstado
    End Sub
#End Region

End Class
