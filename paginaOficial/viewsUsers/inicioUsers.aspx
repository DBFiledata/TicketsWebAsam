<%@ Page Language="C#" AutoEventWireup="true" Title="Inicio" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="inicioUsers.aspx.cs" Inherits="paginaOficial.viewsUsers.inicioUsers" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="contenido" runat="server">
        <!-- Masthead -->
        <header class="masthead bg-primary text-white text-center">
            <div class="container d-flex align-items-center flex-column">

                <!-- Masthead Avatar Image -->
                <img class="mb-1" height="300" width="380" style="margin-top:-120px;" src="../userscontent/img/soporte1.png" alt="" />

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
                <p class="masthead-subheading font-weight-light mb-0">Aplicacion tecnologica para agilizar el proceso de atencion tecnica para dispositivos tecnologicos</p>
                <p class="masthead-subheading font-weight-light mb-0">Genere su tiket para ser atendido por personal tecnico </p>

            </div>
        </header>

</asp:Content>
