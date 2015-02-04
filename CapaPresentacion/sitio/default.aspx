<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCDefault.master" CodeBehind="default.aspx.vb" Inherits="CapaPresentacion._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <article>
	<div class="container">
		<br />
		<div class="row">
			<div class="col-xs-1 col-sm-2 col-md-5 col-lg-6">
				<br />
				<img class="img-responsive hidden-xs hidden-sm" src="../includes/images/application-services.png" alt="application-services" />
			</div>
			<div class="col-xs-12 col-sm-8 col-md-6 col-lg-5">
				<div class="row">
					<div class="col-xs-12">
						<div class="panel panel-default">
							<div class="panel-body">
								<fieldset>
									<legend class="text-center">Inicio de Sesi&oacute;n</legend>
									<form action="#" role="form" class="form-horizontal">
										<div class="form-group">
											<label for="txtCorreo" class="control-label col-xs-5 text-right">Correo electr&oacute;nico:</label>
											<div class="col-xs-7">
												<div class="input-group">
													<div class="input-group-addon">@</div>
													<asp:TextBox ID="txtCorreo" name="txtCorreo" class="form-control" placeholder="Correo electr&oacute;nico" runat="server"></asp:TextBox>
												</div>
												<br />
											</div>
										</div>
										<br />
										<div class="form-group">
											<label for="txtContraseña" class="control-label col-xs-5 text-right">Contraseña:</label>
											<div class="col-xs-7">
												<asp:TextBox ID="txtContraseña" name="txtContraseña" class="form-control" placeholder="Contraseña" runat="server" TextMode="Password"></asp:TextBox>
												<br />
											</div>
										</div>
										<br />
										<div class="col-xs-12">
											<asp:Panel ID="pnErrorInicioSesion" class="panel panel-default hidden" runat="server">
												<ul class="list-group text-center">
													<li class="list-group-item list-group-item-danger">
														<asp:Label ID="lbErrorInicioSesion" runat="server" Text=""></asp:Label>
													</li>
												</ul>
											</asp:Panel>
										</div>
										<br />
										<div class="form-group text-right">
											<asp:Button ID="btnLimpiar" class="btn btn-primary" runat="server" Text="Limpiar" />
											<asp:Button ID="btnIngresar" class="btn btn-success" runat="server" Text="Ingresar" />&nbsp;&nbsp;&nbsp;&nbsp;
										</div>
									</form>
								</fieldset>
							</div>
							<div class="panel-footer">
								<div class="row text-center">
									<div class="col-xs-6"><a href="registrar_usuario.aspx">Registrarse</a></div>
									<div class="col-xs-6"><a href="recordar_contrasena.aspx">¿Olvidaste tu contraseña?</a></div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-1 col-sm-2 col-md-1 col-lg-1 hidden-xs"></div>
		</div>
	</div>
</article>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
