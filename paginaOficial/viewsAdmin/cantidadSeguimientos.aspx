<%@ Page Language="C#" AutoEventWireup="true" Title="Cantidad de Seguimientos" MasterPageFile="~/viewsAdmin/admin.Master"  CodeBehind="cantidadSeguimientos.aspx.cs" Inherits="paginaOficial.viewsAdmin.cantidadSeguimientos" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <div class="card-body">
        <div class="card-header bg-light">
            <h5 class=" text-center">Cantidad de tickets asignados a seguimiento por tecnico</h5>
        </div>
        <div class="card-header bg-light d-flex flex-wrap align-items-center justify-content-center mt-1">
            <asp:Label ID="lblDesde" runat="server" Text="Desde" CssClass="mr-1"></asp:Label>
            <asp:TextBox ID="txtDesde" CssClass="form-control form-control-sm d-inline-block mr-2" Width="150px" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Label ID="lblHasta" runat="server" Text="Hasta" CssClass="mr-1"></asp:Label>
            <asp:TextBox ID="TxtHasta" CssClass="form-control form-control-sm d-inline-block mr-2" Width="150px" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Button ID="btnFiltrar" CssClass="btn btn-success btn-sm mr-1" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
            <asp:Button ID="btnLimpiar" CssClass="btn btn-warning btn-sm" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </div>
        <div class="form-group table-responsive">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered  " Font-Size="Small" Width="100%" CellSpacing="0" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
