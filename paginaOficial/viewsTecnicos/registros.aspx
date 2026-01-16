<%@ Page Language="C#" AutoEventWireup="true" Title="Registro de sus tickets" MasterPageFile="~/viewsTecnicos/tecnicos.Master" CodeBehind="registros.aspx.cs" Inherits="paginaOficial.viewsTecnicos.registros" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Sus Tickets</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light">

                    <asp:Label ID="Label6" runat="server" Text="Label">Filtro: </asp:Label>
                    <asp:DropDownList ID="listEstado" CssClass="active" Height="32px" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar status</asp:ListItem>
                        <asp:ListItem Value="1">Creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="6">En segumiento</asp:ListItem>
                        <asp:ListItem Value="7">En revision</asp:ListItem>
                        <asp:ListItem Value="8">Trabajo Progamado</asp:ListItem>
                        <asp:ListItem Value="5">Finalizado</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label1" runat="server" Text="Label">Solicitante -Nombre</asp:Label>
                    <asp:TextBox ID="txtSolicitanteNombres" CssClass="active" runat="server" ToolTip="🧏‍ nombre de solicitante"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Label">-Apellido</asp:Label>
                    <asp:TextBox ID="txtSolicitanteApellidos" CssClass="active" runat="server" ToolTip="🧏‍ apellido de solicitante"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="Label">Desde</asp:Label>
                    <asp:TextBox ID="txtDesde" CssClass="active" runat="server" ToolTip="📅 inicio de rango de busqueda" TextMode="Date"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="Label">Hasta</asp:Label>
                    <asp:TextBox ID="TxtHasta" CssClass="active" runat="server" ToolTip="📅 final de rago de busqueda" TextMode="Date"></asp:TextBox>
                    <asp:Button ID="Button1" CssClass="btn btn-success btn-lg  mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click"/>
                    <%--<asp:Button ID="btnReporte" CssClass="btn btn-primary btn-lg  mr-1" ToolTip="Generar Reporte" runat="server" Text="📥" OnClick="btnReporte_Click"/>--%>

                </div>
                <div class="form-group">
                    <asp:GridView ID="listTickets" class="table table stacktable table-dark table-responsive" Font-Size="Small" runat="server" 
                        AllowPaging="true" PageSize="50" 
                        OnPageIndexChanging="listTickets_PageIndexChanging">
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
