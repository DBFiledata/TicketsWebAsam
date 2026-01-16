<%@ Page Language="C#" AutoEventWireup="true" Title="Cantidad de revisiones" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="cantidadRevisiones.aspx.cs" Inherits="paginaOficial.viewsAdmin.cantidadRevisiones" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <div class="card-body">
        <div class="card-header bg-light">
            <h5 class=" text-center">Cantidad de tickets asignados a revision por tecnico</h5>
        </div>
        <div class="form-group table-responsive">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered  " Font-Size="Small" Width="100%" CellSpacing="0" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
