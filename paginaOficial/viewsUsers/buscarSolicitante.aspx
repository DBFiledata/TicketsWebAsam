<%@ Page Language="C#" AutoEventWireup="true" Title="Busqueda de solicitantes" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="buscarSolicitante.aspx.cs" Inherits="paginaOficial.viewsUsers.buscarSolicitante" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container py-4">
                <div class="d-flex align-items-center justify-content-center">
                    <div class="col-md-8  bg-dark mt-2 pt-5 pb-5 rounded">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-header">
                                        <h3 class=" text-center">Búsqueda de Personal y Extensiones</h3>
                                    </div>
                                    <div class="card-body">
                                        <asp:Panel ID="panelBuscar" runat="server" Visible="true">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtIdSolicitante" CssClass="form-control text-center"
                                                    Width="95%"
                                                    ToolTip="Debe ingresar la Extensión del Solicitante para cargar su información de la planilla"
                                                    placeholder="Extensión" runat="server">
                                                </asp:TextBox>
                                            </div>


                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnBuscarSolicitante" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Buscar" OnClick="btnBuscarSolicitante_Click" />
                                            </div>

                                        </asp:Panel>

                                        <asp:Panel ID="panelInfo" runat="server" Visible="False">

                                            <div id="sectionInfo" class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Label">ID:</asp:Label>
                                                <asp:Label ID="lblId" runat="server" CssClass="form-control" Text="Label">ID a mostrar</asp:Label>
                                                <asp:Label ID="lbl1" runat="server" Text="Label">Nombre:</asp:Label>
                                                <asp:Label ID="lblNombre" runat="server" CssClass="form-control" Text="Label">apellido a mostrar</asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text="Label">Departamento:</asp:Label>
                                                <asp:Label ID="lblDepartamento" runat="server" CssClass="form-control" Text="Label">departamento a mostrar</asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text="Label">Email:</asp:Label>
                                                <asp:Label ID="lblEmail" runat="server" CssClass="form-control" Text="Label">Email a mostrar</asp:Label>
                                                <asp:Label ID="Label7" runat="server" Text="Label">Telefono:</asp:Label>
                                                <asp:Label ID="lblTelefono" runat="server" CssClass="form-control" Text="Label">Numero de Telefono a mostrar</asp:Label>
                                            </div>

                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnEditar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Editar" OnClick="btnEditar_Click" Enabled="False" CausesValidation="False" Visible="False"/>
                                                <asp:Button ID="btnEliminar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Eliminar" Enabled="False" OnClientClick="return confirm('¿Desea eliminar la cuenta?');" OnClick="btnEliminar_Click" CausesValidation="False" Visible="False"/>
                                            </div>
                                        </asp:Panel>


                                        <asp:Panel ID="PanelEditar" Visible="false" runat="server">

                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label5" runat="server" Text="Label">Id</asp:Label>
                                                    <asp:TextBox ID="txtId" CssClass="form-control"
                                                        ToolTip="Introdusca el ID (cedula) &#10;"
                                                        placeholder="📇" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label6" runat="server" Text="Label">Nombre</asp:Label>
                                                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="📝" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label8" runat="server" Text="Label">Apellido</asp:Label>
                                                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="📝" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label10" runat="server" Text="Label">Departamento</asp:Label>
                                                    <asp:TextBox ID="txtDepartamento" CssClass="form-control"
                                                        ToolTip="Introdusca el departamento del solicitante"
                                                        placeholder=" 👷 " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label11" runat="server" Text="Label">telefono</asp:Label>
                                                    <asp:TextBox ID="txtTelefono" CssClass="form-control"
                                                        ToolTip="Introdusca el ID o codigo de pocicion &#10;se encuentra en el carnet devajo del nombre"
                                                        placeholder=" 📞 " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label12" runat="server" Text="Label">Email</asp:Label>
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" ToolTip="Introdusca su email"
                                                        placeholder="📧" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnEdicion" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Editar ✔" Enabled="False" OnClick="btnEdicion_Click" />
                                                <asp:Button ID="btnCancelar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Cancelar ❌" Enabled="False" OnClick="btnCancelar_Click" CausesValidation="False" />
                                            </div>

                                        </asp:Panel>


                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Label ID="lblerror" runat="server" Text="" Visiblefalse="false" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <%-- validaciones de busqueda --%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdBuscar" runat="server" ControlToValidate="txtIdSolicitante" ErrorMessage="Debe Ingresar un Id" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
<%--                                            <asp:RegularExpressionValidator ID="RegularExpressionIdBuscar" runat="server" ControlToValidate="txtIdSolicitante" ErrorMessage="El Id no concuerda con un numero de cedula valido" ForeColor="Red" ValidationExpression="^(PE|E|N|[23456789](?:AV|PI)?|1[0123]?(?:AV|PI)?)-(\d{1,4})-(\d{1,6})$" Display="None"></asp:RegularExpressionValidator>--%>
                                            <%-- validaciones de edicion --%>
                                            <asp:RequiredFieldValidator CssClass="text-center" ID="RequiredFieldValidatorId" Enabled="false" runat="server" ControlToValidate="txtId" ErrorMessage="Debe Ingresar un Id" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidatorId" Enabled="false" runat="server" ControlToValidate="txtId" ErrorMessage="El Id no concuerda con un numero de cedula valido" ForeColor="Red" ValidationExpression="^(PE|E|N|[23456789](?:AV|PI)?|1[0123]?(?:AV|PI)?)-(\d{1,4})-(\d{1,6})$" Display="None"></asp:RegularExpressionValidator>--%>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdNombre" Enabled="false" runat="server" ErrorMessage="Debe ingresar el nombre" ControlToValidate="txtNombre" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" Enabled="false" runat="server" ErrorMessage="Debe ingresar el Apellido" ControlToValidate="txtApellido" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepartamento" Enabled="false" runat="server" ErrorMessage="Debe ingresar el departamento" ControlToValidate="txtDepartamento" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" Enabled="false" runat="server" ErrorMessage="Debe ingresar un numero de telefono" ControlToValidate="txtTelefono" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatortelefono" Enabled="false" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El numero de telefono no es valido" ForeColor="Red" ValidationExpression="^(([6]([0-9]{7}))|([6]([0-9]{3})-([0-9]{4}))|([2|3|5|8]([0-9]{6}))|([2|3|5|8]([0-9]{2})-([0-9]{4}))|([1-9]{4}))$" Display="None"></asp:RegularExpressionValidator>

                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
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
