<%@ Page Language="C#" AutoEventWireup="true" Title="Registro de Solicitantes" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="registroSolicitantes.aspx.cs" Inherits="paginaOficial.viewsUsers.registroSolicitantes" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container py-1 pb-2 ">
                <div class="d-flex align-items-center justify-content-center">
                    <div class="col-md-12 bg-dark mt-5 mb-1 pb-5 pt-5 pl-5 pr-5 rounded">
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-header">
                                        <h3 class=" text-center">Registro de Solicitantes</h3>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label1" runat="server" Text="Label">Id</asp:Label>
                                                    <asp:TextBox ID="txtId" CssClass="form-control"
                                                        ToolTip="Introdusca el ID (cedula) &#10;"
                                                        placeholder="📇" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label2" runat="server" Text="Label">Nombre</asp:Label>
                                                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="📝" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label4" runat="server" Text="Label">Apellido</asp:Label>
                                                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="📝" runat="server"></asp:TextBox>
                                                </div>
                                            </div>


                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label7" runat="server" Text="Label">Departamento</asp:Label>
                                                    <asp:TextBox ID="txtDepartamento" CssClass="form-control"
                                                        ToolTip="Introdusca el departamento del solicitante"
                                                        placeholder=" 👷 " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label9" runat="server" Text="Label">telefono</asp:Label>
                                                    <asp:TextBox ID="txtTelefono" CssClass="form-control"
                                                        ToolTip="Introdusca el numero de telefono (sin guiones)&#10;telefono fijo, linea interna, celular..."
                                                        placeholder=" 📞 " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label3" runat="server" Text="Label">Email</asp:Label>
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" ToolTip="Introdusca el email(opcional)"
                                                        placeholder="📧" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnRegistrar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Registrar ✔" OnClick="btnRegistrar_Click" />
                                                <asp:Button ID="btnCancelar" CssClass="btn btn-danger btn-lg float-right ml-1" runat="server" Text="Cancelar ❌" OnClick="btnCancelar_Click" CausesValidation="False" />
                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Label ID="lblerror" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:RequiredFieldValidator CssClass="text-center" ID="RequiredFieldValidatorId" runat="server" ControlToValidate="txtId" ErrorMessage="Debe Ingresar un Id" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidatorId" runat="server" ControlToValidate="txtId" ErrorMessage="El Id no concuerda con un numero de cedula valido" ForeColor="Red" ValidationExpression="^(PE|E|N|[23456789](?:AV|PI)?|1[0123]?(?:AV|PI)?)-(\d{1,4})-(\d{1,6})$" Display="None"></asp:RegularExpressionValidator>--%>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdNombre" runat="server" ErrorMessage="Debe ingresar el nombre" ControlToValidate="txtNombre" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ErrorMessage="Debe ingresar el Apellido" ControlToValidate="txtApellido" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar el departamento" ControlToValidate="txtDepartamento" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar un numero de telefono" ControlToValidate="txtTelefono" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatortelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El numero de telefono no es valido" ForeColor="Red" ValidationExpression="^(([6]([0-9]{7}))|([6]([0-9]{3})-([0-9]{4}))|([2|3|5|8]([0-9]{6}))|([2|3|5|8]([0-9]{2})-([0-9]{4}))|([1-9]{4}))$" Display="None"></asp:RegularExpressionValidator>

                                                <asp:ValidationSummary ID="ValidationSummary" CssClass="" runat="server" ForeColor="Red" />
                                            </div>
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
