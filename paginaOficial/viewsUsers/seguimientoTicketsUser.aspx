<%@ Page Language="C#" AutoEventWireup="true" Title="Seguimiento de Tickets" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="seguimientoTicketsUser.aspx.cs" Inherits="paginaOficial.viewsUsers.seguimientoTicketsUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modal-dialog {
            position: relative;
            width: auto;
            margin: 10px;
        }
        .modal-content {
            position: relative;
            display: flex;
            flex-direction: column;
            width: 100%;
            background-color: #fff;
            border-radius: 0.3rem;
        }
        .modal-header {
            display: flex;
            align-items: flex-start;
            justify-content: space-between;
            padding: 1rem;
            border-bottom: 1px solid #dee2e6;
        }
        .modal-body {
            position: relative;
            flex: 1 1 auto;
            padding: 1rem;
        }
        .btn-reasignar {
            background-color: transparent;
            border: none;
            color: #17a2b8;
            font-size: 18px;
            cursor: pointer;
        }
        .btn-reasignar:hover {
            color: #138496;
        }
        /* Estilos para alertas Bootstrap */
        .alert-container {
            position: fixed;
            top: 20px;
            right: 20px;
            z-index: 9999;
            max-width: 400px;
        }
        .alert {
            padding: 15px 20px;
            border-radius: 8px;
            margin-bottom: 10px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            animation: slideIn 0.3s ease-out;
        }
        @keyframes slideIn {
            from { transform: translateX(100%); opacity: 0; }
            to { transform: translateX(0); opacity: 1; }
        }
        .alert-success {
            background-color: #d4edda;
            border-color: #c3e6cb;
            color: #155724;
        }
        .alert-danger {
            background-color: #f8d7da;
            border-color: #f5c6cb;
            color: #721c24;
        }
        .alert-warning {
            background-color: #fff3cd;
            border-color: #ffeeba;
            color: #856404;
        }
    </style>

    <!-- Contenedor de alertas -->
    <div id="alertContainer" class="alert-container"></div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- HiddenField y Modal para Reasignar -->
            <asp:HiddenField ID="hfReasignar" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeReasignar" runat="server" 
                PopupControlID="pnlReasignar" 
                TargetControlID="hfReasignar"
                CancelControlID="btnCloseReasignar" 
                BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="pnlReasignar" runat="server" CssClass="modal-dialog" Style="display: none; width: 500px; margin: 100px auto;">
                <div class="modal-content">
                    <div class="modal-header bg-info text-white">
                        <h5 class="modal-title"><i class="fas fa-exchange-alt"></i> Reasignar Ticket a Otra Área</h5>
                        <asp:Button ID="btnCloseReasignar" runat="server" Text="×" CssClass="close text-white" Style="font-size: 24px;" />
                    </div>
                    <div class="modal-body">
                        <div class="text-center mb-3">
                            <h6>Ticket #<asp:Label ID="lblIdTicketReasignar" runat="server" CssClass="font-weight-bold" Text=""></asp:Label></h6>
                        </div>
                        
                        <div class="form-group">
                            <label for="ddlNuevaArea"><i class="fas fa-building"></i> Seleccionar Nueva Área:</label>
                            <asp:DropDownList ID="ddlNuevaArea" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Text="-- Seleccione un área --"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Soporte Técnico"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Redes"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Data Center"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Desarrollo"></asp:ListItem>
                                <asp:ListItem Value="9" Text="Administrativo Tecnología"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        
                        <div class="form-group">
                            <label for="txtMotivoReasignacion"><i class="fas fa-comment-alt"></i> Motivo de Reasignación:</label>
                            <asp:TextBox ID="txtMotivoReasignacion" runat="server" CssClass="form-control" 
                                TextMode="MultiLine" Rows="3" 
                                placeholder="Explique brevemente el motivo de la reasignación..."></asp:TextBox>
                        </div>
                        
                        <div class="alert alert-info">
                            <i class="fas fa-info-circle"></i> Al reasignar el ticket, se asignará automáticamente a un técnico disponible del área seleccionada.
                        </div>
                        
                        <div class="text-center mt-3">
                            <asp:Button ID="btnConfirmarReasignacion" runat="server" Text="✔ Confirmar Reasignación" 
                                CssClass="btn btn-primary" OnClick="btnConfirmarReasignacion_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>

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
                        OnRowCommand="listTickets_RowCommand"
                        AutoGenerateColumns="false"
                        DataKeyNames="Numero">
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Número" />
                            <asp:BoundField DataField="problemas" HeaderText="Problema" />
                            <asp:BoundField DataField="descripciones" HeaderText="Descripción" />
                            <asp:BoundField DataField="Solicitante" HeaderText="Solicitante" />
                            <asp:BoundField DataField="Tecnico" HeaderText="Técnico" />
                            <asp:BoundField DataField="Area" HeaderText="Área" />
                            <asp:BoundField DataField="Estatus" HeaderText="Estado" />
                            <asp:BoundField DataField="Creacion" HeaderText="Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Atencion" HeaderText="Atención" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Atendido" HeaderText="Atendido" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnReasignarArea" runat="server" 
                                        CommandName="reasignarArea" 
                                        CommandArgument='<%# Eval("Numero") %>'
                                        CssClass="btn-reasignar" 
                                        ToolTip="Reasignar a otra área">
                                        <i class="fas fa-exchange-alt"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
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

    <script type="text/javascript">
        function mostrarAlerta(tipo, mensaje) {
            var alertClass = 'alert-' + tipo;
            var icono = tipo === 'success' ? 'fa-check-circle' : (tipo === 'danger' ? 'fa-exclamation-circle' : 'fa-info-circle');
            var alertHtml = '<div class="alert ' + alertClass + '">' +
                '<i class="fas ' + icono + ' mr-2"></i>' + mensaje +
                '</div>';
            var container = document.getElementById('alertContainer');
            container.innerHTML = alertHtml;
            setTimeout(function () {
                container.innerHTML = '';
            }, 4000);
        }
    </script>
</asp:Content>
