<%@ Page Title="Mantenimiento Recibos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCAdmin.Master" CodeBehind="maRecibos.aspx.vb" Inherits="CapaPresentacion.maRecibos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <div class="container">
    <br />
    <div class="row">
		<div class="col-xs-12">
			<div class="panel panel-default">
				<div class="panel-body">
					<fieldset>
						<legend class="text-center">Recibo</legend>
                        <div class="col-xs-12">
                            <asp:Panel ID="pnErrorInicioSesion" class="panel panel-default hidden" runat="server">
                                <ul class="list-group text-center">
                                    <li class="list-group-item list-group-item-danger">
                                        <asp:Label ID="lbErrorInicioSesion" runat="server" Text=""></asp:Label>
                                    </li>
                                </ul>
                           </asp:Panel>
                        </div>
                        <form action="#" role="form" class="form-horizontal">
                            <div class="row">
                                <div class="col-xs-5 text-left">
                                    <div class="form-group">
                                        <label for="txtIdRecibo" class="control-label col-xs-6 text-right">N&uacute;mero de recibo:</label>
								        <div class="col-xs-6">
									        <div class="input-group">
										        <div class="input-group-addon">#</div>
                                                <asp:TextBox ID="txtIdRecibo" class="form-control" placeholder="N&uacute;mero de recibo" runat="server" disabled></asp:TextBox>
									        </div>
									        <br />
								        </div>
							        </div>
                                </div>
                                <div class="col-xs-1"></div>
                                <div class="col-xs-5 text-right">
                                    <div class="form-group">
                                        <label for="txtFechaEmision" class="control-label col-xs-6 text-right">Fecha de emisi&oacute;n:</label>
								        <div class="col-xs-6">
									        <asp:TextBox ID="txtFechaEmision" class="form-control text-center" placeholder="dd/mm/yyyy" runat="server" disabled></asp:TextBox>
									        <br />
								        </div>
							        </div>
                                </div>
                                <div class="col-xs-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5 text-left">
                                    <div class="form-group">
                                        <label for="ddlNombreCliente" class="control-label col-xs-6 text-right">Nombre del cliente:</label>
								        <div class="col-xs-6">
									        <asp:DropDownList ID="ddlNombreCliente" class="form-control" runat="server"></asp:DropDownList>
									        <br />
								        </div>
							        </div>
                                </div>
                                <div class="col-xs-1"></div>
                                <div class="col-xs-5 text-right">
                                    <div class="form-group">
                                        <label for="txtDescripcion" class="control-label col-xs-6 text-right">Descripción:</label>
								        <div class="col-xs-6">
									        <asp:TextBox ID="txtDescripcion" class="form-control text-center" placeholder="Descripción" runat="server" ></asp:TextBox>
									        <br />
								        </div>
							        </div>
                                </div>
                                <div class="col-xs-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5 text-left">
							        <div class="form-group">
								        <label for="ddlEstado" class="control-label col-xs-6 text-right">Estado:</label>
								        <div class="col-xs-6">
									        <asp:DropDownList ID="ddlEstado" class="form-control" runat="server"></asp:DropDownList>
									        <br />
								        </div>
							        </div>
                                </div>
                                <div class="col-xs-1"></div>
                                <div class="col-xs-5 text-right">
                                    <div class="form-group">
                                        <label for="txtMontoTotal" class="control-label col-xs-6 text-right">Monto total:</label>
								        <div class="col-xs-6">
									        <asp:TextBox ID="txtMontoTotal" class="form-control text-center" placeholder="Monto actual" runat="server" disabled></asp:TextBox>
									        <br />
								        </div>
							        </div>
                                </div>
                                <div class="col-xs-1"></div>
                           
                            <div class="row">
                                <div class="col-xs-11 text-right">
                                    <asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
                                    <asp:Button ID="btnAccion" class="btn btn-default btnGrabarFactura" runat="server" Text="Accion" />
                                </div>
                                <div class="col-xs-1"></div>
                            </div>
                        </form>
                        <br />
                        <fieldset>
						    <legend class="text-center">Detalle Recibo</legend>
                        </fieldset>
					    <div class="row">
						    <div class="col-xs-12 text-right">
							    <asp:ImageButton ID="imgbtnAgregar" runat="server" ImageUrl="~/includes/images/ico-agregar.png" ToolTip="Agregar un nuevo servicio" />&nbsp;&nbsp;&nbsp;&nbsp;
						    </div>
					    </div>
                        <asp:UpdatePanel ID="updatePanelListaDetalleRecibo" runat="server">
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
								            <asp:GridView ID="grdListaDetalleRecibo" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" AllowPaging="True" PageSize="5">
								            <AlternatingRowStyle BackColor="#E6E6E6" />
								            <Columns>
									            <asp:ButtonField CommandName="Eliminar" Text="&lt;img alt=&quot;Eliminar&quot; src=&quot;../includes/images/ico-eliminar.png&quot; /&gt;" >
									                <HeaderStyle CssClass="headerText-table" />
								                </asp:ButtonField>
							                    <asp:BoundField DataField="Id DetalleRecibo" HeaderText="Id DetalleRecibo" >
							                        <HeaderStyle CssClass="headerText-table" />
						                        </asp:BoundField>
						                        <asp:BoundField DataField="Id Factura" HeaderText="Id Factura" >
				                                    <HeaderStyle CssClass="headerText-table" />
			                                    </asp:BoundField>
			                                    <asp:BoundField DataField="Monto Cancelado" HeaderText="Monto Cancelado" >
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
                    <br />
                    <div class="row">
                        <div class="col-xs-6 text-left">
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hlRegresar" class="btn btn-back" runat="server" NavigateUrl="listadoRecibos.aspx">Regresar</asp:HyperLink>
                        </div>
                        <div class="col-xs-6 text-right">
                            <asp:Button ID="btnRegistrarRecibo" class="btn btn-success" runat="server" Text="Agregar detalle" />&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
