<%@ Page Language="C#" AutoEventWireup="true" Title="Lista de Peronal Tecnico" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="listaUsuariosUser.aspx.cs" Inherits="paginaOficial.viewsUsers.listaUsuariosUser" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Busqueda de Personal Tecnico</h3>
            </div>
            <div class="card-body">
                <div class="card-header bg-light">
                    <asp:Label ID="Label6" runat="server" Text="Label">Tipo de usuario</asp:Label>
                    <asp:DropDownList ID="ListTipo" CssClass="active" ToolTip="👷‍ Escoja el tipo de usuario" runat="server">
                        <asp:ListItem Value="0">👥 Seleccionar</asp:ListItem>
                        <asp:ListItem Value="1">Soporte Tecnico</asp:ListItem>
                        <asp:ListItem Value="2">Redes</asp:ListItem>
                        <asp:ListItem Value="3">Data Center</asp:ListItem>
                        <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                        <asp:ListItem Value="5">Agente</asp:ListItem>
                        <asp:ListItem Value="6">Administrador</asp:ListItem>
                        <asp:ListItem Value="7">Monitoreo</asp:ListItem>
                        <asp:ListItem Value="8">Administrador de Trabajos Programados</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre de usuario</asp:Label>
                    <asp:TextBox ID="txtnombre" CssClass="active" ToolTip="Ingrese el nombre y apellido &#10;O alguno de estos dos datos" runat="server"></asp:TextBox>
                    <asp:Button ID="btnfiltrar" CssClass="btn btn-success btn-lg  mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click" />
                </div>
                <div class="form-group">
                    <asp:GridView ID="GridView1" class="table table-striped table-dark" runat="server"></asp:GridView>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
