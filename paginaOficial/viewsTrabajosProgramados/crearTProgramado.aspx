<%@ Page Language="C#" AutoEventWireup="true" Title="Generar Trabajo Programado" MasterPageFile="~/viewsTrabajosProgramados/TrabajosProgramados.Master" CodeBehind="crearTProgramado.aspx.cs" Inherits="paginaOficial.viewsTrabajosProgramados.crearTProgramado" Async="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
            <div class="container py-1 pb-3">
                <div class="d-flex align-items-center justify-content-center">
                    <div class="col-md-8  bg-dark mt-1 pt-3 pb-3 rounded">
                        <div class="row">
                            <div class="col-md-10 mx-auto">
                                <div class="card border-secondary">
                                    <div class="card-header">
                                        <h3 class="mb-0 my-0 text-center">Generar Trabajo Programado</h3>
                                    </div>
                                    <div class="card-body">

                                       
                                        <asp:Panel ID="panelInfo" runat="server" Visible="true">
                                            <div class="form-group">
                                                <div class="form-group d-flex align-items-center justify-content-center">
                                                    <asp:Button ID="btnConfirmarReasignacion" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="📝"  CausesValidation="false" Visible="false" OnClick="btnConfirmarReasignacion_Click" />
                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="Label8" runat="server" Text="Label">Informacion del trabajo programado (nombre de evento, lugar, ect.)</asp:Label>
                                                    <asp:TextBox ID="txtDetallePocicion" runat="server"
                                                        ToolTip="🏙 Ingrese informacion sobre la ubicacion exacta&#10;🎯 Procure que su informacion sea precisa y correcta&#10;🧭 Para que el personal tecnico pueda ubicar el lugar facilmente"
                                                        CssClass="form-control " TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="Label2" runat="server" Text="Label">Detalle adicional (hora)</asp:Label>
                                                    <asp:TextBox ID="txtProblema" runat="server"
                                                        ToolTip="📝 Ingrese la informacion de forma entendible &#10;🎯 Procure que la informacion sea precisa y correcta &#10;👨‍💻 Describa algun detalle adicional &#10;ej.(detalles del lugar, hora que ocurrira el evento)"
                                                        CssClass="form-control " TextMode="MultiLine" Width="95%" Height="150px"></asp:TextBox>
                                                </div>
                                                <div class="form-group">

                                                    <div id="fechaProgramacion" style="display: none;">
                                                        <asp:Label ID="Label4" runat="server" Text="Label">Fecha de Atencion estimada</asp:Label>
                                                        <asp:TextBox class="form-control" ID="txtfecha" runat="server" ToolTip="📅 Ingrese la fecha en que se atendera el ticket" TextMode="Date" Width="95%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="tipoTicket" class="form-group">
                                                    <asp:Label ID="Label6" runat="server" Text="Label">Tecnicos disponibles</asp:Label>

                                                    <telerik:RadMultiSelect ID="RadMultiSelect1" Width="95%" runat="server" DataTextField="nombre" DataValueField="ID" />

                                                </div>
                                                <div class="form-group d-flex align-items-center justify-content-center">
                                                    <asp:Button ID="btnRegistrar" CssClass="btn btn-success btn-lg float-right mr-1" runat="server" Text="Generar ✔" OnClick="btnGenerar_Click" />
                                                    <asp:Button ID="btnReasignacion" runat="server" CssClass="btn btn-primary float-right form-control w-auto" Text="Reasignar 🔄" Enabled="true" Visible="false" OnClick="btnReasignacion_Click" />

                                                </div>
                                        </asp:Panel>

                                        <asp:Panel ID="panelResultado" runat="server" Visible="False">
                                            <div class="form-group">
                                                <div>
                                                    <h5 class="active text-center">Trabajo programado creado exitosamente</h5>
                                                </div>
                                                <asp:Label ID="label5" CssClass="form-control text-center mt-3" runat="server" Text="Numero de ticket"></asp:Label>
                                                <div>
                                                    <asp:Label ID="lblNum" CssClass="form-control text-center" runat="server" Text="# 0000" Font-Size="100px"></asp:Label>
                                                </div>
                                                <div class="form-group d-flex align-items-center justify-content-center">
                                                    <asp:Button ID="btnContinuar" CssClass="btn btn-success btn-lg float-right mr-1 mt-4" runat="server" Text="Continuar ✔" OnClick="btnContinuar_Click" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Label ID="lblerror" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <asp:Label ID="lblValidadorFecha" runat="server" Text=""></asp:Label>
                                            <asp:RequiredFieldValidator CssClass="text-center" ID="RequiredFieldValidatorDetalle" runat="server" ControlToValidate="txtDetallePocicion" ErrorMessage="Debe ingresar la informacion del trabajo programado" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
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
