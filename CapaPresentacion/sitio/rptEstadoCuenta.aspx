<%@ Page Title="Estados de Cuenta" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCCliente.Master" CodeBehind="rptEstadoCuenta.aspx.vb" Inherits="CapaPresentacion.rptEstadoCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <div class="container">
        <br />
        <div class="row">
            <div class="col-xs-12">
			    <div class="panel panel-default">
				    <div class="panel-body">
					    <fieldset>
						    <legend class="text-center">Reporte: Estados de Cuenta</legend>
						    <div class="col-xs-12 text-right">
                                <asp:ImageButton ID="imgbtnGenerarReporte" runat="server" ImageUrl="~/includes/images/ico-imprimir.png" ToolTip="Generar reporte" />
					        </div>
					        <br />
					        <div class="row">
						        <div class="col-xs-12 text-right">
							        <!-- Aqui va el reporte -->
						        </div>
					        </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
