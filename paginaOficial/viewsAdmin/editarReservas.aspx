<%@ Page Language="C#" AutoEventWireup="true" Title="Editar Reservas" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="editarReservas.aspx.cs" Inherits="paginaOficial.viewsAdmin.editarReservas" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <script type="text/javascript">
        function openModalFinalizarReservas() {
            $('#modalFinalizarReservas').modal('show');
        }
    </script>
    
    <div id="modalFinalizarReservas" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center" id="myModalLabel">Finalizar Reserva</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div id="modal-content">
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea sacar de Reserva al tecnico
                                            <br />
                                                Con Id:
                                                <asp:Label ID="lblIdVacaciones" runat="server" Text="Label">Cedula</asp:Label><br />
                                                Con Nombre:
                                                <asp:Label ID="lblNombreVacaciones" runat="server" Text="Label">nombre</asp:Label><br />
                                                tipo de tecnico:
                                                    <asp:Label ID="lblTipo" runat="server" Text="Label">nombre</asp:Label><br />
                                            </h6>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="btnFinalizar" class="btn btn-primary" runat="server" Text="finalizar 🛑" OnClick="btnFinalizar_Click" />
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

    <div class="card-header bg-gradient-secondary">
        <h3 class=" text-center">Editar Reservas de Personal Tecnico</h3>
    </div>
    <div class="card-body">
        <div class="card-header bg-light">
            <asp:Label ID="Label6" runat="server" Text="Label">Tipo de usuario</asp:Label>
            <asp:DropDownList ID="listTipo" CssClass="active" ToolTip="👷‍ Escoja el area a la que pertenecera el usuario" runat="server">
                <asp:ListItem Value="0">👥 Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Soporte</asp:ListItem>
                <asp:ListItem Value="2">Redes</asp:ListItem>
                <asp:ListItem Value="3">Data Center</asp:ListItem>
                <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                <asp:ListItem Value="9">Administrativo Tecnología</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Label">Nombre de usuario</asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="active" runat="server"></asp:TextBox>
            <asp:Button ID="btnfiltrar" CssClass="btn btn-success btn-lg  mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click" />
        </div>
        <div class="form-group table-responsive">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" Width="100%" CellSpacing="0" runat="server" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Finalizar Reservas">
                            <ItemTemplate>
                                <%--<asp:Button ID="btnEditarVacaciones" CommandName="editarvacaciones" Text="📝" CssClass="btn btn-link" ToolTip="Editar Vacaciones al usuario" runat="server" />--%>

                                <asp:Button ID="btnFinalizarReservas" CommandName="finalizarReservas" Text="🛑" CssClass="btn btn-link" ToolTip="sacar de Reservas al usuario" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

