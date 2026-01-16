<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" MasterPageFile="~/viewsPruebas/Site1.Master" Inherits="paginaOficial.viewsPruebas.WebForm2" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Busqueda</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light">
                    <asp:TextBox ID="TextBox1" CssClass="active" Height="35px" placeholder="Buscar" runat="server"></asp:TextBox>
                    <asp:Button ID="btnfiltrar" Width="55px" Height="35px" CssClass="btn mr-1 text-light" ToolTip="Aplicar Filtro" Style="background-color: green" runat="server" Text="🔎"/>
                </div>
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" runat="server">


                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
