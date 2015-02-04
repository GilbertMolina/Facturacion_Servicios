Public Class Recibo

#Region "Propiedades"
    Private _IdRecibo As Integer
    Private _FechaEmision As Date
    Private _Correo As String
    Private _Descripcion As String
    Private _MontoTotal As Double
    Private _IdEstado As Integer
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property IdRecibo As Integer
        Get
            Return _IdRecibo
        End Get
        Set(value As Integer)
            _IdRecibo = value
        End Set
    End Property
    Public Property FechaEmision As Date
        Get
            Return _FechaEmision
        End Get
        Set(value As Date)
            _FechaEmision = value
        End Set
    End Property
    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
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
    Public Property MontoTotal As Double
        Get
            Return _MontoTotal
        End Get
        Set(value As Double)
            _MontoTotal = value
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
    Public Sub New(ByVal pIdRecibo As Integer, ByVal pFechaEmision As Date, ByVal pCorreo As String, _
                   ByVal pDescripcion As String, ByVal pMontoTotal As Double, ByVal pIdEstado As Integer)
        Me.IdRecibo = pIdRecibo
        Me.FechaEmision = pFechaEmision
        Me.Correo = pCorreo
        Me.Descripcion = pDescripcion
        Me.MontoTotal = pMontoTotal
        Me.IdEstado = pIdEstado
    End Sub
#End Region

End Class
