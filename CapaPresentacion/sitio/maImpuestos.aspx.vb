Public Class maImpuestos
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Private _Transaccion As String
    Private _IdImpuesto As Integer
#End Region

#Region "Métodos de acceso a las propiedades"
    Public Property Transaccion As String
        Get
            Return ViewState("Transaccion")
        End Get
        Set(value As String)
            ViewState("Transaccion") = value
        End Set
    End Property

    Public Property IdImpuesto As Integer
        Get
            Return ViewState("IdImpuesto")
        End Get
        Set(value As Integer)
            ViewState("IdImpuesto") = value
        End Set
    End Property
#End Region

#Region "Metodos de la pagina"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarVariablesSession()
            evaluarAccion()
            deshabilitarBotones()
        End If
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub btnAccion_Click(sender As Object, e As System.EventArgs) Handles btnAccion.Click
        ejecutarAccion()
    End Sub

    Protected Sub limpiarCampos()
        txtDescripcion.Text = ""
        txtPorcentajeImpuesto.Text = ""
    End Sub

    Protected Sub cargarVariablesSession()
        Transaccion = Session("vTransaccion")
        IdImpuesto = Session("vIdImpuesto")
        'Despues de tomarlas de las variables de session se remueven para no acumular variables en session
        Session.Remove("vTransaccion")
        Session.Remove("vIdImpuesto")
    End Sub

    Protected Sub evaluarAccion()
        Select Case Transaccion
            Case "A"
                btnAccion.Text = "Registrar"
                btnAccion.CssClass = "btn btn-success"
            Case "M"
                btnAccion.Text = "Modificar"
                btnAccion.CssClass = "btn btn-warning"
                cargarImpuestoPorID()
            Case "E"
                btnAccion.Text = "Eliminar"
                btnAccion.CssClass = "btn btn-danger"
                cargarImpuestoPorID()
        End Select
    End Sub

    Protected Sub deshabilitarBotones()
        Select Case Transaccion
            Case "E"
                txtDescripcion.Enabled = False
                txtDescripcion.CssClass = "form-control"
                txtPorcentajeImpuesto.Enabled = False
                txtPorcentajeImpuesto.CssClass = "form-control"
                btnLimpiar.Enabled = False
                btnLimpiar.CssClass = "btn btn-primary"
        End Select
    End Sub

    Protected Sub cargarImpuestoPorID()
        Dim vImpuesto As New wsImpuesto.Impuesto
        Dim vGestor As New wsImpuesto.wsTbImpuesto
        Dim metodosUtiles As New utiles
        Try
            vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
            vGestor.Timeout = -1

            vImpuesto.IdImpuesto = IdImpuesto

            vImpuesto = vGestor.TbImpuestoConsultarImpuestoBusquedaMantenimiento(vImpuesto)

            txtDescripcion.Text = vImpuesto.Descripcion
            txtPorcentajeImpuesto.Text = vImpuesto.PorcentajeImpuesto
        Catch vExc As Exception
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = vExc.Message
        Finally
            If Not (vGestor Is Nothing) Then
                vGestor.Dispose()
            End If
            vImpuesto = Nothing
        End Try
    End Sub

    Protected Sub ejecutarAccion()
        Dim vImpuesto As New wsImpuesto.Impuesto
        Dim vGestor As New wsImpuesto.wsTbImpuesto
        Dim vResultado As String = ""

        If validarCamposLLenos() Then
            Try
                vImpuesto.IdImpuesto = IdImpuesto
                vImpuesto.Descripcion = txtDescripcion.Text.Trim
                vImpuesto.PorcentajeImpuesto = txtPorcentajeImpuesto.Text.Trim

                vGestor.Credentials = System.Net.CredentialCache.DefaultCredentials
                vGestor.Timeout = -1

                Select Case Transaccion
                    Case "A"
                        vResultado = vGestor.TbImpuestoInsertarImpuesto(vImpuesto)
                    Case "M"
                        vResultado = vGestor.TbImpuestoActualizarImpuesto(vImpuesto)
                    Case "E"
                        vResultado = vGestor.TbIMpuestoEliminarImpuesto(vImpuesto)
                End Select

                If vResultado = "" Then
                    Response.Redirect("listadoImpuestos.aspx", False)
                Else
                    pnErrorInicioSesion.CssClass = "panel panel-default"
                    lbErrorInicioSesion.Text = vResultado
                End If

            Catch vExc As Exception
                pnErrorInicioSesion.CssClass = "panel panel-default"
                lbErrorInicioSesion.Text = vExc.Message
            End Try
        Else
            pnErrorInicioSesion.CssClass = "panel panel-default"
            lbErrorInicioSesion.Text = "Debe de digitar todos los campos del formulario."
        End If
    End Sub

    Protected Function validarCamposLLenos()
        Dim vResultado As Boolean = False
        If txtDescripcion.Text <> "" And txtPorcentajeImpuesto.Text <> "" Then
            vResultado = True
        Else
            vResultado = False
        End If
        Return vResultado
    End Function

    Protected Sub maImpuestos_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        Dim metodosUtiles As New utiles
        If metodosUtiles.variablesSessionVacias(Session("vCorreoElectronico"), Session("vCedula"), Session("vNombreUsuario"), Session("vPrimerApellido"), Session("vSegundoApellido"), Session("vIdRol"), Session("vIdEstado")) Then
            Response.Redirect("default.aspx")
        Else
            Me.MasterPageFile = metodosUtiles.AsignacionMasterPage(Session("vIdRol"))
        End If
    End Sub
#End Region

End Class