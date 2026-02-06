<%@ Page Language="C#" AutoEventWireup="true" Title="Cerrar Tickets" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="CerrarTickets.aspx.cs" Inherits="paginaOficial.viewsUsers.CerrarTickets" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style type="text/css">
        /* Estilos para alertas modernas */
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
        .alert-info {
            background-color: #d1ecf1;
            border-color: #bee5eb;
            color: #0c5460;
        }

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

        }

        .modal-dialog-centered {
            display: flex;
            align-items: center;
        }

        &.modal-dialog-scrollable {
            flex-direction: column;
            justify-content: center;
            height: 100%;
        }

        &::before {
            content: none;
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



        .modal-dialog-scrollable {
            max-height: calc(100% - #{$modal-dialog-margin-y-sm-up * 2});
            max-height: calc(100vh - #{$modal-dialog-margin-y-sm-up * 2});
        }



        .modal-dialog-centered {
            min-height: calc(100% - #{$modal-dialog-margin-y-sm-up * 2});
            height: calc(100vh - #{$modal-dialog-margin-y-sm-up * 2});
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
    </style>

    <!-- Contenedor de alertas modernas -->
    <div id="alertContainer" class="alert-container"></div>

    <script type="text/javascript">
        function mostrarAlerta(tipo, mensaje) {
            var alertClass = 'alert-' + tipo;
            var icono = tipo === 'success' ? 'fa-check-circle' : 
                       (tipo === 'danger' ? 'fa-exclamation-circle' : 
                       (tipo === 'warning' ? 'fa-exclamation-triangle' : 'fa-info-circle'));
            var alertHtml = '<div class="alert ' + alertClass + '">' +
                '<i class="fas ' + icono + ' mr-2"></i>' + mensaje +
                '</div>';
            var container = document.getElementById('alertContainer');
            container.innerHTML = alertHtml;
            setTimeout(function () {
                container.innerHTML = '';
            }, 4000);
        }

        function iniciarTimer() {
            var b = $find('<%= Timer1.ClientID %>');
            if (b) {
                //b._stopTimer(); //stop the timer
                b._startTimer();//start the timer
            }
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:HiddenField ID="HiddenField1" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="HiddenField1"
                CancelControlID="btnClose" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField2" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeRevision" runat="server" PopupControlID="Panel2" TargetControlID="HiddenField2"
                CancelControlID="btnCloseRevision" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField3" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeSeguimiento" runat="server" PopupControlID="Panel3" TargetControlID="HiddenField3"
                CancelControlID="btnCloseSeguimiento" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField4" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeReasignar" runat="server" PopupControlID="Panel4" TargetControlID="HiddenField4"
                CancelControlID="btnCloseReasignar" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField5" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeReasignado" runat="server" PopupControlID="Panel5" TargetControlID="HiddenField5"
                CancelControlID="btnCloseReasignado" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField6" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeReasignarArea" runat="server" PopupControlID="Panel6" TargetControlID="HiddenField6"
                CancelControlID="btnCloseReasignarArea" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>




            <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
            </asp:Timer>

            <asp:Panel ID="Panel1" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">

                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Cerrar Tickets</h4>
                        <asp:Button ID="btnClose" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea finalizar el ticket
                                            <br />
                                                #
                                                <asp:Label ID="lblIdFinalizar" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                            </h6>
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Label">Comentario</asp:Label>
                                                <asp:TextBox ID="txtComent" runat="server"
                                                    ToolTip="📝 Ingrese la informacion de forma entendible &#10;Detalle por que sera asignado este ticket a revision"
                                                    CssClass="form-control ml-2" TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                            </div>
                                            <asp:Button ID="btnConfirmar" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnConfirmar_Click" />
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
                        <h4 class="modal-title text-center">Revision de Tickets</h4>
                        <asp:Button ID="btnCloseRevision" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea realizar revision del ticket
                                            <br />
                                                #
                                                <asp:Label ID="lblIdRevision" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                            </h6>
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Label">Motivo de la revision</asp:Label>
                                                <asp:TextBox ID="txtRevision" runat="server"
                                                    ToolTip="📝 Ingrese la informacion de forma entendible &#10;Detalle por que sera asignado este ticket a revision"
                                                    CssClass="form-control ml-2" TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                            </div>
                                            <asp:Button ID="btnConfirmarRevision" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnConfirmarRevision_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">
                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Seguimiento de Tickets</h4>
                        <asp:Button ID="btnCloseSeguimiento" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea realizar Seguimiento del ticket
                                            <br />
                                                #
                                                <asp:Label ID="lblIdSeguimiento" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                            </h6>
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Label">Motivo del Seguimiento</asp:Label>
                                                <asp:TextBox ID="txtSegumiento" runat="server"
                                                    ToolTip="📝 Ingrese la informacion de forma entendible &#10;Detalle por que sera asignado este ticket a seguimiento"
                                                    CssClass="form-control ml-2" TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                            </div>
                                            <asp:Button ID="btnConfirmarSegumiento" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnConfirmarSegumiento_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel4" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;" runat="server">
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
                                                <asp:Label ID="Label4" runat="server" Text="Label">Motivo de la Reasignacion</asp:Label>
                                                <asp:TextBox ID="txtMotivoReasignacion" runat="server"
                                                    ToolTip="📝 Ingrese la informacion de forma entendible &#10;Detalle por que sera reasignado este ticket"
                                                    CssClass="form-control ml-2" TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                            </div>
                                            <div class="form-group text-center">
                                                <telerik:RadMultiSelect ID="RadMultiSelect1" Width="95%" runat="server" DataTextField="nombre" DataValueField="ID" MaxSelectedItems="1"></telerik:RadMultiSelect>
                                            </div>
                                            <asp:Button ID="btnReasignar" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnReasignar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel5" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">

                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Reasignacion de ticket</h4>
                        <asp:Button ID="btnCloseReasignado" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Se a reasignado el ticket a:
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

            <asp:Panel ID="Panel6" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 500px;">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #17a2b8; color: white;">
                        <h4 class="modal-title text-center"><i class="fas fa-exchange-alt"></i> Reasignar Ticket a Otra Área</h4>
                        <asp:Button ID="btnCloseReasignarArea" runat="server" Text="x" class="close" aria-hidden="true" style="color: white;" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body">
                                        <div class="text-center mb-3">
                                            <h6>Reasignar Ticket #<asp:Label ID="lblIdReasignarArea" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
                                        </div>
                                        
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Label"><i class="fas fa-building"></i> Seleccionar Nueva Área:</asp:Label>
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
                                            <asp:Label ID="Label6" runat="server" Text="Label"><i class="fas fa-comment-alt"></i> Motivo de Reasignación:</asp:Label>
                                            <asp:TextBox ID="txtMotivoReasignacionArea" runat="server"
                                                ToolTip="📝 Ingrese el motivo de la reasignación de área"
                                                CssClass="form-control" TextMode="MultiLine" Height="100px"
                                                placeholder="Explique brevemente el motivo de la reasignación..."></asp:TextBox>
                                        </div>
                                        
                                        <div class="alert alert-info small">
                                            <i class="fas fa-info-circle"></i> Al reasignar el ticket, se asignará automáticamente a un técnico disponible del área seleccionada.
                                        </div>
                                        
                                        <div class="text-center">
                                            <asp:Button ID="btnConfirmarReasignarArea" class="btn btn-info" runat="server" Text="✔ Confirmar Reasignación" OnClick="btnConfirmarReasignarArea_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <div class="card-header bg-gradient-secondary">
                <h3>Asignar Porcesos a Tickets</h3>
            </div>
            <div class="card-body">
                <div class="card-header bg-light">
                    <h5 class=" text-center">Listado de tickets activos</h5>
                </div>
                <div class="form-group table-responsive">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered  " Font-Size="Small" Width="100%" CellSpacing="0" runat="server" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Procesos">
                                    <ItemTemplate>
                                        <asp:Panel ID="Panel5" runat="server"></asp:Panel>

                                        <asp:Button ID="Button1" CommandName="cerrarTicket" Text="🔐" CssClass="btn btn-link" ToolTip="Cerrar ticket" runat="server" />
                                        <asp:Button ID="Button2" CommandName="seguimientoTicket" Text="⏳" CssClass="btn btn-link" ToolTip="Seguimiento" runat="server" />
                                        <asp:Button ID="Button3" CommandName="revisionTicket" Text="📑" CssClass="btn btn-link" ToolTip="Revisión" runat="server" />
                                        <asp:Button ID="Button4" CommandName="reasignar" Text="🔄" CssClass="btn btn-link" ToolTip="Reasignar a otro técnico" runat="server" />
                                        <asp:Button ID="Button5" CommandName="reasignarArea" Text="🔀" CssClass="btn btn-link" ToolTip="Reasignar a otra área" runat="server" />

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
