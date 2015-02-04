<%@ Page Title="Mantenimiento Facturas" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCAdmin.Master" CodeBehind="maFacturas.aspx.vb" Inherits="CapaPresentacion.maFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
<div class="container">
    <br />
	<div class="row">
		<div class="col-xs-12">
			<div class="panel panel-default">
				<div class="panel-body">
                    <asp:UpdatePanel ID="updatePanelFactura" runat="server">
                    <ContentTemplate>
                    <fieldset>
						<legend class="text-center">Factura</legend>
                            <div class="col-xs-12">                        
                                 <asp:Panel ID="pnErrorCargarFacturaSuccess" class="panel panel-default hidden" runat="server">
                                    <ul class="list-group text-center">
                                        <li class="list-group-item list-group-item-success">
                                            <asp:Label ID="lbErrorCargarFacturaSuccess" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                    </asp:Panel>
                                <asp:Panel ID="pnErrorCargarFactura" class="panel panel-default hidden" runat="server">
                                    <ul class="list-group text-center">
                                        <li class="list-group-item list-group-item-danger">
                                            <asp:Label ID="lbErrorCargarFactura" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                               </asp:Panel>
                            </div>
                                <form action="#" role="form" class="form-horizontal">
                                    <div class="row">
                                        <div class="col-xs-6 text-left">
                                            <div class="form-group">
                                                <label for="txtIdFactura" class="control-label col-xs-5 text-right">N&uacute;mero de factura:</label>
								                <div class="col-xs-7">
									                <div class="input-group">
										                <div class="input-group-addon">#</div>
                                                        <asp:TextBox ID="txtIdFactura" class="form-control" placeholder="N&uacute;mero de factura" runat="server" disabled></asp:TextBox>
									                </div>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-5 text-right">
                                            <div class="form-group">
                                                <label for="txtFechaEmision" class="control-label col-xs-5 text-right">Fecha de emisi&oacute;n:</label>
								                <div class="col-xs-7">
									                <asp:TextBox ID="txtFechaEmision" class="form-control text-center" placeholder="" runat="server" TextMode="Date" disabled></asp:TextBox>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-6 text-left">
                                            <div class="form-group">
                                                <label for="ddlNombreCliente" class="control-label col-xs-5 text-right">Nombre del cliente:</label>
								                <div class="col-xs-7">
									                <asp:DropDownList ID="ddlNombreCliente" class="form-control" runat="server"></asp:DropDownList>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-5 text-right">
                                            <div class="form-group">
                                                <label for="txtFechaVencimiento" class="control-label col-xs-5 text-right">Fecha de vencimiento:</label>
								                <div class="col-xs-7">
									                <asp:TextBox ID="txtFechaVencimiento" class="form-control text-center" placeholder="" runat="server" TextMode="Date"></asp:TextBox>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-6 text-left">
							                <div class="form-group">
								                <label for="ddlEstado" class="control-label col-xs-5 text-right">Estado:</label>
								                <div class="col-xs-7">
									                <asp:DropDownList ID="ddlEstado" class="form-control" runat="server"></asp:DropDownList>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-5 text-right">
                                            <div class="form-group">
                                                <label for="txtMontoTotalFactura" class="control-label col-xs-5 text-right">Monto total factura:</label>
								                <div class="col-xs-7">
									                <asp:TextBox ID="txtMontoTotalFactura" class="form-control text-center" placeholder="Monto total factura" runat="server">0</asp:TextBox>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-6"></div>                                        
                                        <div class="col-xs-5 text-right">
                                            <div class="form-group">
                                                <label for="txtMontoTotalPagado" class="control-label col-xs-5 text-right">Monto total pagado:</label>
								                <div class="col-xs-7">
									                <asp:TextBox ID="txtMontoTotalPagado" class="form-control text-center" placeholder="Monto total factura" runat="server">0</asp:TextBox>
									                <br />
								                </div>
							                </div>
                                        </div>
                                        <div class="col-xs-1"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-11 text-right">
                                            <asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
                                            <asp:Button ID="btnAccion" class="btn btn-default btnGrabarFactura" runat="server" Text="Accion" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                        <div class="col-xs-1"></div>
                                    </div>
                                </form>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="updatePanelListaDetalleFactura" runat="server">
                            <ContentTemplate>
                            <asp:Panel ID="pnDetalleFactura" class="panel panel-default hidden" runat="server">
                                <fieldset>
						            <legend class="text-center">Detalle Factura</legend>
                                </fieldset>
					            <div class="row">                        
						            <div class="col-xs-12">
                                    <table class="table table-bordered table-condensed table-hover">
                                        <thead>
                                            <tr>
                                                <th colspan="4" class="text-center headerText-table">Agregar nuevo servicio</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="col-xs-4">
                                                    <asp:DropDownList ID="ddlServicio" class="form-control col-xs-7 col-sm-7" runat="server"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCantidad" CssClass="form-control col-xs-2 col-sm-2" runat="server" TextMode="Number"></asp:TextBox>
                                                </td>
                                                <td class="col-xs-4">
                                                    <div class="row">
                                                        <div class="col-xs-10">
                                                            <asp:TextBox ID="txtMontoServicio" class="form-control" placeholder="Monto total del servicio" runat="server" disabled></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-2 text-left">
                                                            <asp:ImageButton ID="imgbtnActualizar" runat="server" ImageUrl="~/includes/images/ico-refrescar.png" ToolTip="Actualizar monto" />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="col-xs-1 col-sm-1">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgbtnAgregar" runat="server" ImageUrl="~/includes/images/ico-agregar.png" ToolTip="Agregar un nuevo servicio" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
					                </div>
					            </div>
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
								            <asp:GridView ID="grdListaDetalleFactura" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" AllowPaging="True" PageSize="5">
								            <AlternatingRowStyle BackColor="#E6E6E6" />
								            <Columns>
									            <asp:ButtonField CommandName="Eliminar" Text="&lt;img alt=&quot;Eliminar&quot; src=&quot;../includes/images/ico-eliminar.png&quot; /&gt;" >
									                <HeaderStyle CssClass="headerText-table" />
								                </asp:ButtonField>
					                            <asp:BoundField DataField="Id Factura" HeaderText="N&uacute;mero Factura" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
					                            <asp:BoundField DataField="Id Detalle" HeaderText="N&uacute;mero Detalle" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
					                            <asp:BoundField DataField="Servicio" HeaderText="Servicio" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
					                            <asp:BoundField DataField="Precio Unitario" HeaderText="Precio con Impuesto" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
						                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" >
						                            <HeaderStyle CssClass="headerText-table" />
					                            </asp:BoundField>
                                            </Columns>
                                            <PagerStyle BackColor="Black" Font-Size="Smaller" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" Font-Italic="False" Font-Names="Arial" /></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
					</fieldset>
                    <br />
                    <div class="row">
                        <div class="col-xs-12 text-left">
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hlRegresar" class="btn btn-back" runat="server" NavigateUrl="listadoFacturas.aspx">Regresar</asp:HyperLink>
                        </div>
                    </div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
