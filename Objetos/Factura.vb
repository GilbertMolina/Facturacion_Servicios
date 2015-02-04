Public Class Factura

#Region "Propiedades"
    Private _IdFactura As Integer
    Private _Correo As String
    Private _FechaEmision As Date
    Private _FechaVencimiento As Date
    Private _MontoTotal As Double
    Private _MontoCancelado As Double
    Private _SaldoActual As Double
    Private _IdEstado As Integer
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property IdFactura As Integer
        Get
            Return _IdFactura
        End Get
        Set(value As Integer)
            _IdFactura = value
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
    Public Property FechaEmision As Date
        Get
            Return _FechaEmision
        End Get
        Set(value As Date)
            _FechaEmision = value
        End Set
    End Property
    Public Property FechaVencimiento As Date
        Get
            Return _FechaVencimiento
        End Get
        Set(value As Date)
            _FechaVencimiento = value
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
    Public Property MontoCancelado As Double
        Get
            Return _MontoCancelado
        End Get
        Set(value As Double)
            _MontoCancelado = value
        End Set
    End Property
    Public Property SaldoActual As Double
        Get
            Return _SaldoActual
        End Get
        Set(value As Double)
            _SaldoActual = value
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
    Public Sub New(ByVal pIdFactura As Integer, ByVal pCorreo As String, ByVal pFechaEmision As Date, _
                   ByVal pFechaVencimiento As Date, ByVal pMontoTotal As Double, ByVal pMontoCancelado As Double, _
                   ByVal pSaldoActual As Double, ByVal pIdEstado As Integer)
        Me.IdFactura = pIdFactura
        Me.Correo = pCorreo
        Me.FechaEmision = pFechaEmision
        Me.FechaVencimiento = pFechaVencimiento
        Me.MontoTotal = pMontoTotal
        Me.MontoCancelado = pMontoCancelado
        Me.SaldoActual = pSaldoActual
        Me.IdEstado = pIdEstado
    End Sub
#End Region

End Class
