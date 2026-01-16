<%@ Page Language="C#" AutoEventWireup="true" Title="Inicio" MasterPageFile="~/viewsTecnicos/tecnicos.Master" CodeBehind="inicio.aspx.cs" Inherits="paginaOficial.viewsTecnicos.inicio" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <header class="masthead bg-gradient-success text-white text-center align-items-stretch h-auto">
        <div class="container d-flex align-items-center flex-column">

            <!-- Masthead Avatar Image -->
            <img class="mb-4" style="margin-top: -120px;" height="305" width="700" src="../userscontent/img/Tecnicos1.png" alt="" />
            <!-- Masthead Heading -->
            <h1 class="masthead-heading text-uppercase mb-0">Le damos la bienvenida</h1>

            <!-- Icon Divider -->
            <div class="divider-custom divider-light">
                <div class="divider-custom-line"></div>
                <div class="divider-custom-icon">
                    <i class="fa fa-wrench"></i>
                    <i class="fa fa-stethoscope"></i>
                    <i class="fa fa-desktop"></i>
                </div>

                <div class="divider-custom-line"></div>
            </div>

            <!-- Masthead Subheading -->
            <p class="masthead-subheading font-weight-light mb-0">Aplicacion para gestion de tikets para tecnicos</p>

        </div>
    </header>
</asp:Content>
