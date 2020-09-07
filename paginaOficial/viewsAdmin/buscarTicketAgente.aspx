<%@ Page Language="C#" AutoEventWireup="true" Title="Buscar Ticket" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="buscarTicketAgente.aspx.cs" Inherits="paginaOficial.viewsAdmin.buscarTicketAgente" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
        <asp:Panel ID="panelBuscar" runat="server" Visible="true">
            <div class="container py-5">
                <div class="d-flex align-items-center justify-content-center">
                    <div class="col-md-8  bg-dark mt-4 pb-5 pt-5 rounded">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-header">
                                        <h3 class=" text-center">Busqueda de Tickets</h3>
                                    </div>
                                    <div class="card-body">


                                        <div class="form-group">
                                            <h3 class=" text-center pt-2">Por Agentes</h3>
                                            <asp:TextBox ID="id" CssClass="form-control text-center"
                                                Width="95%"
                                                ToolTip="👨‍💼 Deve ingresar el ID del agente el cual realizo el ticket &#10;✔Al encontarlo puede realizar los siguientes procesos: &#10;🛠edicion o  🗑eliminacion"
                                                placeholder="👨‍💼" runat="server">
                                            </asp:TextBox>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="btnBuscar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Buscar🔎" OnClick="btnBuscar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="panelInfo" runat="server" Visible="False">
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Tickets del Agente</h3>
            </div>
            <div class="card-body">
                <div class="card-header bg-light">
                    <asp:Label ID="Label6" runat="server" Text="Label">Status de tickets</asp:Label>
                    <asp:DropDownList ID="listEstado" CssClass="active" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar Status</asp:ListItem>
                        <asp:ListItem Value="1">creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="4">Programado</asp:ListItem>
                        <asp:ListItem Value="5">finalizado</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnfiltrar" CssClass="btn btn-success btn-lg  mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click" />
                </div>
                <div class="form-group">
                    <asp:GridView ID="listTickets" class="table table-striped table-dark" Font-Size="Small" Width="100%" CellSpacing="0"  runat="server"></asp:GridView>
                </div>

            </div>
        </asp:Panel>
</asp:Content>
