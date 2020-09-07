<%@ Page Language="C#" AutoEventWireup="true" Title="Inicio" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="inicioAdmin.aspx.cs" Inherits="paginaOficial.viewsAdmin.inicioAdmin" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <header class="masthead bg-info text-white text-center align-items-stretch h-auto">
        <div class="container d-flex align-items-center flex-column">

            <!-- Masthead Avatar Image -->
            <img class="mb-4" style="margin-top: -120px;" height="300" width="380" src="../userscontent/img/soporte.png" alt="" />
            <!-- Masthead Heading -->
            <h1 class="masthead-heading text-uppercase mb-0">Le damos la biemvenida</h1>

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
            <p class="masthead-subheading font-weight-light mb-0">aplicacion para administrar el proceso de atencion tecnica a dispocitivos tecnologicos</p>

        </div>
    </header>
</asp:Content>
