﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.18444
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.18444.
'
Namespace wsRecibo
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="wsTbReciboSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class wsTbRecibo
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private TbReciboConsultarRecibosOperationCompleted As System.Threading.SendOrPostCallback
        
        Private consultarReciboBusquedaMantenimientoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TbReciboConsultarReciboIDOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TbReciboInsertarReciboOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TbReciboActualizarReciboOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TbReciboEliminarReciboOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.CapaPresentacion.My.MySettings.Default.CapaPresentacion_wsRecibo_wsTbRecibo
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event TbReciboConsultarRecibosCompleted As TbReciboConsultarRecibosCompletedEventHandler
        
        '''<remarks/>
        Public Event consultarReciboBusquedaMantenimientoCompleted As consultarReciboBusquedaMantenimientoCompletedEventHandler
        
        '''<remarks/>
        Public Event TbReciboConsultarReciboIDCompleted As TbReciboConsultarReciboIDCompletedEventHandler
        
        '''<remarks/>
        Public Event TbReciboInsertarReciboCompleted As TbReciboInsertarReciboCompletedEventHandler
        
        '''<remarks/>
        Public Event TbReciboActualizarReciboCompleted As TbReciboActualizarReciboCompletedEventHandler
        
        '''<remarks/>
        Public Event TbReciboEliminarReciboCompleted As TbReciboEliminarReciboCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TbReciboConsultarRecibos", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TbReciboConsultarRecibos() As System.Data.DataSet
            Dim results() As Object = Me.Invoke("TbReciboConsultarRecibos", New Object(-1) {})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TbReciboConsultarRecibosAsync()
            Me.TbReciboConsultarRecibosAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TbReciboConsultarRecibosAsync(ByVal userState As Object)
            If (Me.TbReciboConsultarRecibosOperationCompleted Is Nothing) Then
                Me.TbReciboConsultarRecibosOperationCompleted = AddressOf Me.OnTbReciboConsultarRecibosOperationCompleted
            End If
            Me.InvokeAsync("TbReciboConsultarRecibos", New Object(-1) {}, Me.TbReciboConsultarRecibosOperationCompleted, userState)
        End Sub
        
        Private Sub OnTbReciboConsultarRecibosOperationCompleted(ByVal arg As Object)
            If (Not (Me.TbReciboConsultarRecibosCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TbReciboConsultarRecibosCompleted(Me, New TbReciboConsultarRecibosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/consultarReciboBusquedaMantenimiento", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function consultarReciboBusquedaMantenimiento(ByVal pRecibo As Recibo) As Recibo
            Dim results() As Object = Me.Invoke("consultarReciboBusquedaMantenimiento", New Object() {pRecibo})
            Return CType(results(0),Recibo)
        End Function
        
        '''<remarks/>
        Public Overloads Sub consultarReciboBusquedaMantenimientoAsync(ByVal pRecibo As Recibo)
            Me.consultarReciboBusquedaMantenimientoAsync(pRecibo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub consultarReciboBusquedaMantenimientoAsync(ByVal pRecibo As Recibo, ByVal userState As Object)
            If (Me.consultarReciboBusquedaMantenimientoOperationCompleted Is Nothing) Then
                Me.consultarReciboBusquedaMantenimientoOperationCompleted = AddressOf Me.OnconsultarReciboBusquedaMantenimientoOperationCompleted
            End If
            Me.InvokeAsync("consultarReciboBusquedaMantenimiento", New Object() {pRecibo}, Me.consultarReciboBusquedaMantenimientoOperationCompleted, userState)
        End Sub
        
        Private Sub OnconsultarReciboBusquedaMantenimientoOperationCompleted(ByVal arg As Object)
            If (Not (Me.consultarReciboBusquedaMantenimientoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent consultarReciboBusquedaMantenimientoCompleted(Me, New consultarReciboBusquedaMantenimientoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TbReciboConsultarReciboID", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TbReciboConsultarReciboID(ByVal pRecibo As Recibo) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("TbReciboConsultarReciboID", New Object() {pRecibo})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TbReciboConsultarReciboIDAsync(ByVal pRecibo As Recibo)
            Me.TbReciboConsultarReciboIDAsync(pRecibo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TbReciboConsultarReciboIDAsync(ByVal pRecibo As Recibo, ByVal userState As Object)
            If (Me.TbReciboConsultarReciboIDOperationCompleted Is Nothing) Then
                Me.TbReciboConsultarReciboIDOperationCompleted = AddressOf Me.OnTbReciboConsultarReciboIDOperationCompleted
            End If
            Me.InvokeAsync("TbReciboConsultarReciboID", New Object() {pRecibo}, Me.TbReciboConsultarReciboIDOperationCompleted, userState)
        End Sub
        
        Private Sub OnTbReciboConsultarReciboIDOperationCompleted(ByVal arg As Object)
            If (Not (Me.TbReciboConsultarReciboIDCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TbReciboConsultarReciboIDCompleted(Me, New TbReciboConsultarReciboIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TbReciboInsertarRecibo", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TbReciboInsertarRecibo(ByVal pRecibo As Recibo) As String
            Dim results() As Object = Me.Invoke("TbReciboInsertarRecibo", New Object() {pRecibo})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TbReciboInsertarReciboAsync(ByVal pRecibo As Recibo)
            Me.TbReciboInsertarReciboAsync(pRecibo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TbReciboInsertarReciboAsync(ByVal pRecibo As Recibo, ByVal userState As Object)
            If (Me.TbReciboInsertarReciboOperationCompleted Is Nothing) Then
                Me.TbReciboInsertarReciboOperationCompleted = AddressOf Me.OnTbReciboInsertarReciboOperationCompleted
            End If
            Me.InvokeAsync("TbReciboInsertarRecibo", New Object() {pRecibo}, Me.TbReciboInsertarReciboOperationCompleted, userState)
        End Sub
        
        Private Sub OnTbReciboInsertarReciboOperationCompleted(ByVal arg As Object)
            If (Not (Me.TbReciboInsertarReciboCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TbReciboInsertarReciboCompleted(Me, New TbReciboInsertarReciboCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TbReciboActualizarRecibo", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TbReciboActualizarRecibo(ByVal pRecibo As Recibo) As String
            Dim results() As Object = Me.Invoke("TbReciboActualizarRecibo", New Object() {pRecibo})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TbReciboActualizarReciboAsync(ByVal pRecibo As Recibo)
            Me.TbReciboActualizarReciboAsync(pRecibo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TbReciboActualizarReciboAsync(ByVal pRecibo As Recibo, ByVal userState As Object)
            If (Me.TbReciboActualizarReciboOperationCompleted Is Nothing) Then
                Me.TbReciboActualizarReciboOperationCompleted = AddressOf Me.OnTbReciboActualizarReciboOperationCompleted
            End If
            Me.InvokeAsync("TbReciboActualizarRecibo", New Object() {pRecibo}, Me.TbReciboActualizarReciboOperationCompleted, userState)
        End Sub
        
        Private Sub OnTbReciboActualizarReciboOperationCompleted(ByVal arg As Object)
            If (Not (Me.TbReciboActualizarReciboCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TbReciboActualizarReciboCompleted(Me, New TbReciboActualizarReciboCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TbReciboEliminarRecibo", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TbReciboEliminarRecibo(ByVal pRecibo As Recibo) As String
            Dim results() As Object = Me.Invoke("TbReciboEliminarRecibo", New Object() {pRecibo})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TbReciboEliminarReciboAsync(ByVal pRecibo As Recibo)
            Me.TbReciboEliminarReciboAsync(pRecibo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TbReciboEliminarReciboAsync(ByVal pRecibo As Recibo, ByVal userState As Object)
            If (Me.TbReciboEliminarReciboOperationCompleted Is Nothing) Then
                Me.TbReciboEliminarReciboOperationCompleted = AddressOf Me.OnTbReciboEliminarReciboOperationCompleted
            End If
            Me.InvokeAsync("TbReciboEliminarRecibo", New Object() {pRecibo}, Me.TbReciboEliminarReciboOperationCompleted, userState)
        End Sub
        
        Private Sub OnTbReciboEliminarReciboOperationCompleted(ByVal arg As Object)
            If (Not (Me.TbReciboEliminarReciboCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TbReciboEliminarReciboCompleted(Me, New TbReciboEliminarReciboCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class Recibo
        
        Private idReciboField As Integer
        
        Private fechaEmisionField As Date
        
        Private correoField As String
        
        Private descripcionField As String
        
        Private montoTotalField As Double
        
        Private idEstadoField As Integer
        
        '''<comentarios/>
        Public Property IdRecibo() As Integer
            Get
                Return Me.idReciboField
            End Get
            Set
                Me.idReciboField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property FechaEmision() As Date
            Get
                Return Me.fechaEmisionField
            End Get
            Set
                Me.fechaEmisionField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Correo() As String
            Get
                Return Me.correoField
            End Get
            Set
                Me.correoField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Descripcion() As String
            Get
                Return Me.descripcionField
            End Get
            Set
                Me.descripcionField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property MontoTotal() As Double
            Get
                Return Me.montoTotalField
            End Get
            Set
                Me.montoTotalField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property IdEstado() As Integer
            Get
                Return Me.idEstadoField
            End Get
            Set
                Me.idEstadoField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")>  _
    Public Delegate Sub TbReciboConsultarRecibosCompletedEventHandler(ByVal sender As Object, ByVal e As TbReciboConsultarRecibosCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TbReciboConsultarRecibosCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")>  _
    Public Delegate Sub consultarReciboBusquedaMantenimientoCompletedEventHandler(ByVal sender As Object, ByVal e As consultarReciboBusquedaMantenimientoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class consultarReciboBusquedaMantenimientoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Recibo
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Recibo)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")>  _
    Public Delegate Sub TbReciboConsultarReciboIDCompletedEventHandler(ByVal sender As Object, ByVal e As TbReciboConsultarReciboIDCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TbReciboConsultarReciboIDCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")>  _
    Public Delegate Sub TbReciboInsertarReciboCompletedEventHandler(ByVal sender As Object, ByVal e As TbReciboInsertarReciboCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TbReciboInsertarReciboCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")>  _
    Public Delegate Sub TbReciboActualizarReciboCompletedEventHandler(ByVal sender As Object, ByVal e As TbReciboActualizarReciboCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TbReciboActualizarReciboCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")>  _
    Public Delegate Sub TbReciboEliminarReciboCompletedEventHandler(ByVal sender As Object, ByVal e As TbReciboEliminarReciboCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TbReciboEliminarReciboCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
