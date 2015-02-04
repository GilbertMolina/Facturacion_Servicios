<%@ Page Title="Mantenimiento Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCSuperAdmin.Master" CodeBehind="maClientes.aspx.vb" Inherits="CapaPresentacion.maClientes" %>
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
						<legend class="text-center">Mantenimiento Clientes</legend>
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
							<div class="form-group">
								<label for="txtNombreUsuario" class="control-label col-xs-5 text-right">Nombre de usuario:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtNombreUsuario" class="form-control" placeholder="Nombre de usuario" runat="server"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtPrimerApellido" class="control-label col-xs-5 text-right">Primer Apellido:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtPrimerApellido" class="form-control" placeholder="Primer apellido" runat="server"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtSegundoApellido" class="control-label col-xs-5 text-right">Segundo Apellido:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtSegundoApellido" class="form-control" placeholder="Segundo apellido" runat="server"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtFechaNacimiento" class="control-label col-xs-5 text-right">Fecha de nacimiento:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtFechaNacimiento" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtDireccion" class="control-label col-xs-5 text-right">Direcci&oacute;n:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtDireccion" class="form-control" placeholder="Direcci&oacute;n" runat="server"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtTelefono" class="control-label col-xs-5 text-right">Tel&eacute;fono:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtTelefono" class="form-control" placeholder="Tel&eacute;fono" runat="server" TextMode="Phone"></asp:TextBox>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="ddlSexo" class="control-label col-xs-5 text-right">Sexo: </label>
								<div class="col-xs-7">
									<asp:DropDownList ID="ddlSexo" class="form-control" runat="server"></asp:DropDownList>
									<br />
								</div>
							</div>
							<br />
							<div class="form-group">
								<label for="txtContraseña" class="control-label col-xs-5 text-right">Contraseña:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtContraseña" class="form-control" placeholder="Contraseña" 
                                        runat="server" TextMode="Password"></asp:TextBox>
									<br />
								</div>
							</div>
							<div class="form-group">
								<label for="txtContraseñaConfirmar" class="control-label col-xs-5 text-right">Confirmar contraseña:</label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtContraseñaConfirmar" class="form-control" 
                                        placeholder="Confirmar contraseña" runat="server" TextMode="Password"></asp:TextBox>
									<br />
								</div>
							</div>
							<div class="form-group">
								<label for="txtRol" class="control-label col-xs-5 text-right">Rol asignado: </label>
								<div class="col-xs-7">
                                    <asp:TextBox ID="txtRol" class="form-control" placeholder="" runat="server" disabled>Cliente</asp:TextBox>
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
                                            <asp:HyperLink ID="hlRegresar" class="btn btn-back" runat="server" NavigateUrl="listadoClientes.aspx">Regresar</asp:HyperLink>
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
