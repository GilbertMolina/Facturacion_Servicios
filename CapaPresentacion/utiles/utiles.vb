Imports System
Imports System.Web.UI

Public Class utiles

#Region "Métodos de lógica"
    Public Function AsignacionMasterPage(ByVal pRol As Integer) As String
        Dim MasterPage As String = "~/MasterPage/ServiciosABCCliente.Master"    'Por Default el usuario es de tipo Cliente por lo tanto se le asigna el MasterPage de Cliente
        Select Case pRol
            Case 1  'Super Admin
                MasterPage = "~/MasterPage/ServiciosABCSuperAdmin.Master"
            Case 2  'Admin
                MasterPage = "~/MasterPage/ServiciosABCAdmin.Master"
            Case 3  'Agente de cobros Registro Facturas
                MasterPage = "~/MasterPage/ServiciosABCAgenteFacturas.Master"
            Case 4  'Agente de cobros Registro Recibos
                MasterPage = "~/MasterPage/ServiciosABCAgenteRecibos.Master"
            Case 5  'Encargado Seguimiento Cobros
                MasterPage = "~/MasterPage/ServiciosABCEncargadoCobro.Master"
            Case 6  'Cliente
                MasterPage = "~/MasterPage/ServiciosABCCliente.Master"
        End Select
        Return MasterPage
    End Function

    Public Function validarEmailCorrecto(ByVal pEmailIngresado As String) As Boolean
        Dim vExpresionRegular = "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"
        If Regex.IsMatch(pEmailIngresado, vExpresionRegular) Then
            If Regex.Replace(pEmailIngresado, vExpresionRegular, String.Empty).Length = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function variablesSessionVacias(ByVal pCorreo As String, ByVal pCedula As String, ByVal pNombre As String, ByVal pPrimerApellido As String, ByVal pSegundoApellido As String, ByVal pRol As String, ByVal pEstado As String)
        Dim vResultado As Boolean = False
        If pCorreo = Nothing Or pCedula = Nothing Or pNombre = Nothing Or pPrimerApellido = Nothing Or pSegundoApellido = Nothing Or pRol = Nothing Or pEstado = Nothing Then
            vResultado = True
        End If
        Return vResultado
    End Function

    Public Function retornarFechaIngles(ByVal pFecha As String) As String    'Entrada: 20-08-2014 > Salida: 2014-08-20
        Dim dia As String = pFecha.Substring(0, 2)
        Dim mes As String = pFecha.Substring(3, 2)
        Dim anno As String = pFecha.Substring(6, 4)
        Return anno & "-" & mes & "-" & dia
    End Function

    Public Function retornarFechaEspanol(ByVal pFecha As String) As String   'Entrada: 2014-08-20 > Salida: 20-08-2014
        Dim anno As String = pFecha.Substring(0, 4)
        Dim mes As String = pFecha.Substring(5, 2)
        Dim dia As String = pFecha.Substring(8, 2)
        Return dia & "/" & mes & "/" & anno
    End Function

#End Region

End Class
