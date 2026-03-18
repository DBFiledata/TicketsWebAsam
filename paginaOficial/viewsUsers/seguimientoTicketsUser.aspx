<%@ Page Language="C#" AutoEventWireup="true" Title="Seguimiento de Tickets" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="seguimientoTicketsUser.aspx.cs" Inherits="paginaOficial.viewsUsers.seguimientoTicketsUser" %>

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
                <h3 class="text-center">Sus tickets generados</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="card-header bg-light">
                    <asp:Label ID="Label6" runat="server" Text="Label">Status de tickets</asp:Label>
                    <asp:DropDownList ID="listEstado" CssClass="btn btn-secondary dropdown-toggle py-1" Height="48.8px" ToolTip="🎫 Escoja el estado de su ticket" runat="server">
                        <asp:ListItem Value="0">🎫 Seleccionar Status</asp:ListItem>
                        <asp:ListItem Value="1">Creado</asp:ListItem>
                        <asp:ListItem Value="2">En atencion</asp:ListItem>
                        <asp:ListItem Value="3">Atendido</asp:ListItem>
                        <asp:ListItem Value="4">Programado</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnfiltrar" CssClass="btn btn-success btn-lg mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click" />
                </div>
                <div class="form-group">
                    <asp:GridView ID="listTickets" CssClass="table table-striped table-dark table-responsive" Font-Size="Small" runat="server"
                        AllowPaging="true" PageSize="50" 
                        OnPageIndexChanging="listTickets_PageIndexChanging"
                        AutoGenerateColumns="false"
                        DataKeyNames="Numero">
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Número" />
                            <asp:TemplateField HeaderText="Problema">
                                <ItemTemplate>
                                    <div class="cell-scroll"><%# Eval("problemas") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción">
                                <ItemTemplate>
                                    <div class="cell-scroll"><%# Eval("descripciones") %></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Solicitante" HeaderText="Solicitante" />
                            <asp:BoundField DataField="Tecnico" HeaderText="Técnico" />
                            <asp:BoundField DataField="Area" HeaderText="Área" />
                            <asp:BoundField DataField="Estatus" HeaderText="Estado" />
                            <asp:BoundField DataField="Creacion" HeaderText="Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Atencion" HeaderText="Atención" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Atendido" HeaderText="Atendido" DataFormatString="{0:dd/MM/yyyy}" />
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
