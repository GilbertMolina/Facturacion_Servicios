Public Class DetalleRecibo

#Region "Propiedades"
    Private _IdRecibo As Integer
    Private _IdDetalleRecibo As Integer
    Private _IdFactura As Integer
    Private _MontoCancelado As Double
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
    Public Property IdDetalleRecibo As Integer
        Get
            Return _IdDetalleRecibo
        End Get
        Set(value As Integer)
            _IdDetalleRecibo = value
        End Set
    End Property
    Public Property IdFactura As Integer
        Get
            Return _IdFactura
        End Get
        Set(value As Integer)
            _IdFactura = value
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
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
    Public Sub New(ByVal pIdRecibo As Integer, ByVal pIdDetalleRecibo As Integer, ByVal pIdFactura As Integer, ByVal pMontoCancelado As Double)
        Me.IdRecibo = pIdRecibo
        Me.IdDetalleRecibo = pIdDetalleRecibo
        Me.IdFactura = pIdFactura
        Me.MontoCancelado = pMontoCancelado
    End Sub
#End Region

End Class
