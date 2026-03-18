
<%@ Page Language="C#" AutoEventWireup="true" Title="Generar Tickets" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="generarTicketsUsers.aspx.cs" Inherits="paginaOficial.viewsCompartidas.generarTicketsUsers" Async="true" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function showProgramacion(elemento) {
            var contenido = document.getElementById("fechaProgramacion");
            var contenido2 = document.getElementById("tipoTicket");
            contenido.style.display = elemento.checked ? "block" : "none";
            contenido2.style.display = elemento.checked ? "none" : "block";
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container py-4">
                <div class="d-flex align-items-center justify-content-center">
                    <div class="col-md-8  bg-dark mt-2 pt-3 pb-4 rounded">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-header">
                                        <h3 class="mb-0 my-1 text-center">Generar Ticket</h3>
                                    </div>
                                    <div class="card-body">
                                        <asp:Panel ID="panelBuscar" runat="server">
                                            <div class="form-group">
                                                <asp:Label ID="Label9" runat="server" Text="Label">Id de solicitante</asp:Label>

                                                <div class=" d-flex align-items-center justify-content-center">
                                                    <asp:TextBox ID="txtIdSolicitante" runat="server" placeholder="ID Solicitante"
                                                        ToolTip="Ingrese el id del solicitante de servicio tecnico"
                                                        CssClass="form-control text-center" Width="95%"></asp:TextBox>
                                                    <asp:Button ID="btnSolicitanteNuevo" runat="server" CssClass="btn btn-primary float-right form-control w-auto" Text="Ultimo" Enabled="false" Visible="false" OnClick="btnSolicitanteNuevo_Click" CausesValidation="false" />
                                                </div>
                                                <div class=" d-flex align-items-center justify-content-center">
                                                    <asp:Button ID="btnBuscarInfo" CssClass="btn btn-success float-right form-control mt-2 w-auto" runat="server" Text="Buscar informacion" OnClick="btnBuscarInfo_Click"/>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                        <asp:Panel ID="panelInfo" runat="server" Visible="False">
                                            <div class="form-group">
                                                <div id="sectionInfo" class="form-group">


                                                    <asp:Label ID="Label11" runat="server" Text="Label">Nombre</asp:Label>
                                                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>

                                                    <asp:Label ID="Label12" runat="server" Text="Label">Apellido</asp:Label>
                                                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Apellido" runat="server" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>


                                                    <asp:Label ID="Label1" runat="server" Text="Label">Departamento:</asp:Label>
                                                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control" Text="" Width="95%" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>

                                                    <asp:Label ID="Label3" runat="server" Text="Label">Email:</asp:Label>
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text="" Width="95%" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>

                                                    <asp:Label ID="Label7" runat="server" Text="Label">Telefono:</asp:Label>
                                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Text="" Width="95%" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>

                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="Label8" runat="server" Text="Label">Detalle de lugar exacto</asp:Label>
                                                    <asp:TextBox ID="txtDetallePocicion" runat="server"
                                                        ToolTip="Ingrese informacion sobre la ubicacion exacta&#10;Procure que su informacion sea precisa y correcta&#10;Para que el personal tecnico pueda ubicar el lugar facilmente"
                                                        CssClass="form-control " TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="Label2" runat="server" Text="Label">Detalle de problemas que se esta presentando</asp:Label>
                                                    <asp:TextBox ID="txtProblema" runat="server"
                                                        ToolTip="Ingrese la informacion de forma entendible&#10;Procure que la informacion sea precisa y correcta&#10;Para que el personal tecnico este correctamente informado del problema"
                                                        CssClass="form-control " TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:CheckBox ID="checkFechaProgramacion" runat="server" Text="Programar ticket a una fecha de atencion" onclick="showProgramacion(this)"
                                                        ToolTip="Selecione esta opcion si este ticket no sera atendido el dia de hoy para programar el ticket a una fecha posterior" />
                                                    <div id="fechaProgramacion" style="display: none;">
                                                        <asp:Label ID="Label4" runat="server" Text="Label">Fecha de Atencion estimada</asp:Label>
                                                        <asp:TextBox class="form-control" ID="txtfecha" runat="server" ToolTip="Ingrese la fecha en que se atendera el ticket" TextMode="Date" Width="95%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="tipoTicket" class="form-group">
                                                    <asp:Label ID="Label6" runat="server" Text="Label">Tipo de ticket</asp:Label>
                                                    <asp:DropDownList ID="ListTipo" CssClass="form-control" ToolTip="Detalle el area a la que pertenece el ticket" runat="server" Width="95%">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        <asp:ListItem Value="1">Soporte tecnico</asp:ListItem>
                                                        <asp:ListItem Value="2">Redes</asp:ListItem>
                                                        <asp:ListItem Value="3">Data center</asp:ListItem>
                                                        <asp:ListItem Value="4">Desarrollo</asp:ListItem>
                                                        <asp:ListItem Value="9">Administrativo Tecnología</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <asp:CheckBox ID="CheckArea" runat="server" Text="Ticket solicitado desde el Area Revertida" 
                                                        ToolTip="Selecione esta opcion si este ticket ha sido una solicitud del Area Revertida" />
                                                <div class="form-group d-flex align-items-center justify-content-center">
                                                    <asp:Button ID="btnRegistrar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
                                                    <asp:Button ID="btnCancelar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </asp:Panel>


                                        <asp:Panel ID="panelResultado" runat="server" Visible="False">
                                            <div class="form-group">
                                                <div>
                                                    <h5 class="active text-center">Ticket creado exitosamente</h5>
                                                </div>
                                                <asp:Label ID="label5" CssClass="form-control text-center mt-3" runat="server" Text="Numero de ticket"></asp:Label>
                                                <div>
                                                    <asp:Label ID="lblNum" CssClass="form-control text-center" runat="server" Text="# 0000" Font-Size="100px"></asp:Label>
                                                </div>
                                                <div>
                                                    <div class="d-flex align-items-center justify-content-center">
                                                        <asp:Label ID="lblresultado" CssClass="text-center" runat="server" Text="Ticket asignado a:"></asp:Label>
                                                    </div>
                                                    <asp:Label ID="lblTecnico" CssClass="form-control text-center" runat="server" Text="nombre de tecnico"></asp:Label>
                                                </div>
                                                <div class="form-group d-flex align-items-center justify-content-center">
                                                    <asp:Button ID="btnContinuar" CssClass="btn btn-success btn-lg float-right mr-1 mt-4" runat="server" Text="Continuar" OnClick="btnContinuar_Click" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Label ID="lblerror" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Label ID="lblValidadorFecha" runat="server" Text=""></asp:Label>
                                            <asp:RequiredFieldValidator CssClass="text-center" ID="RequiredFieldValidatorId" runat="server" ControlToValidate="txtIdSolicitante" ErrorMessage="Debe ingresar un id" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                            <asp:ValidationSummary ID="ValidationSummary" CssClass="" runat="server" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

