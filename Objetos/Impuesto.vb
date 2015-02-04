Public Class Impuesto

#Region "Propiedades"
    Private _IdImpuesto As Integer
    Private _Descripcion As String
    Private _PorcentajeImpuesto As Double
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property IdImpuesto As Integer
        Get
            Return _IdImpuesto
        End Get
        Set(value As Integer)
            _IdImpuesto = value
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
    Public Property PorcentajeImpuesto As Double
        Get
            Return _PorcentajeImpuesto
        End Get
        Set(value As Double)
            _PorcentajeImpuesto = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
    Public Sub New(ByVal pIdImpuesto As Integer, ByVal pDescripcion As String, ByVal pPorcentajeImpuesto As Double)
        Me.IdImpuesto = pIdImpuesto
        Me.Descripcion = pDescripcion
        Me.PorcentajeImpuesto = pPorcentajeImpuesto
    End Sub
#End Region

End Class
