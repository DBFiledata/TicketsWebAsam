<%@ Page Language="C#" Title="Tickets creados" MasterPageFile="~/viewsTrabajosProgramados/TrabajosProgramados.Master" CodeBehind="seguimientoDeTicketsCreadosTProgramado.aspx.cs" Inherits="paginaOficial.viewsTrabajosProgramados.seguimientoDeTicketsCreadosTProgramado" %>

<%--<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="../Scripts/sounds.js"></script>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="HiddenField1"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:HiddenField ID="HiddenField2" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpeReasignar" runat="server" PopupControlID="Panel2" TargetControlID="HiddenField2"
                CancelControlID="btnCloseReasignar"  BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Timer ID="Timer2" runat="server" OnTick="Timer2_Tick">
            </asp:Timer>

            <asp:Panel ID="Panel1" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">

                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Nuevos tickets!</h4>
                        <asp:Button ID="btnClose" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>
                                            ❗ Se han generado tickets nuevos ❗
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
                        <h4 class="modal-title text-center">Reasignar Tickets</h4>
                        <asp:Button ID="btnCloseReasignar" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea pasar el tiCket a trabajo programado
                                            <br />
                                                #
                                                <asp:Label ID="lblIdReasignar" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                            </h6>
                                            <asp:Button ID="btnReasignar" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnReasignar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>


            <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
            </asp:Timer>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Tickets activos</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="form-group">
                    <asp:GridView ID="listTickets" class="table table stacktable table-dark table-responsive" Font-Size="Small" runat="server" OnRowCommand="listTickets_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Procesos">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" CommandName="TrabajosProgrmados" Text="📤" CssClass="btn btn-link" ToolTip="Pasar ticket a trabajo programado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>--%>



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
    <script type="text/javascript">
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
                CancelControlID="btnCloseReasignar" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
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
                        <h4 class="modal-title text-center">Reasignar Tickets</h4>
                        <asp:Button ID="btnCloseReasignar" runat="server" Text="x" class="close" aria-hidden="true" />
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea pasar el ticket a trabajo programado
                                            <br />
                                                #
                                                <asp:Label ID="lblIdReasignar" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                            </h6>
                                            <asp:Button ID="btnReasignar" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnReasignar_Click" />
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
                    <h5 class=" text-center">Listado de tickets activos</h5>
                </div>
                <div class="form-group table-responsive">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" OnRowDataBound="GridView1_RowDataBound" Font-Size="Small" Width="100%" CellSpacing="0" runat="server" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Procesos">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" CommandName="revisionTicket" Text="📤" CssClass="btn btn-link" ToolTip="Revisión" runat="server" />
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

