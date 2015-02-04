<%@ Page Title="Recordar contraseña" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCDefault.Master"
    CodeBehind="recordar_contrasena.aspx.vb" Inherits="CapaPresentacion.recordar_contrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-1 col-sm-2 col-md-3"></div>
		    <div class="col-xs-10 col-sm-8 col-md-6">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <fieldset>
                            <legend class="text-center">Recordar contraseña</legend>
                            <div class="col-xs-12">
                                <asp:Panel ID="pnErrorInicioSesionFail" class="panel panel-default hidden" runat="server">
                                    <ul class="list-group text-center">
                                        <li class="list-group-item list-group-item-danger">
                                            <asp:Label ID="lbErrorInicioSesionFail" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                </asp:Panel>
                                <asp:Panel ID="pnErrorInicioSesionSuccess" class="panel panel-default hidden" runat="server">
                                    <ul class="list-group text-center">
                                        <li class="list-group-item list-group-item-success">
                                            <asp:Label ID="lbErrorInicioSesionSuccess" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                </asp:Panel>
                            </div>
                            <form action="#" role="form" class="form-horizontal">
                                <div class="form-group">
                                    <label for="txtCorreo" class="control-label col-xs-5 text-right">Correo electr&oacute;nico:</label>
                                    <div class="col-xs-7">
                                        <div class="input-group">
                                            <div class="input-group-addon">@</div>
                                            <asp:TextBox ID="txtCorreo" class="form-control" placeholder="Correo electr&oacute;nico" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label for="txtCedula" class="control-label col-xs-5 text-right">C&eacute;dula:</label>
                                    <div class="col-xs-7">
                                        <asp:TextBox ID="txtCedula" class="form-control" placeholder="C&eacute;dula" runat="server"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="col-xs-2"></div>
                                            <div class="col-xs-8">
                                                <asp:HyperLink ID="hlRegresar" class="btn btn-back" runat="server" NavigateUrl="default.aspx">Regresar</asp:HyperLink>
                                            </div>
                                            <div class="col-xs-2"></div>
                                        </div>
                                    </div>
                                    <div class="col-xs-6 text-right">
                                        <asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
                                        <asp:Button ID="btnRecordar" class="btn btn-success" runat="server" Text="Recordar" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                </div>
                            </form>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="col-xs-1 col-sm-2 col-md-3"></div>
         </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
