<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" MasterPageFile="~/viewsPruebas/Site1.Master" Inherits="paginaOficial.viewsPruebas.WebForm1" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Solicitudes</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light">
                    <asp:Button ID="Button1" CssClass="btn btn-lg  mr-1 text-light" ToolTip="Aplicar Filtro" Style="background-color: green" runat="server" Text="Procesadas"/>
                    <asp:Button ID="btnfiltrar" CssClass="btn btn-lg  mr-1 text-light" ToolTip="Aplicar Filtro" Style="background-color: green" runat="server" Text="Enviadas"/>
                </div>
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Estatus">
                            <ItemTemplate>
                               
                                <asp:Button ID="Button2" CommandName="editar" Text="Recibir" CssClass="btn  btn-light" ToolTip="Editar informacion del usuario" runat="server" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
