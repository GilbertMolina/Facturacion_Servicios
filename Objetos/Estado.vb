Public Class Estado

#Region "Propiedades"
    Private _IdEstado As Integer
    Private _Descripcion As String
#End Region

#Region "Metodos de acceso a las propiedades"
    Public Property IdEstado As Integer
        Get
            Return _IdEstado
        End Get
        Set(value As Integer)
            _IdEstado = value
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
    Public Sub New(ByVal pIdEstado As Integer, ByVal pDescripcion As String)
        Me.IdEstado = pIdEstado
        Me.Descripcion = pDescripcion
    End Sub
#End Region

End Class
