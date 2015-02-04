<%@ Page Title="Mantenimiento Impuestos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCSuperAdmin.Master" CodeBehind="maImpuestos.aspx.vb" Inherits="CapaPresentacion.maImpuestos" %>
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
						<legend class="text-center">Registro de Impuestos</legend>
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
								<label for="txtDescripcion" class="control-label col-xs-5 text-right">Descripci&oacute;n:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Descripci&oacute;n" runat="server"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
                                <label for="txtPorcentajeImpuesto" class="control-label col-xs-5 text-right">Porcentaje Impuesto:</label>
								<div class="col-xs-7">
									<div class="input-group">
										<div class="input-group-addon">%</div>
                                        <asp:TextBox ID="txtPorcentajeImpuesto" class="form-control" placeholder="Impuesto" runat="server"></asp:TextBox>
									</div>
									<br />
								</div>
							</div>
							<br />
							<div class="row">	
								<div class="col-xs-6">
									<div class="row">
										<div class="col-xs-2"></div>
										<div class="col-xs-8">
                                            <asp:HyperLink ID="hlRegresar" class="btn btn-back" runat="server" NavigateUrl="listadoImpuestos.aspx">Regresar</asp:HyperLink>
										</div>
										<div class="col-xs-2"></div>
									</div>
								</div>
								<div class="col-xs-6 text-right">
                                    <asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
                                    <asp:Button ID="btnAccion" class="btn btn-default" runat="server" Text="Registrar" />&nbsp;&nbsp;&nbsp;&nbsp;
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
