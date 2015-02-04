﻿<%@ Page Title="Lista de Recibos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCAdmin.Master" CodeBehind="listadoRecibos.aspx.vb" Inherits="CapaPresentacion.listadoRecibos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <div class="container">
	<br />
	<div class="row">
		<div class="col-xs-12">
			<div class="panel panel-default">
				<div class="panel-body">
					<fieldset>
						<legend class="text-center">Lista de Recibos</legend>
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
                                        <asp:TextBox ID="txtIdRecibo" CssClass="form-control col-xs-3 col-sm-4 col-md-5" runat="server" placeholder="B&uacute;squeda por n&uacute;mero de recibo"></asp:TextBox>
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
					    <div class="row">
						    <div class="col-xs-12 text-right">
							    <asp:ImageButton ID="imgbtnAgregar" runat="server" ImageUrl="~/includes/images/ico-agregar.png" ToolTip="Agregar un nuevo usuario" />
						    </div>
					    </div>
                        <asp:UpdatePanel ID="updatePanelListaRecibos" runat="server">
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
								            <asp:GridView ID="grdListaRecibos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" AllowPaging="True" PageSize="5">
								            <AlternatingRowStyle BackColor="#E6E6E6" />
								            <Columns>
									            <asp:ButtonField CommandName="Eliminar" Text="&lt;img alt=&quot;Eliminar&quot; src=&quot;../includes/images/ico-eliminar.png&quot; /&gt;" >
									                <HeaderStyle CssClass="headerText-table" />
								                </asp:ButtonField>
									            <asp:ButtonField CommandName="Modificar" Text="&lt;img alt=&quot;Modificarr&quot; src=&quot;../includes/images/ico-modificar.png&quot; /&gt;" >
									                <HeaderStyle CssClass="headerText-table" />
								                </asp:ButtonField>
							                    <asp:BoundField DataField="Id Recibo" HeaderText="Id Recibo" >
							                        <HeaderStyle CssClass="headerText-table" />
						                        </asp:BoundField>
					                            <asp:BoundField DataField="Fecha de Emisión" HeaderText="Fecha de Emisión" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
					                            <asp:BoundField DataField="Correo" HeaderText="Nombre Cliente" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
					                            <asp:BoundField DataField="Descripción" HeaderText="Descripción" >
					                                <HeaderStyle CssClass="headerText-table" />
				                                </asp:BoundField>
				                                <asp:BoundField DataField="Monto Total" HeaderText="Monto Total" >
				                                    <HeaderStyle CssClass="headerText-table" />
			                                    </asp:BoundField>
		                                        <asp:BoundField DataField="Id Estado" HeaderText="Estado" >
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
