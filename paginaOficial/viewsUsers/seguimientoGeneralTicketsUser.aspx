<%@ Page Language="C#" AutoEventWireup="true" Title="Seguimiento general Tickets" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="seguimientoGeneralTicketsUser.aspx.cs" Inherits="paginaOficial.viewsUsers.seguimientoGeneralTicketsUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modal-dialog {
            position: relative;
            width: auto;
            margin: 10px;
        }
        .modal-content {
            position: relative;
            display: flex;
            flex-direction: column;
            width: 100%;
            background-color: #fff;
            border-radius: 0.3rem;
        }
        .modal-header {
            display: flex;
            align-items: flex-start;
            justify-content: space-between;
            padding: 1rem;
            border-bottom: 1px solid #dee2e6;
        }
        .modal-body {
            position: relative;
            flex: 1 1 auto;
            padding: 1rem;
        }
        .btn-reasignar {
            background-color: transparent;
            border: none;
            color: #17a2b8;
            font-size: 18px;
            cursor: pointer;
        }
        .btn-reasignar:hover {
            color: #138496;
        }
        /* Estilos para alertas Bootstrap */
        .alert-container {
            position: fixed;
            top: 20px;
            right: 20px;
            z-index: 9999;
            max-width: 400px;
        }
        .alert {
            padding: 15px 20px;
            border-radius: 8px;
            margin-bottom: 10px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            animation: slideIn 0.3s ease-out;
        }
        @keyframes slideIn {
            from { transform: translateX(100%); opacity: 0; }
            to { transform: translateX(0); opacity: 1; }
        }
        .alert-success {
            background-color: #d4edda;
            border-color: #c3e6cb;
            color: #155724;
        }
        .alert-danger {
            background-color: #f8d7da;
            border-color: #f5c6cb;
            color: #721c24;
        }
        .alert-warning {
            background-color: #fff3cd;
            border-color: #ffeeba;
            color: #856404;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="card-header bg-gradient-secondary">
                <h3 class="text-center">Tickets generados</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light">
                    <asp:Label ID="Label6" runat="server" Text="Label">Filtro: </asp:Label>
                    <asp:DropDownList ID="listEstado" CssClass="active" Height="32px" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar status</asp:ListItem>
                        <asp:ListItem Value="1">Creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="4">Programado</asp:ListItem>
                        <asp:ListItem Value="6">En segumiento</asp:ListItem>
                        <asp:ListItem Value="7">En revision</asp:ListItem>
                        <%--<asp:ListItem Value="8">Trabajo Progamado</asp:ListItem>--%>
                        <asp:ListItem Value="5">Finalizado</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="listAreas" CssClass="active" Height="32px" ToolTip="Escoja el area a la que pertenece el ticket" runat="server">
                        <asp:ListItem Value="0">👷‍ Seleccionar</asp:ListItem>
                        <asp:ListItem Value="1">Soporte Tecnico</asp:ListItem>
                        <asp:ListItem Value="2">Redes</asp:ListItem>
                        <asp:ListItem Value="3">Data center</asp:ListItem>
                        <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                        <asp:ListItem Value="9">Administrativo Tecnología</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="Label7" runat="server" Text="Label">Desde</asp:Label>
                    <asp:TextBox ID="txtDesde" CssClass="active" runat="server" ToolTip="📅 inicio de rango de busqueda" TextMode="Date"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="Label">Hasta</asp:Label>
                    <asp:TextBox ID="TxtHasta" CssClass="active" runat="server" ToolTip="📅 final de rago de busqueda" TextMode="Date"></asp:TextBox>
                    <asp:Button ID="Button1" CssClass="btn btn-success btn-lg mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click"/>
                    <asp:Button ID="btnReporte" CssClass="btn btn-primary btn-lg mr-1" ToolTip="Generar Reporte" runat="server" Text="📥" OnClick="btnReporte_Click"/>
                </div>
                <div class="form-group">
                    <asp:GridView ID="listTickets" CssClass="table table-striped table-dark table-responsive" Font-Size="Small" runat="server"
                        AllowPaging="true" PageSize="100" 
                        OnPageIndexChanging="listTickets_PageIndexChanging"
                        AutoGenerateColumns="false"
                        DataKeyNames="Numero">
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Número" />
                            <asp:BoundField DataField="Nombre Solicitante" HeaderText="Solicitante" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                            <asp:BoundField DataField="Nombre Tecnico" HeaderText="Técnico" />
                            <asp:BoundField DataField="Nombre Agente" HeaderText="Agente" />
                            <asp:BoundField DataField="Problema" HeaderText="Problema" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="Area" HeaderText="Área" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="Fecha de creacion    " HeaderText="Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Fecha de programacion" HeaderText="Programación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Fecha de Finalizacion" HeaderText="Finalización" DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>
                        <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle BackColor="White" CssClass="dataTables_paginate paging_simple_numbers" VerticalAlign="Bottom" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
