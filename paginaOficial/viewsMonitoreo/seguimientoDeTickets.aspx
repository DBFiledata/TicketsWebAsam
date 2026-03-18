<%@ Page Language="C#" AutoEventWireup="true" Title="Seguimuento de Tickets" MasterPageFile="~/viewsMonitoreo/monitoreo.Master" CodeBehind="seguimientoDeTickets.aspx.cs" Inherits="paginaOficial.viewsMonitoreo.seguimientoDeTickets" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style type="text/css">
        /* Scroll para columnas de texto largo */
        .cell-scroll {
            max-height: 80px;
            max-width: 300px;
            overflow-y: auto;
            white-space: pre-wrap;
            word-wrap: break-word;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Tickets generados</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light d-flex flex-wrap align-items-center">
                    <div class="mr-2 mb-2">
                        <asp:Label ID="Label6" runat="server" CssClass="font-weight-bold mr-2">Filtro:</asp:Label>
                        <asp:DropDownList ID="listEstado" CssClass="form-control form-control-sm d-inline-block" Width="180px" ToolTip="Escoja el estado de su ticket" runat="server">
                            <asp:ListItem Value="0">Seleccionar status</asp:ListItem>
                            <asp:ListItem Value="1">Creado</asp:ListItem>
                            <asp:ListItem Value="2">En atencion</asp:ListItem>
                            <asp:ListItem Value="3">Atendido</asp:ListItem>
                            <asp:ListItem Value="4">Programado</asp:ListItem>
                            <asp:ListItem Value="6">En segumiento</asp:ListItem>
                            <asp:ListItem Value="7">En revision</asp:ListItem>
                            <asp:ListItem Value="8">Trabajo Programado</asp:ListItem>
                            <asp:ListItem Value="5">Finalizado</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="mr-2 mb-2">
                        <asp:DropDownList ID="listAreas" CssClass="form-control form-control-sm d-inline-block" Width="180px" ToolTip="Escoja el area a la que pertenece el ticket" runat="server">
                            <asp:ListItem Value="0">Seleccionar área</asp:ListItem>
                            <asp:ListItem Value="1">Soporte Tecnico</asp:ListItem>
                            <asp:ListItem Value="2">Redes</asp:ListItem>
                            <asp:ListItem Value="3">Data center</asp:ListItem>
                            <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                            <asp:ListItem Value="9">Administrativo Tecnología</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="mr-2 mb-2">
                        <asp:Label ID="Label7" runat="server" CssClass="font-weight-bold mr-2">Desde</asp:Label>
                        <asp:TextBox ID="txtDesde" CssClass="form-control form-control-sm d-inline-block" Width="140px" runat="server" ToolTip="Inicio de rango de búsqueda" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="mr-2 mb-2">
                        <asp:Label ID="Label8" runat="server" CssClass="font-weight-bold mr-2">Hasta</asp:Label>
                        <asp:TextBox ID="TxtHasta" CssClass="form-control form-control-sm d-inline-block" Width="140px" runat="server" ToolTip="Final de rango de búsqueda" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="mr-2 mb-2">
                        <asp:Button ID="Button1" CssClass="btn btn-success btn-sm" ToolTip="Aplicar Filtro" runat="server" Text="Filtrar" OnClick="btnfiltrar_Click" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-warning btn-sm ml-1" ToolTip="Limpiar Filtro" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </div>

                    <div class="ml-auto mb-2">
                        <asp:Button ID="btnExportar" CssClass="btn btn-primary btn-sm" ToolTip="Exportar a Excel" runat="server" Text="Exportar Excel" OnClick="btnExportar_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:GridView ID="listTickets" class="table table stacktable table-dark table-responsive" Font-Size="Small" runat="server" AllowPaging="true" PageSize="100" 
                        OnPageIndexChanging="listTickets_PageIndexChanging"
                        OnRowDataBound="listTickets_RowDataBound">
                        <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <PagerStyle BackColor="White" CssClass="dataTables_paginate paging_simple_numbers" VerticalAlign="Bottom" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>