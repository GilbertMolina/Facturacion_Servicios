Public Class Servicio

#Region "Propiedades"
    Private _IdServicio As Integer
    Private _Descripcion As String
    Private _PrecioUnitario As Double
    Private _IdImpuesto As Integer
    Private _IdEstado As Integer
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property IdServicio As Integer
        Get
            Return _IdServicio
        End Get
        Set(value As Integer)
            _IdServicio = value
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
    Public Property PrecioUnitario As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(value As Double)
            _PrecioUnitario = value
        End Set
    End Property
    Public Property IdImpuesto As Integer
        Get
            Return _IdImpuesto
        End Get
        Set(value As Integer)
            _IdImpuesto = value
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
    Public Sub New(ByVal pIdServicio As Integer, ByVal pDescripcion As String, ByVal pPrecioUnitario As Double, _
                   ByVal pIdImpuesto As Integer, ByVal pIdEstado As Integer)
        Me.IdServicio = pIdServicio
        Me.Descripcion = pDescripcion
        Me.PrecioUnitario = pPrecioUnitario
        Me.IdImpuesto = pIdImpuesto
        Me.IdEstado = pIdEstado
    End Sub
#End Region

End Class
