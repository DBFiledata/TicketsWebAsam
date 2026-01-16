<%@ Page Language="C#" AutoEventWireup="true" Title="Disponibilidad" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="statusTecnicos.aspx.cs" Inherits="paginaOficial.viewsAdmin.statusTecnicos" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">

    <script type="text/javascript">
        function openModalPermisos() {
            $('#modalPermisos').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalReservas() {
            $('#modalReservas').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalVacaciones() {
            $('#modalVacaciones').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalFinalizarVacaciones() {
            $('#modalFinalizarVacaciones').modal('show');
        }
    </script>
    <script type="text/javascript">
        function openModalArea() {
            $('#modalArea').modal('show');
        }
    </script>

    <div id="modalPermisos" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center">Asignar Permiso</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div>
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>desea asignar permiso al usuario
                                            <br />
                                                Con Id:
                                                <asp:Label ID="lblIdPermiso" runat="server" Text="Label">Cedula</asp:Label><br />
                                                Con Nombre:
                                                <asp:Label ID="lblNombrePermiso" runat="server" Text="Label">nombre</asp:Label><br />
                                                tipo de tecnico:
                                                    <asp:Label ID="lblTipoPermiso" runat="server" Text="Label">nombre</asp:Label><br />
                                            </h6>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Asignar ✔" OnClick="btnAsignarPermiso_Click" />
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

    <div id="modalReservas" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center">Asignar tecnico a reserva</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div>
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Desea asignar a reserva al usuario
                                            <br />
                                                Con Id:
                                                <asp:Label ID="lblIdReserva" runat="server" Text="Label">Cedula</asp:Label><br />
                                                Con Nombre:
                                                <asp:Label ID="lblNombreReserva" runat="server" Text="Label">nombre</asp:Label><br />
                                                tipo de tecnico:
                                                    <asp:Label ID="lblTipoReserva" runat="server" Text="Label">nombre</asp:Label><br />
                                            </h6>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Asignar ✔" OnClick="btnAsignarReserva_Click" />
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

    <div id="modalVacaciones" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center">Asignar vacaciones</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div>
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>desea asignar vacaciones al usuario
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
                                            <asp:Button ID="btnAsignar" class="btn btn-primary" runat="server" Text="Asignar ✔" OnClick="btnAsignarVacacion_Click" />
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

    <div id="modalArea" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center">Asignar al Area</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div>
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>desea asignar al area al usuario
                                            <br />
                                                Con Id:
                                                <asp:Label ID="lblIdArea" runat="server" Text="Label">Cedula</asp:Label><br />
                                                Con Nombre:
                                                <asp:Label ID="lblNombreArea" runat="server" Text="Label">nombre</asp:Label><br />
                                                tipo de tecnico:
                                                    <asp:Label ID="lblTipoArea" runat="server" Text="Label">nombre</asp:Label><br />
                                            </h6>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="AsignarArea" class="btn btn-primary" runat="server" Text="Asignar ✔" OnClick="btnAsignarArea_Click" />
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

    <div id="modalFinalizarVacaciones" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center" id="myModalLabel">Liberar Tecnico</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div id="modal-content">
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>desea asignar estatus disponible al tecnico con la siguente informacion 
                                            <br />
                                                Con Id:
                                                <asp:Label ID="lblIdLiberar" runat="server" Text="Label">Cedula</asp:Label><br />
                                                Con Nombre:
                                                <asp:Label ID="lblNombreLiberar" runat="server" Text="Label">nombre</asp:Label><br />
                                                tipo de tecnico:
                                                    <asp:Label ID="lblTipoLiberar" runat="server" Text="Label">nombre</asp:Label><br />
                                            </h6>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="btnFinalizar" class="btn btn-primary" runat="server" Text="finanizar 🛑" OnClick="btnFinalizar_Click" />
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
        <h3 class=" text-center">Asignar Disponibilidad</h3>
    </div>
    <div class="card-body">
        <div class="card-header bg-light">
            <asp:Label ID="Label6" runat="server" Text="Label">Tipo de usuario</asp:Label>
            <asp:DropDownList ID="listTipo" CssClass="active" ToolTip="👷‍ Escoja el area a la que pertenecera el usuario" runat="server">
                <asp:ListItem Value="0">👥 Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Soporte Tecnico</asp:ListItem>
                <asp:ListItem Value="2">Redes</asp:ListItem>
                <asp:ListItem Value="3">Data Center</asp:ListItem>
                <asp:ListItem Value="4">Desarrollo</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Label">Nombre de usuario</asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="active" runat="server"></asp:TextBox>
            <asp:Button ID="btnfiltrar" CssClass="btn btn-success btn-lg  mr-1" ToolTip="Aplicar Filtro" runat="server" Text="🔎" OnClick="btnfiltrar_Click" />
        </div>
        <div class="form-group table-responsive">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" Width="100%" CellSpacing="0" runat="server" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Disponibilidad">
                            <ItemTemplate>
                                <asp:Button ID="btnVacaciones" CommandName="vacaciones" Text="⛴" CssClass="btn btn-link" ToolTip="Asignar Vacaciones al usuario" runat="server" />
                                <asp:Button ID="btnReservas" CommandName="reservas" Text="⏳" CssClass="btn btn-link" ToolTip="Asignar Reserva al usuario" runat="server" />
                                <asp:Button ID="btnPermisos" CommandName="permisos" Text="🏃‍" CssClass="btn btn-link" ToolTip="Asignar Permisos al usuario" runat="server" />
                                <asp:Button ID="BtnArea" CommandName="Area" Text="🟢" CssClass="btn btn-link" ToolTip="Asignar al area" runat="server" />
                                <asp:Button ID="btnFinalizarVacaciones" CommandName="finalizarVacaciones" Text="🛑" CssClass="btn btn-link" ToolTip="Liberar usuario" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

