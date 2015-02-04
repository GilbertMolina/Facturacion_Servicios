<%@ Page Title="Inicio" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/ServiciosABCCliente.Master" CodeBehind="inicio.aspx.vb" Inherits="CapaPresentacion.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" runat="server">
    <div class="container">
		<div class="row">
			<div class="col-xs-12">
                <h1 class="text-center">Bienvenido</h1>
				<h2 class="text-center"><asp:Label ID="lbNombreCompletoUsuario" runat="server"></asp:Label></h2>
				<h2 class="text-center">Rol asignado: <kbd><asp:Label ID="lbRolAsignado" runat="server"></asp:Label></kbd></h2>
			</div>
		</div>
		<div class="row">
			<div class="col-xs-2 col-sm-2 col-md-3"></div>
            <div class="col-xs-8 col-sm-8 col-md-6">
                <p class="text-center"><img class="img-responsive" src="../includes/images/business-services.png" alt="application-services" /></p>
            </div>
            <div class="col-xs-2 col-sm-2 col-md-3"></div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>
