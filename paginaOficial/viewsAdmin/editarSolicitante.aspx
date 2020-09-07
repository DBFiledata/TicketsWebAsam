<%@ Page Language="C#" Title="Editar Solicitantes" MasterPageFile="~/viewsAdmin/admin.Master" AutoEventWireup="true" CodeBehind="editarSolicitante.aspx.cs" Inherits="paginaOficial.viewsAdmin.editarSolicitante" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <div class="container py-1">
        <div class="d-flex align-items-center justify-content-center">
            <div class="col-md-10  bg-dark mt-3 pb-4 pt-4 mb-2 rounded">
                <div class="row">
                    <div class="col-md-10 mx-auto">
                        <div class="card border-secondary">
                            <div class="card-header">
                                <h3 class=" text-center">Editar Perfil</h3>
                            </div>
                            <div class="card-body">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Label">ID</asp:Label>
                                    <asp:TextBox ID="txtId" CssClass="form-control"
                                        ToolTip="Introdusca el ID (cedula) &#10;"
                                        placeholder="📇" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Label">Nombre</asp:Label>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Label">Apellido</asp:Label>
                                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Label">Departamento</asp:Label>
                                    <asp:TextBox ID="txtDepartemento" CssClass="form-control"
                                        ToolTip="Introdusca su codigo de pocicion &#10;"
                                        runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group d-flex align-items-center justify-content-center">
                                    <div class="form-group col-6">
                                        <asp:Label ID="Label9" runat="server" Text="Label">telefono</asp:Label>
                                        <asp:TextBox ID="txtTelefono" CssClass="form-control"
                                            ToolTip="Introdusca el ID o codigo de pocicion &#10;se encuentra en el carnet devajo del nombre"
                                            placeholder=" 📞 " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-6">
                                        <asp:Label ID="Label3" runat="server" Text="Label">Email</asp:Label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" ToolTip="Introdusca su email"
                                            placeholder="📧" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group d-flex align-items-center justify-content-center">
                                    <asp:Button ID="btnEditar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Editar ✔" OnClick="btnEditar_Click" />
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Cancelar ❌" OnClick="btnCancelar_Click" CausesValidation="False"/>
                                </div>
                            </div>
                            <div class="form-group d-flex align-items-center justify-content-center">
                                <asp:Label ID="lblerror" runat="server" Text="" Visiblefalse="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-group d-flex align-items-center justify-content-center">
                                <asp:RequiredFieldValidator CssClass="text-center" ID="RequiredFieldValidatorId" runat="server" ControlToValidate="txtId" ErrorMessage="Debe Ingresar un Id" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorId" runat="server" ControlToValidate="txtId" ErrorMessage="El Id no concuerda con un numero de cedula valido" ForeColor="Red" ValidationExpression="^(PE|E|N|[23456789](?:AV|PI)?|1[0123]?(?:AV|PI)?)-(\d{1,4})-(\d{1,6})$" Display="None"></asp:RegularExpressionValidator>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdNombre" runat="server" ErrorMessage="Debe ingresar el nombre" ControlToValidate="txtNombre" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ErrorMessage="Debe ingresar el Apellido" ControlToValidate="txtApellido" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepartemento" runat="server" ErrorMessage="Debe ingresar el departamento" ControlToValidate="txtDepartemento" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" ErrorMessage="Debe ingresar un numero de telefono" ControlToValidate="txtTelefono" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatortelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El numero de telefono no es valido" ForeColor="Red" ValidationExpression="^(([6]([0-9]{7}))|([6]([0-9]{3})-([0-9]{4}))|([2|3|5|8]([0-9]{6}))|([2|3|5|8]([0-9]{2})-([0-9]{4}))|([1-9]{4}))$" Display="None"></asp:RegularExpressionValidator>

                                <asp:ValidationSummary ID="ValidationSummary" CssClass="" runat="server" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

