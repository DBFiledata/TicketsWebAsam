<%@ Page Language="C#" AutoEventWireup="true" Title="Tickets creados" MasterPageFile="~/viewsMonitoreo/monitoreo.Master"  CodeBehind="seguimientoTicketsCreados.aspx.cs" Inherits="paginaOficial.viewsMonitoreo.seguimientoTicketsCreados" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <script src="../Scripts/sounds.js"></script>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="HiddenField1"
                CancelControlID="btnClose" OnCancelScript="iniciarTimer();" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Timer ID="Timer2" runat="server" OnTick="Timer2_Tick">
            </asp:Timer>

            <asp:Panel ID="Panel1" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">

                <div class="modal-content">
                    <div class=" modal-header">
                        <h4 class="modal-title text-center">Nuevo ticket!</h4>
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

            <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
            </asp:Timer>
            <div class="card-header bg-gradient-secondary">
                <h3 class=" text-center">Tickets activos</h3>
            </div>
            <div id="contenido" class="card-body">
                <div class="form-group">
                    <asp:GridView ID="listTickets" OnRowDataBound="listTickets_RowDataBound" class="table table stacktable table-dark table-responsive" Font-Size="Small" runat="server"></asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

