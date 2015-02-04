Public Class DetalleFactura

#Region "Propiedades"
    Private _IdFactura As Integer
    Private _IdDetalleFactura As Integer
    Private _IdServicio As Integer
    Private _PrecioUnitario As Double
    Private _Cantidad As Integer
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
    Public Property IdDetalleFactura As Integer
        Get
            Return _IdDetalleFactura
        End Get
        Set(value As Integer)
            _IdDetalleFactura = value
        End Set
    End Property
    Public Property IdServicio As Integer
        Get
            Return _IdServicio
        End Get
        Set(value As Integer)
            _IdServicio = value
        End Set
    End Property
    Public Property PrecioUnitario As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(value As Double)
            _PrecioUnitario = value
        End Set
    End Property
    Public Property Cantidad As Integer
        Get
            Return _Cantidad
        End Get
        Set(value As Integer)
            _Cantidad = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
    Public Sub New(ByVal pIdFactura As Integer, ByVal pIdDetalleFactura As Integer, ByVal pIdServicio As Integer, ByVal pPrecioUnitario As Double, ByVal pCantidad As Integer)
        Me.IdFactura = pIdFactura
        Me.IdDetalleFactura = pIdDetalleFactura
        Me.IdServicio = pIdServicio
        Me.PrecioUnitario = pPrecioUnitario
        Me.Cantidad = pCantidad
    End Sub
#End Region

End Class
