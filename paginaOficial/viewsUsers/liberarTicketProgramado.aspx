<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="liberarTicketProgramado.aspx.cs" Title="Liberar Ticket Programado" MasterPageFile="~/viewsUsers/users.Master" Inherits="paginaOficial.viewsUsers.liberarTicketProgramado" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">

    <script type="text/javascript">
        function openModalInfo() {
            $('#modalInfo').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalLiberarTicket() {
            $('#modalLiberarTicket').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalResultadoTicket() {
            $('#modalResultadoTicket').modal('show');
        }
    </script>
    <script type="text/javascript">
        function mostrar(valor) {
            document.getElementById("confirmacion").style.display = (valor > "0" && valor < "5") ? "block" : "none";
        }
    </script>

    <div id="modalInfo" class="modal fade mt-2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog mt-3">
            <div class="modal-content">
                <div class=" modal-header">
                    <h4 class="modal-title text-center" id="myModalLabels">Informacion de Ticket</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 mx-auto">
                            <div class="card border-secondary">
                                <div class="card-body mt-n3">
                                    <asp:Label ID="Label6" runat="server" Text="Label">Numero de ticket:</asp:Label>
                                    <asp:Label ID="lblNumTicket" runat="server" CssClass="form-control text-center" Text="Label">numero de ticket a mostrar</asp:Label>
                                    <asp:Label ID="Label9" runat="server" Text="Label">ID de solicitante de servicio:</asp:Label>
                                    <asp:Label ID="lblIdSolicitante" runat="server" CssClass="form-control text-center" Text="Label">ID de solicitante a mostrar</asp:Label>
                                    <asp:Label ID="Label11" runat="server" Text="Label">Nombre de solicitante:</asp:Label>
                                    <asp:Label ID="lblNombreSolicitante" runat="server" CssClass="form-control text-center" Text="Label">nombre y apellido del solicitante a mostrar</asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text="Label">Problema presentado:</asp:Label>
                                    <asp:TextBox ID="txtProblema" runat="server" CssClass="form-control " TextMode="MultiLine" Height="120px" Enabled="false"></asp:TextBox>
                                    <asp:Label ID="Label7" runat="server" Text="Label">Descripcion de ubicacion exacta:</asp:Label>
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control " TextMode="MultiLine" Height="120px" Enabled="false"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server" Text="Label">Fecha a la que fue programado:</asp:Label>
                                    <asp:Label ID="lblfecha" runat="server" CssClass="form-control text-center" Text="Label">Fecha de estado a Mostrar</asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modalLiberarTicket" class="modal fade mt-5" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog mt-5">
            <div class="modal-content">
                <div class=" modal-header">
                    <h4 class="modal-title text-center">Liberar Ticket</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-10 mx-auto">
                            <div class="card border-secondary">
                                <div class="card-body mt-n3">
                                    <div class="form-group text-center">

                                        <h6>Desea liberar el ticket de estado programado?
                                            <br />
                                            #
                                                <asp:Label ID="lblIdLiberar" runat="server" Font-Size="100px" Text="Label">#</asp:Label>
                                        </h6>
                                        <div id="tipoTicket" class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Label">Tipo de ticket</asp:Label>
                                            <asp:DropDownList ID="ListTipo" CssClass="form-control" ToolTip="detalle el area a la que pertenece el ticket" runat="server" Width="95%" onchange="mostrar(this.value)">
                                                <asp:ListItem Value="0">👷‍ Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">soporte Tecnico</asp:ListItem>
                                                <asp:ListItem Value="2">Redes</asp:ListItem>
                                                <asp:ListItem Value="3">Data Center</asp:ListItem>
                                                <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="confirmacion" class="form-group" style="display: none;">
                                            <asp:Button ID="btnConfirmar" class="btn btn-primary" runat="server" Text="Aceptar ✔" OnClick="btnConfirmar_Click" />
                                            <asp:Button ID="btnCancelar" class="btn btn-secondary" runat="server" Text="Cancelar ❌" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="modalResultadoTicket" class="modal fade mt-5" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog mt-5">
            <div class="modal-content">
                <div class=" modal-header">
                    <h4 class="modal-title text-center">Eliminar de Perfil</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-10 mx-auto">
                            <div class="card border-secondary">
                                <div class="card-body mt-n3">
                                    <div class="form-group text-center">

                                        <h6>El ticket fue liberado
                                            <br />
                                            #
                                                <asp:Label ID="lblIdLiberado" runat="server" Font-Size="75px" Text="Label">#</asp:Label>
                                        </h6>
                                        <h6>El tecnico asignado fue:
                                            <br />
                                            <asp:Label ID="lblTecnico" runat="server" Text="Label">#</asp:Label>
                                        </h6>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card-header bg-gradient-secondary">
        <h3 class=" text-center">Liberar Tickets Programados</h3>
    </div>
    <div class="card-body">
        <div class="card-header bg-light text-center">
            Sus Tickets Programados
        </div>
        <div class="form-group">
            <asp:GridView ID="listTicket" class="table table-striped table-dark" runat="server" OnRowCommand="listTicket_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Procesos">
                        <ItemTemplate>
                            <asp:Button ID="Button1" CommandName="info" Text="👁‍🗨" CssClass="btn btn-link" ToolTip="Informacion detallada del ticket" runat="server" />
                            <asp:Button ID="Button2" CommandName="liberar" Text="🔓" CssClass="btn btn-link" ToolTip="liberar ticket" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
