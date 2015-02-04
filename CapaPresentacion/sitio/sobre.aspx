<%@ Page Title="Sobre" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCCliente.Master" CodeBehind="sobre.aspx.vb" Inherits="CapaPresentacion.sobre" %>
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
						<legend class="text-center">Estudiantes</legend>							
						<form action="#" role="form" class="form-horizontal">
                            <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3"></div>
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <p class="text-center"><img class="img-responsive" src="../includes/images/logo-uia.png" alt="UIA Solo los mejores" /></p>
                            </div>
                            <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3"></div>
							<div class="col-xs-12">
								<h4 class="text-justify">Aplicaci&oacute;n para el Proyecto Final del curso Programaci&oacute;n 4 de la escuela de Inform&aacute;tica de la UIA. Esta ha sido desarrollada por los siguientes estudiantes:</h4>
								<br />
							</div>
							<br />
							<div class="col-xs-12">
								<div class="table-responsive">
									<table class="table table-hover table-stripped table-bordered text-center">
										<tr>
											<td><h4>Gilberth Molina Castrillo</h4></td>
										</tr>
										<tr>
											<td><h4>Jeison Leandro Hernández</h4></td>
										</tr>
										<tr>
											<td><h4>Milena Picado Santamaria</h4></td>
										</tr>
									</table>
								</div>
							</div>
							<br />
							<br />
							<div class="row">	
								<div class="col-xs-6">
									<br />
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
