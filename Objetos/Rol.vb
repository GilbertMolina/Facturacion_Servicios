Public Class Rol

#Region "Propiedades"
    Private _IdRol As Integer
    Private _Descripcion As String
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property IdRol As Integer
        Get
            Return _IdRol
        End Get
        Set(value As Integer)
            _IdRol = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
    Public Sub New(ByVal pIdRol As Integer, ByVal pDescripcion As String)
        Me.IdRol = pIdRol
        Me.Descripcion = pDescripcion
    End Sub
#End Region

End Class
