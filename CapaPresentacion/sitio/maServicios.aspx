<%@ Page Title="Mantenimiento Servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCSuperAdmin.Master" CodeBehind="maServicios.aspx.vb" Inherits="CapaPresentacion.maServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
<div class="container">
    <br />
	<div class="row">
		<div class="col-xs-1 col-sm-1 col-md-3"></div>
		<div class="col-xs-9 col-sm-9 col-md-6">
			<div class="panel panel-default">
				<div class="panel-body">
					<fieldset>
						<legend class="text-center">Mantenimiento Servicios</legend>
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
							<div class="form-group">
                                <label for="txtDescripcion" class="control-label col-xs-5 text-right">Descripción:</label>
								<div class="col-xs-7">
									<asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Descripción servicio" runat="server"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtPrecioUnitario" class="control-label col-xs-5 text-right">Precio Unitario:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtPrecioUnitario" class="form-control" placeholder="Precio Unitario" runat="server"></asp:TextBox>
                                    <br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="ddlImpuesto" class="control-label col-xs-5 text-right">Impuesto asignado: </label>
								<div class="col-xs-7">
									<asp:DropDownList ID="ddlImpuesto" class="form-control" runat="server"></asp:DropDownList>
									<br />
								</div>
							</div>
							<div class="form-group">
								<label for="ddlEstado" class="control-label col-xs-5 text-right">Estado: </label>
								<div class="col-xs-7">
									<asp:DropDownList ID="ddlEstado" class="form-control" runat="server"></asp:DropDownList>
									<br />
								</div>
							</div>
							<br />
							<div class="row">	
								<div class="col-xs-6">
									<div class="row">
										<div class="col-xs-2"></div>
										<div class="col-xs-8">
                                            <asp:HyperLink ID="hlRegresar" class="btn btn-back" runat="server" NavigateUrl="listadoServicios.aspx">Regresar</asp:HyperLink>
										</div>
										<div class="col-xs-2"></div>
									</div>
								</div>
								<div class="col-xs-6 text-right">
                                    <asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
                                    <asp:Button ID="btnAccion" class="btn btn-default" runat="server" Text="Accion" />&nbsp;&nbsp;&nbsp;&nbsp;
								</div>
							</div>
						</form>
					</fieldset>
				</div>
			</div>
		</div>
		<div class="col-xs-1 col-sm-1 col-md-3"></div>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
