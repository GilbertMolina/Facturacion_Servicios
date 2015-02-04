Imports CapaAccesoDatos
Imports Objetos

Public Class cnImpuesto

#Region "Variable de instancia"
    Dim vCadImpuesto As New cadImpuesto
#End Region

#Region "Métodos de matenimiento"
    Public Function consultarImpuestos() As DataSet
        Return vCadImpuesto.consultarImpuestos()
    End Function

    Public Function consultarImpuestosFiltros(ByVal pDescripcion As String, ByVal pPorcentajeImpuesto As Double) As DataSet
        Return vCadImpuesto.consultarImpuestosFiltros(pDescripcion, pPorcentajeImpuesto)
    End Function

    Public Function consultarImpuestoBusquedaMantenimiento(ByVal pImpuesto As Impuesto) As Impuesto
        Return vCadImpuesto.consultarImpuestoBusquedaMantenimiento(pImpuesto)
    End Function

    Public Function insertarImpuesto(ByVal pImpuesto As Impuesto) As String
        Dim vImpuestoConsultado As New Impuesto
        Dim vResultado As String = ""
        Try
            vImpuestoConsultado = pImpuesto
            vImpuestoConsultado = vCadImpuesto.consultarImpuestoBusquedaMantenimiento(vImpuestoConsultado)
            If vImpuestoConsultado.IdImpuesto = "-1" Then
                vCadImpuesto.insertarImpuesto(pImpuesto)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadImpuesto Is Nothing) Then
                vCadImpuesto = Nothing
            End If
            If Not (vImpuestoConsultado Is Nothing) Then
                vImpuestoConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function actualizarImpuesto(ByVal pImpuesto As Impuesto) As String
        Dim vImpuestoConsultado As New Impuesto
        Dim vResultado As String = ""
        Try
            vImpuestoConsultado = pImpuesto
            vImpuestoConsultado = vCadImpuesto.consultarImpuestoBusquedaMantenimiento(vImpuestoConsultado)
            If vImpuestoConsultado.IdImpuesto <> "-1" Then
                vCadImpuesto.actualizarImpuesto(pImpuesto)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadImpuesto Is Nothing) Then
                vCadImpuesto = Nothing
            End If
            If Not (vImpuestoConsultado Is Nothing) Then
                vImpuestoConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function

    Public Function eliminarImpuesto(ByVal pImpuesto As Impuesto) As String
        Dim vImpuestoConsultado As New Impuesto
        Dim vResultado As String = ""
        Try
            vImpuestoConsultado = pImpuesto
            vImpuestoConsultado = vCadImpuesto.consultarImpuestoBusquedaMantenimiento(vImpuestoConsultado)
            If vImpuestoConsultado.IdImpuesto <> "-1" Then
                vCadImpuesto.eliminarImpuesto(pImpuesto)
            Else
                vResultado = "-1"
            End If
        Catch vExc As Exception
            Throw New Exception(vExc.Message, vExc)
        Finally
            If Not (vCadImpuesto Is Nothing) Then
                vCadImpuesto = Nothing
            End If
            If Not (vImpuestoConsultado Is Nothing) Then
                vImpuestoConsultado = Nothing
            End If
        End Try
        Return vResultado
    End Function
#End Region

End Class
