<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" MasterPageFile="~/viewsPruebas/Site1.Master" Inherits="paginaOficial.viewsPruebas.WebForm5" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container py-1 pb-2 ">
                <div class="d-flex align-items-center justify-content-center">
                    <div class="col-md-12  bg-dark mt-2 pb-5 pt-5 rounded">
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-header">
                                        <h3 class=" text-center">Solicitud</h3>
                                    </div>
                                    <div class="card-body">
                                        <asp:Panel ID="Panel1" Enabled="false" runat="server">
                                            <div id="sectionInfo" class="form-group">

                                                <asp:Label ID="Label11" runat="server" Text="Label">Numero de solicitud</asp:Label>
                                                <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="📝" runat="server"></asp:TextBox>

                                                <asp:Label ID="Label12" runat="server" Text="Label">Descripción</asp:Label>
                                                <asp:TextBox ID="txtApellido" TextMode="MultiLine" Height="100px" CssClass="form-control" placeholder="📝" runat="server"></asp:TextBox>


                                                <asp:Label ID="Label1" runat="server" Text="Label">Unidad solicitante:</asp:Label>
                                                <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control" Text=""></asp:TextBox>

                                                <asp:Label ID="Label3" runat="server" Text="Label">Fecha:</asp:Label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text=""></asp:TextBox>

                                                <asp:Label ID="Label7" runat="server" Text="Label">Documento:</asp:Label>
                                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />

                                            </div>
                                            <div class="form-group d-flex align-items-center justify-content-center">
                                                <asp:Button ID="btnRegistrar" CssClass="btn  btn-lg float-right mr-1 text-light" Width="155px" Style="background-color: green" runat="server" Text="mover ↗️" />
                                            </div>
                                        </asp:Panel>
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

