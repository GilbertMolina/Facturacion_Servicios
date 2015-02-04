<%@ Page Title="Cambiar contraseña" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCCliente.Master"
    CodeBehind="cambiar_contrasena.aspx.vb" Inherits="CapaPresentacion.cambiar_contrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <div class="container">
        <br />
        <div class="row">
            <div class="col-xs-1 col-sm-2 col-md-3"></div>
		    <div class="col-xs-10 col-sm-8 col-md-6">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <fieldset>
                            <legend class="text-center">Cambiar su contraseña</legend>
                            <div class="col-xs-12">
                                <asp:Panel ID="pnErrorContraseñasFail" class="panel panel-default hidden" runat="server">
                                    <ul class="list-group text-center">
                                        <li class="list-group-item list-group-item-danger">
                                            <asp:Label ID="lbErrorContraseñasFail" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                </asp:Panel>
                                <asp:Panel ID="pnErrorContraseñasSuccess" class="panel panel-default hidden" runat="server">
                                    <ul class="list-group text-center">
                                        <li class="list-group-item list-group-item-success">
                                            <asp:Label ID="lbErrorContraseñasSuccess" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                </asp:Panel>
                            </div>
                            <form action="#" role="form" class="form-horizontal">
                            <div class="form-group">
                                <label for="txtContraseñaAnterior" class="control-label col-xs-6 text-right">Contraseña anterior:</label>
                                <div class="col-xs-6">
                                    <asp:TextBox ID="txtContraseñaAnterior" class="form-control" 
                                        placeholder="Contraseña anterior" runat="server" TextMode="Password" 
                                        MaxLength="30"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <label for="txtContraseñaNueva" class="control-label col-xs-6 text-right">Contraseña nueva:</label>
                                <div class="col-xs-6">
                                    <asp:TextBox ID="txtContraseñaNueva" class="form-control" 
                                        placeholder="Contraseña nueva" runat="server" TextMode="Password" 
                                        MaxLength="30"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <label for="txtContraseñaNuevaConfirmar" class="control-label col-xs-6 text-right">Confirmar contraseña nueva:</label>
                                <div class="col-xs-6">
                                    <asp:TextBox ID="txtContraseñaNuevaConfirmar" class="form-control" 
                                        placeholder="Confirmar contraseña nueva" runat="server" TextMode="Password" 
                                        MaxLength="30"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-6"></div>
                                <div class="col-xs-6 text-right">
                                    <asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
                                    <asp:Button ID="btnRecordar" class="btn btn-success" runat="server" Text="Cambiar" />&nbsp;&nbsp;&nbsp;&nbsp;
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
