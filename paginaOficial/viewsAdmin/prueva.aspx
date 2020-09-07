<%@ Page Language="C#" AutoEventWireup="true" Title="Inicio" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="prueva.aspx.cs" Inherits="paginaOficial.viewsAdmin.prueva" %>


<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style type="text/css">
        /*.modal-header {
            background-color: #f0f0f0;
        }

        .modal-footer {
            background-color: #f0f0f0;
        }

        .form-control1, .form-control_2.input-sm {
            width: 35%;
        }

        .col-sm-8 {
            width: 35%;
        }

        .input-group {
            margin: 0 0 0 13em;
        }

        .form-control1, .form-control_2.input-sm {
            -moz-appearance: meterchunk;
            height: 30px;
            width: 158px;
        }

        tr {
            max-height: 35px !important;
            height: 35px !important;
            overflow: hidden;
        }

        .btn-info {
            padding: 2px 10px;
        }

        .table td, .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
            padding: 5px !important;
            width: 10px;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modal-dialog {
            margin: -41px auto;
            position: relative;
            width: auto;
        }

        .modal-body {
            padding: 29px;
            position: relative;
        }*/
        

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

        // Modal background
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
            <div class="xs tabls">
                <div class="bs-example4" data-example-id="contextual-table">
                    <div style="margin-bottom: 11px" class="row">
                        <div class="col-md-2">
                            <asp:Button ID="btnCreateState" runat="server" Text="Create State" CssClass="btn btn-sm btn-info" />
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:Repeater ID="rptState" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th style="width: auto">#</th>
                                            <th>Sr.No</th>
                                            <th>State Name</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <th scope="row"></th>
                                        <td><%#Container.ItemIndex+1 %></td>
                                        <td><%#Eval("Name") %></td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <asp:HiddenField ID="HiddenField1" runat="server" />
            <!-- ModalPopupExtender -->
            <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="HiddenField1"
                CancelControlID="btnClose"  BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Timer ID="Timer1" runat="server" Interval="20000" OnTick="Timer1_Tick">
            </asp:Timer>
            <div class="card-body">
                <div class="card-header bg-light">
                    <h5 class=" text-center">Listado de tickets activos</h5>
                </div>
                <div class="form-group table-responsive">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered  " Font-Size="Small" Width="100%" CellSpacing="0" runat="server" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Manteniniento">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" CommandName="info" Text="👁‍🗨" CssClass="btn btn-link" ToolTip="Informacion detallada del ticket" runat="server" />

                                        <asp:Button ID="Button2" CommandName="cerrarTicket" Text="🔐" CssClass="btn btn-link" ToolTip="Cerrar ticket" runat="server" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="modal-dialog" align="center" Style="display: none; width: 600px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="exampleModalLabel">Create State</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <asp:Label ID="Label6" runat="server" Text="Label">Numero de ticket:</asp:Label>
                                        <asp:Label ID="lblNumTicket" runat="server" CssClass="form-control text-center" Text="Label">numero de ticket a mostrar</asp:Label>



                                        <asp:Label ID="Label9" runat="server" Text="Label">Datos del solicitante de servicio:</asp:Label>
                                        <asp:Label ID="lblIdSolicitante" runat="server" CssClass="form-control text-center" Text="Label">ID de solicitante a mostrar</asp:Label>



                                        <asp:Label ID="Label4" runat="server" Text="Datos del tecnico asignado:"></asp:Label>
                                        <asp:Label ID="lblIdTecnico" runat="server" CssClass="form-control text-center" Text="Label">id de tecnico a mostrar</asp:Label>


                                        <asp:Label ID="Label2" runat="server" Text="Label">Datos de Agente que genero el ticket:</asp:Label>
                                        <asp:Label ID="lblIdAgente" runat="server" CssClass="form-control text-center" Text="Label">id de agnete a mostrar</asp:Label>


                                        <asp:Label ID="Label5" runat="server" Text="Label">Problema presentado:</asp:Label>
                                        <asp:TextBox ID="txtProblema" runat="server" CssClass="form-control " TextMode="MultiLine" Height="120px" Enabled="false"></asp:TextBox>

                                        <asp:Label ID="Label7" runat="server" Text="Label">Descripcion de ubicacion exacta:</asp:Label>
                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control " TextMode="MultiLine" Height="120px" Enabled="false"></asp:TextBox>

                                        <asp:Label ID="Label19" runat="server" Text="Label">Estado del ticket:</asp:Label>
                                        <asp:Label ID="lblEstado" runat="server" CssClass="form-control text-center" Text="Label">Estado a mostrar</asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Label">Fecha:</asp:Label>
                                        <asp:Label ID="lblfecha" runat="server" CssClass="form-control text-center" Text="Label">Fecha de estado a Mostrar</asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <asp:Button Style="float: left" ID="btnSave" ValidationGroup="SaveState" runat="server" Text="Save" class="btn btn-primary" UseSubmitBehavior="false" data-dismiss="modal" />
                        <asp:Button Style="float: left" ID="btnClose" class="btn btn-primary" runat="server" Text="Close" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
