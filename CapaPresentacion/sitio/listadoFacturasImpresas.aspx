<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCAdmin.Master" CodeBehind="listadoFacturasImpresas.aspx.vb" Inherits="CapaPresentacion.listadoFacturasImpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
<div class="container">
	<br />
	<div class="row">
		<div class="col-xs-12">
			<div class="panel panel-default">
				<div class="panel-body">
					<fieldset>
						<legend class="text-center">Lista de Facturas Impresas</legend>
						<div class="col-xs-12">
                        <table class="table table-bordered table-condensed table-hover">
                            <thead>
                                <tr>
                                    <th colspan="3" class="text-center headerText-table">Filtro de b&uacute;squedas</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtIdFactura" CssClass="form-control col-xs-3 col-sm-4 col-md-5" runat="server" placeholder="B&uacute;squeda por n&uacute;mero de factura"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNombreCliente" CssClass="form-control col-xs-6 col-sm-6 col-md-6" runat="server" placeholder="B&uacute;squeda por nombre de cliente"></asp:TextBox>
                                    </td>
                                    <td class="col-xs-3 col-sm-2 col-md-1">
                                        &nbsp;&nbsp;<asp:ImageButton ID="imgbtnBuscar" runat="server" ImageUrl="~/includes/images/ico-buscar.png" ToolTip="Buscar por los filtros ingresados" />
                                        &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgbtnLimpiar" runat="server" ImageUrl="~/includes/images/ico-limpiar.png" ToolTip="Limpiar los filtros y volver a cargar la tabla" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
					    </div>
					    <br />
                        <asp:UpdatePanel ID="updatePanelListaFacturas" runat="server">
                            <ContentTemplate>
					            <div class="row">
						            <div class="col-xs-12">
                                        <asp:Panel ID="pnGridViewSinDatos" class="panel panel-default hidden" runat="server">
                                            <ul class="list-group text-center">
                                                <li class="list-group-item list-group-item-danger">
                                                    <h4><asp:Label ID="lbGridViewSinDatos" runat="server" Text=""></asp:Label></h4>
                                                </li>
                                            </ul>
                                       </asp:Panel>
							            <div class="table-responsive">
								            <asp:GridView ID="grdListaFacturas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" AllowPaging="True" PageSize="5">
								            <AlternatingRowStyle BackColor="#E6E6E6" />
								            <Columns>
							                    <asp:BoundField DataField="Id Factura" HeaderText="Id Factura" >
							                        <HeaderStyle CssClass="headerText-table" />
						                        </asp:BoundField>
						                        <asp:BoundField DataField="Nombre Cliente" HeaderText="Nombre Cliente" >
						                            <HeaderStyle CssClass="headerText-table" />
					                            </asp:BoundField>
					                            <asp:BoundField DataField="Fecha de Emisión" HeaderText="Fecha de Emisión" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
					                            <asp:BoundField DataField="Fecha de Vencimiento" HeaderText="Fecha de Vencimiento" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
				                                <asp:BoundField DataField="Monto Total" HeaderText="Monto Total" >
				                                    <HeaderStyle CssClass="headerText-table" />
			                                    </asp:BoundField>
				                                <asp:BoundField DataField="Monto Cancelado" HeaderText="Monto Cancelado" >
				                                    <HeaderStyle CssClass="headerText-table" />
			                                    </asp:BoundField>
			                                    <asp:BoundField DataField="Saldo Actual" HeaderText="Saldo Actual" >
			                                        <HeaderStyle CssClass="headerText-table" />
		                                        </asp:BoundField>
		                                        <asp:BoundField DataField="Estado" HeaderText="Estado" >
		                                            <HeaderStyle CssClass="headerText-table" />
	                                            </asp:BoundField>
                                            </Columns>
                                            <PagerStyle BackColor="Black" Font-Size="Smaller" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" Font-Italic="False" Font-Names="Arial" /></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
