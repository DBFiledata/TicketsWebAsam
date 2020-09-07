<%@ Page Language="C#" AutoEventWireup="true" Title="Buscar Ticket" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="buscarTicketNum.aspx.cs" Inherits="paginaOficial.viewsAdmin.buscarTicketNum" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="panelBuscar" runat="server" Visible="true">
                <div class="container py-5">
                    <div class="d-flex align-items-center justify-content-center">
                        <div class="col-md-8  bg-dark mt-4 pb-5 pt-5 rounded">
                            <div class="row">
                                <div class="col-md-10 mx-auto">
                                    <div class="card border-secondary">
                                        <div class="card-header">
                                            <h3 class=" text-center">Busqueda de Tickets</h3>
                                        </div>
                                        <div class="card-body">

                                            <div class="form-group">
                                                <h3 class=" text-center pt-2">Por Numero de Ticket</h3>
                                                <asp:TextBox ID="txtIdTicket" CssClass="form-control text-center"
                                                    Width="95%"
                                                    ToolTip="🎫 Deve ingresar el numero de ticket a buscar &#10;✔Al encontarlo puede realizar los siguientes procesos: &#10;🛠edicion o  🗑eliminacion"
                                                    placeholder="🎫" runat="server">
                                                </asp:TextBox>
                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnBuscarTicket" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Buscar🔎" OnClick="btnBuscar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="panelInfo" runat="server" Visible="False">
                <div class="container py-5">
                    <div class="d-flex align-items-center justify-content-center">
                        <div class="col-md-8  bg-dark pb-5 pt-5 rounded">
                            <div class="row">
                                <div class="col-md-10 mx-auto">
                                    <div class="card border-secondary">
                                        <div class="card-header">
                                            <h3 class=" text-center">Informacion del Ticket</h3>
                                        </div>
                                        <div class="card-body">
                                            <div id="sectionInfo" class="form-group">
                                                <asp:Label ID="Label6" runat="server" Text="Label">Numero de ticket:</asp:Label>
                                                <asp:Label ID="lblNumTicket" runat="server" CssClass="form-control text-center" Text="Label">numeroe ticket a mostrar</asp:Label>

                                                <asp:Label ID="Label11" runat="server" Text="Label">Datos del solicitante:</asp:Label>
                                                <asp:Label ID="lblNombreSolicitante" runat="server" CssClass="form-control text-center" Text="Label">nombre y apellido del solicitante a mostrar</asp:Label>

                                                <asp:Label ID="Label7" runat="server" Text="Datos del tecnico:"></asp:Label>
                                                <asp:Label ID="lblNombreTecnico" runat="server" CssClass="form-control text-center" Text="Label">Nombre de tecnico:</asp:Label>

                                                <asp:Label ID="Label13" runat="server" Text="Label">Datos del Agente:</asp:Label>
                                                <asp:Label ID="lblNombreAgente" runat="server" CssClass="form-control text-center" Text="Label">nombre y apellido del agente a mostrar</asp:Label>

                                                <asp:Label ID="lbl1" runat="server" Text="Label">Problema presentado:</asp:Label>
                                                <asp:TextBox ID="txtProblema" runat="server" CssClass="form-control " TextMode="MultiLine" Height="150px" Enabled="false"></asp:TextBox>

                                                <asp:Label ID="Label1" runat="server" Text="Label">Descripcion de ubicacion exacta:</asp:Label>
                                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control " TextMode="MultiLine" Height="150px" Enabled="false"></asp:TextBox>

                                                <asp:Label ID="Label19" runat="server" Text="Label">Estado del ticket:</asp:Label>
                                                <asp:Label ID="lblEstado" runat="server" CssClass="form-control text-center" Text="Label">Estado a mostrar</asp:Label>

                                                <asp:Label ID="Label3" runat="server" Text="Label">Fecha:</asp:Label>
                                                <asp:Label ID="lblfecha" runat="server" CssClass="form-control text-center" Text="Label">Fecha de estado a Mostrar</asp:Label>

                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnEditar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Editar ✔" Enabled="False" OnClick="btnEditar_Click" />
                                                <asp:Button ID="btnEliminar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Eliminar ❌" Enabled="False" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar este ticket?');" />
                                            </div>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Label ID="lblerror" runat="server" Text="" Visiblefalse="false" ForeColor="Red"></asp:Label>
                                        </div>

                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:RequiredFieldValidator CssClass="text-center" ID="RequiredFieldValidatorId" runat="server" ControlToValidate="txtIdTicket" ErrorMessage="Debe Ingresar el numero del ticket" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorId" runat="server" ControlToValidate="txtIdTicket" ErrorMessage="El numero de ticket no es valido<br/>-Solo debe contener numeros<br/>-Solo se admite numeros de hasta 6 digitos" ForeColor="Red" ValidationExpression="^([1-9]([0-9]{1,5})?)=$" Display="None"></asp:RegularExpressionValidator>

                                            <asp:ValidationSummary ID="ValidationSummary" CssClass="" runat="server" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
