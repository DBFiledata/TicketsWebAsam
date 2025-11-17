<%@ Page Language="C#" AutoEventWireup="true" Title="Generar Tickets" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="editarTicket.aspx.cs" Inherits="paginaOficial.viewsAdmin.editarTicket" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <script type="text/javascript">
        function mostrar(valor) {
            document.getElementById("fechaProgramacion").style.display = (valor == "4") ? "block" : "none";
            document.getElementById("idTecnico").style.display = (valor == "1") ? "block" : "none";
        }
    </script>

    <div class="container py-4">
        <div class="d-flex align-items-center justify-content-center">
            <div class="col-md-8  bg-dark pb-4 pt-3 rounded">
                <div class="row">
                    <div class="col-md-10 mx-auto">
                        <div class="card border-secondary">
                            <div class="card-header">
                                <h3 class="mb-0 my-1 text-center">Editar Ticket</h3>
                            </div>
                            <div class="card-body">

                                <div id="informacionTicket">

                                    <asp:Panel ID="panelInfo" runat="server">

                                        <div id="sectionInfo" class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Label">Numero de ticket:</asp:Label>
                                            <asp:Label ID="lblNumTicket" runat="server" Width="95%" CssClass="form-control text-center" Text="Label">numero del ticket a mostrar</asp:Label><br />

                                            <asp:Label ID="Label4" runat="server" Text="Label">Id del solicitante:</asp:Label>
                                            <asp:Label ID="lblIdSolicitante" runat="server" Width="95%" CssClass="form-control text-center" Text="Label">numero del ticket a mostrar</asp:Label><br />

                                            <asp:Label ID="Label9" runat="server" Text="Label">Id del Agente:</asp:Label>
                                            <asp:Label ID="lblIdAgente" runat="server" Width="95%" CssClass="form-control text-center" Text="Label">numero del ticket a mostrar</asp:Label><br />

                                            <asp:Label ID="Label3" runat="server" Text="Label">Id del Tecnico:</asp:Label>
                                            <asp:Label ID="lblIdTecnico" runat="server" Width="95%" CssClass="form-control text-center" Text="Label">id del ticket a mostrar</asp:Label><br />
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" Text="Label">Detalle de lugar exacto</asp:Label>
                                            <asp:TextBox ID="txtDetallePocicion" runat="server"
                                                ToolTip="🏙 ingrese informacion sobre la ubicacion exacta&#10;🎯 procure que su informacion sea precisa y correcta&#10;🧭 para que el personal tecnico pueda ubicar el lugar facilmente"
                                                CssClass="form-control " TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Label">Detalle de problemas Que se esta presentando</asp:Label>
                                            <asp:TextBox ID="txtProblema" runat="server"
                                                ToolTip="📝 ingrese la informacion de forma entendible &#10;🎯 procure que la informacion sea precisa y correcta &#10;👨‍💻 para que el personal tecnico este correctamente informado del problema"
                                                CssClass="form-control " TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Label">Estado del Ticket</asp:Label>
                                            <asp:DropDownList ID="listTipo" CssClass="form-control" runat="server" Width="95%" onchange="mostrar(this.value)">
                                                <asp:ListItem Value="0">🎫 Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">creado</asp:ListItem>
                                                <asp:ListItem Value="2">En atencion</asp:ListItem>
                                                <asp:ListItem Value="3">Atendido</asp:ListItem>
                                                <asp:ListItem Value="4">Programado</asp:ListItem>
                                                <asp:ListItem Value="5">finalizado</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                            <div id="fechaProgramacion" style="display: none;">
                                                <asp:Label ID="Label5" runat="server" Text="Label">Fecha de Atencion estimada</asp:Label>
                                                <asp:TextBox class="form-control" ID="txtfecha" runat="server" ToolTip="📅 Ingrese la fecha en que se atendera el ticket" TextMode="Date" Width="95%"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div id="idTecnico" style="display: none;">
                                                <asp:Label ID="Label7" runat="server" Text="Label">Id de tecnico a asignar</asp:Label>
                                                <asp:TextBox ID="txtIdTecnico" CssClass="form-control text-center"
                                                    Width="95%" ToolTip="Id del solicitante" runat="server">
                                                </asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Button ID="btnActualizar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Actualizar✔" OnClick="btnActualizar_Click" />
                                            <asp:Button ID="btnCancelar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Cancelar ❌" OnClick="btnCancelar_Click" />
                                        </div>
                                        
                                    </asp:Panel>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
