<%@ Page Language="C#" AutoEventWireup="true" Title="Seguimuento de Tickets" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="seguimientoTickets.aspx.cs" Inherits="paginaOficial.viewsAdmin.seguimientoTickets" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Sus tickets generados</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light">
                    <asp:Label ID="Label6" runat="server" Text="Label">Filtro: </asp:Label>
                    <asp:DropDownList ID="listEstado" CssClass="active" Height="32px" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar Status</asp:ListItem>
                        <asp:ListItem Value="1">Creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="4">Programado</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="DropDownList1" CssClass="active" Height="32px" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar Status</asp:ListItem>
                        <asp:ListItem Value="1">Creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="4">Programado</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="list" CssClass="active" Height="32px" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar Status</asp:ListItem>
                        <asp:ListItem Value="1">Creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="4">Programado</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="niij" CssClass="active" Height="32px" ToolTip="Escoja el area a la que pertenece el ticket" runat="server">
                        <asp:ListItem Value="0">👷‍ Seleccionar</asp:ListItem>
                        <asp:ListItem Value="1">soporte Tecnico</asp:ListItem>
                        <asp:ListItem Value="2">Redes</asp:ListItem>
                        <asp:ListItem Value="3">Data Center</asp:ListItem>
                        <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="listAreas" runat="server"></asp:DropDownList>

                    <asp:Label ID="Label7" runat="server" Text="Label">Desde</asp:Label>
                    <asp:TextBox ID="txtDesde" CssClass="active" runat="server" ToolTip="📅 inicio de rango de busqueda" TextMode="Date"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="Label">Hasta</asp:Label>
                    <asp:TextBox ID="TxtHasta" CssClass="active" runat="server" ToolTip="📅 final de rago de busqueda" TextMode="Date"></asp:TextBox>
                    <asp:Button ID="Button1" CssClass="btn btn-success btn-lg  mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" />
                    <%--OnClick="btnfiltrar_Click"--%> 
                    <asp:Button ID="btnReporte" CssClass="btn btn-primary btn-lg  mr-1" ToolTip="Generar Reporte" runat="server" Text="📥"  />
                    <%--OnClick="btnReporte_Click"--%>

                </div>
                <div class="form-group">
                    <asp:GridView ID="listTickets" class="table table stacktable table-dark table-responsive" Font-Size="Small" runat="server"></asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
