<%@ Page Language="C#" AutoEventWireup="true" Title="Tickets del Area" MasterPageFile="~/viewsTrabajosProgramados/TrabajosProgramados.Master" CodeBehind="ticketsTProgramado.aspx.cs" Inherits="paginaOficial.viewsTrabajosProgramados.ticketsTProgramado" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            display: none;
            width: 100%;
            height: 100%;
            overflow: hidden;
        }

        .modal-dialog {
            position: relative;
            width: auto;
        }

        .modal-dialog-scrollable {
            display: flex;
        }

        .modal-header,
        .modal-footer {
            flex-shrink: 0;
        }

        .modal-body {
            overflow-y: auto;
        }

        .modal-dialog-centered {
            display: flex;
            align-items: center;
        }

        .modal-content {
            position: relative;
            display: flex;
            flex-direction: column;
            width: 100%;
            pointer-events: auto;
        }

        .modal-backdrop {
            position: fixed;
            top: 0;
            left: 0;
            width: 100vw;
            height: 100vh;
        }

        .modal-header {
            display: flex;
            align-items: flex-start;
        }

        .modal-title {
            margin-bottom: 0;
        }

        .modal-body {
            position: relative;
        }

        .modal-footer {
            display: flex;
            align-items: center;
            margin-left: .25rem;
        }

        .modal-scrollbar-measure {
            position: absolute;
            top: -9999px;
            width: 50px;
            height: 50px;
            overflow: scroll;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
    </style>
    <script type="text/javascript">
        function iniciarTimer() {
            var b = $find('<%= Timer1.ClientID %>');
            if (b) {
                b._startTimer();
            }
        }
    </script>
    <script type="text/javascript">
        function mostrarAlerta(tipo, mensaje) {
            var iconClass = tipo === 'success' ? 'fa-check-circle' : 
                           tipo === 'danger' ? 'fa-exclamation-circle' : 
                           tipo === 'warning' ? 'fa-exclamation-triangle' : 
                           'fa-info-circle';
            
            var alertHtml = '<div class="alert alert-' + tipo + ' alert-dismissible fade show position-fixed" role="alert" style="top: 20px; right: 20px; z-index: 9999; min-width: 300px; box-shadow: 0 4px 6px rgba(0,0,0,0.1);">' +
                '<i class="fas ' + iconClass + ' mr-2"></i>' +
                '<strong>' + mensaje + '</strong>' +
                '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span>' +
                '</button>' +
                '</div>';
            
            $('body').append(alertHtml);
            setTimeout(function () { $('.alert').alert('close'); }, 4000);
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:HiddenField ID="HiddenField1" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeReasignar" runat="server" PopupControlID="Panel1" TargetControlID="HiddenField1"
                CancelControlID="btnCloseReasignar" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField2" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeResultado" runat="server" PopupControlID="Panel2" TargetControlID="HiddenField2"
                CancelControlID="btnCloseResultado" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
            </asp:Timer>

            <asp:Panel ID="Panel1" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;" runat="server">
                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Reasignar ticket</h4>
                        <asp:Button ID="btnCloseReasignar" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea reasignar el ticket
                                            <br />
                                                #
                                                <asp:Label ID="lblIdReasignar" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                            </h6>
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Label">Motivo de la Reasignacion</asp:Label>
                                                <asp:TextBox ID="txtMotivoReasignacion" runat="server"
                                                    ToolTip="Ingrese la informacion de forma entendible. Detalle por que sera reasignado este ticket"
                                                    CssClass="form-control ml-2" TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                            </div>
                                            <div class="form-group text-center">
                                                <asp:Label ID="Label2" runat="server" Text="Label">Seleccionar Tecnico</asp:Label>
                                                <asp:DropDownList ID="ddlTecnicos" runat="server" CssClass="form-control" Width="95%">
                                                    <asp:ListItem Value="0" Text="-- Seleccione un tecnico --"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <asp:Button ID="btnReasignar" class="btn btn-primary" runat="server" Text="Aceptar" OnClick="btnReasignar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">
                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Reasignacion de ticket</h4>
                        <asp:Button ID="btnCloseResultado" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Se ha reasignado el ticket a:
                                            <br />
                                            </h6>
                                            <div class="form-group">
                                                <asp:Label ID="lblTecnico" runat="server" Font-Size="25px" Text="Label">#</asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblcedulaTecnico" runat="server" Font-Size="25px" Text="Label">#</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <div class="card-body">
                <div class="card-header bg-light">
                    <h5 class=" text-center">Tickets asignados al area</h5>
                </div>
                <div class="form-group table-responsive">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" Font-Size="Small" Width="100%" CellSpacing="0" runat="server" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Procesos">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" CommandName="reasignarTicket" Text="🔄" CssClass="btn btn-link" ToolTip="Reasignar a otro tecnico" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
