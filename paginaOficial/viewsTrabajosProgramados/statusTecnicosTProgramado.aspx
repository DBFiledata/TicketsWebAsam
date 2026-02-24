<%@ Page Language="C#" AutoEventWireup="true" Title="Disponibilidad del Personal" MasterPageFile="~/viewsTrabajosProgramados/TrabajosProgramados.Master" CodeBehind="statusTecnicosTProgramado.aspx.cs" Inherits="paginaOficial.viewsTrabajosProgramados.statusTecnicosTProgramado" %>

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
        function openModalEditarDisponibilidad() {
            $('#modalEditarDisponibilidad').modal('show');
        }
    </script>

    <script type="text/javascript">
        function mostrarAlerta(mensaje, tipo) {
            // tipo puede ser: success, danger, warning, info
            var alertClass = 'alert-' + tipo;
            var iconClass = tipo === 'success' ? 'fa-check-circle' : 
                           tipo === 'danger' ? 'fa-exclamation-circle' : 
                           tipo === 'warning' ? 'fa-exclamation-triangle' : 
                           'fa-info-circle';
            
            var alertHtml = '<div class="alert ' + alertClass + ' alert-dismissible fade show position-fixed" role="alert" style="top: 20px; right: 20px; z-index: 9999; min-width: 300px; box-shadow: 0 4px 6px rgba(0,0,0,0.1);">' +
                '<i class="fas ' + iconClass + ' mr-2"></i>' +
                '<strong>' + mensaje + '</strong>' +
                '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span>' +
                '</button>' +
                '</div>';
            
            $('body').append(alertHtml);
            
            // Auto cerrar después de 4 segundos
            setTimeout(function() {
                $('.alert').fadeOut(500, function() {
                    $(this).remove();
                });
            }, 4000);
        }

        function toggleFechaRetorno() {
            var disponibilidad = $('#<%= ddlDisponibilidad.ClientID %>').val();
            var divFecha = $('#divFechaRetorno');
            var txtFecha = $('#<%= txtFechaRetorno.ClientID %>');
            
            // Mostrar campo de fecha solo para: Ocupado(2), Permiso(3), Vacaciones(4), Reserva(5), Trabajo Programado(7)
            if (disponibilidad == '2' || disponibilidad == '3' || disponibilidad == '4' || 
                disponibilidad == '5' || disponibilidad == '7') {
                divFecha.slideDown(300);
                
                // Sugerir fecha por defecto según el tipo
                var now = new Date();
                var sugerencia = new Date(now);
                
                switch(disponibilidad) {
                    case '2': // Ocupado - sugerir 2 horas
                        sugerencia.setHours(now.getHours() + 2);
                        break;
                    case '3': // Permiso - sugerir 4 horas
                        sugerencia.setHours(now.getHours() + 4);
                        break;
                    case '4': // Vacaciones - sugerir 7 días
                        sugerencia.setDate(now.getDate() + 7);
                        break;
                    case '5': // Reserva - sugerir 1 día
                        sugerencia.setDate(now.getDate() + 1);
                        break;
                    case '7': // Trabajo Programado - sugerir 3 horas
                        sugerencia.setHours(now.getHours() + 3);
                        break;
                }
                
                // Formatear fecha para input datetime-local (YYYY-MM-DDTHH:MM)
                var year = sugerencia.getFullYear();
                var month = String(sugerencia.getMonth() + 1).padStart(2, '0');
                var day = String(sugerencia.getDate()).padStart(2, '0');
                var hours = String(sugerencia.getHours()).padStart(2, '0');
                var minutes = String(sugerencia.getMinutes()).padStart(2, '0');
                
                txtFecha.val(year + '-' + month + '-' + day + 'T' + hours + ':' + minutes);
            } else {
                divFecha.slideUp(300);
                txtFecha.val('');
            }
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
                                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Asignar" OnClick="btnAsignarPermiso_Click" />
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
                                            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Asignar" OnClick="btnAsignarReserva_Click" />
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
                                            <asp:Button ID="btnAsignar" class="btn btn-primary" runat="server" Text="Asignar" OnClick="btnAsignarVacacion_Click" />
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
                                            <asp:Button ID="btnFinalizar" class="btn btn-primary" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click" />
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

    <div id="modalEditarDisponibilidad" class="modal fade mt-1 col-12" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title text-center">Editar Disponibilidad</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                </div>
                <div class="modal-body mt-n3">
                    <div>
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-body mt-n3">
                                        <div class="form-group text-center">
                                            <h6>Actualizar disponibilidad del usuario
                                            <br />
                                                Con Id:
                                                <asp:Label ID="lblIdDisponibilidad" runat="server" Text="Label">Cedula</asp:Label><br />
                                                Con Nombre:
                                                <asp:Label ID="lblNombreDisponibilidad" runat="server" Text="Label">nombre</asp:Label><br />
                                                Tipo de tecnico:
                                                <asp:Label ID="lblTipoDisponibilidad" runat="server" Text="Label">nombre</asp:Label><br />
                                            </h6>
                                        </div>
                                        <div class="form-group">
                                            <label for="ddlDisponibilidad">Seleccione la disponibilidad:</label>
                                            <asp:DropDownList ID="ddlDisponibilidad" runat="server" CssClass="form-control" onchange="toggleFechaRetorno()">
                                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                                <asp:ListItem Value="2">Ocupado</asp:ListItem>
                                                <asp:ListItem Value="3">Permiso</asp:ListItem>
                                                <asp:ListItem Value="4">Vacaciones</asp:ListItem>
                                                <asp:ListItem Value="5">Reserva</asp:ListItem>
                                                <asp:ListItem Value="6">En el Area</asp:ListItem>
                                                <asp:ListItem Value="7">Trabajo Programado</asp:ListItem>
                                                <asp:ListItem Value="8">Instalación</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group" id="divFechaRetorno" style="display: none;">
                                            <label for="txtFechaRetorno">
                                                <i class="fas fa-calendar-alt mr-2"></i>Fecha y hora de retorno automático a "Activo":
                                            </label>
                                            <asp:TextBox ID="txtFechaRetorno" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                                            <small class="form-text text-muted">
                                                El usuario volverá automáticamente a estado "Activo" en esta fecha
                                            </small>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="btnGuardarDisponibilidad" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarDisponibilidad_Click" />
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
        <h3 class=" text-center">Control de Disponibilidad - Mi Area</h3>
    </div>
    <div class="card-body">
        <div class="card-header bg-light">
            <asp:Label ID="Label1" runat="server" Text="Label">Nombre de usuario</asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="active" runat="server"></asp:TextBox>
            <asp:Button ID="btnfiltrar" CssClass="btn btn-success btn-lg mr-1" ToolTip="Aplicar Filtro" runat="server" Text="Filtrar" OnClick="btnfiltrar_Click" />
        </div>
        <div class="form-group table-responsive">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-dark table-bordered" Width="100%" CellSpacing="0" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEditarDisponibilidad" CommandName="editarDisponibilidad" CssClass="btn btn-primary btn-sm" ToolTip="Editar disponibilidad" runat="server">
                                    <i class="fas fa-pencil-alt"></i> Editar disponibilidad
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
