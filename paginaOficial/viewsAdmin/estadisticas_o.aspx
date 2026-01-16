<%@ Page Language="C#" AutoEventWireup="true" Title="Estadisticas Generales" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="estadisticas.aspx.cs" Inherits="paginaOficial.viewsAdmin.estadisticas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
    </telerik:RadScriptManager>

    <div class="container py-1 pb-2 ">
        <div class="d-flex align-items-center justify-content-center">
            <div class="col-md-12  bg-dark mt-2 pb-5 pt-5 rounded">
                <div class="row">
                    <div class="col-md-12 mx-auto">
                        <div class="card border-secondary">
                            <div class="card-header">
                                <h3 class=" text-center">Estadisticas Generales</h3>
                            </div>
                            <div class="card-body">

                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <div class="row">
                                        <div class="col-xl-12 col-md-12 mb-2">
                                            <div class="card border-left-primary shadow h-100 py-2">
                                                <div class="card-body">
                                                    <div class="row no-gutters align-items-center">
                                                        <div class="col mr-2">
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">No se han generado tickets para este mes</div>
                                                        </div>
                                                        <div class="col-auto">
                                                            <i class="fa fa-ticket-alt fa-2x text-primary"></i>
                                                            <i class="fas fa-calendar fa-2x text-primary"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel2" runat="server">
                                    <div class="row">
                                        <div class="col-xl-12 col-md-12 mb-2">
                                            <div class="card border-left-primary shadow h-100 py-2">
                                                <div class="card-body">
                                                    <div class="row no-gutters align-items-center">
                                                        <div class="col mr-2">
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tickets totales generados en este mes</div>
                                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                                <asp:Label ID="labelVisitasMensual" runat="server" Text=""> tickets</asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-auto">
                                                            <i class="fa fa-ticket-alt fa-2x text-primary"></i>
                                                            <i class="fas fa-calendar fa-2x text-primary"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-6">
                                            <telerik:RadHtmlChart ID="pieChartArea" runat="server">
                                            </telerik:RadHtmlChart>
                                        </div>
                                        <div class="form-group col-6">
                                            <telerik:RadHtmlChart runat="server" ID="BarChart1" Transitions="true">
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </div>

                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">
                                            <telerik:RadHtmlChart ID="donutChart" runat="server">
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel3" runat="server" Visible="false">
                                    <div class="row">
                                        <div class="col-xl-12 col-md-12 mb-2">
                                            <div class="card border-left-primary shadow h-100 py-2">
                                                <div class="card-body">
                                                    <div class="row no-gutters align-items-center">
                                                        <div class="col mr-2">
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">No se han generado tickets hasta el momento</div>
                                                        </div>
                                                        <div class="col-auto">
                                                            <i class="fa fa-ticket-alt fa-2x text-danger"></i>
                                                            <i class="fas fa-calendar fa-2x text-danger"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel4" runat="server">
                                    <div class="row">
                                        <div class="col-xl-12 col-md-12 mb-2">
                                            <div class="card border-left-primary shadow h-100 py-2">
                                                <div class="card-body">
                                                    <div class="row no-gutters align-items-center">
                                                        <div class="col mr-2">
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tickets totales a la fecha</div>
                                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                                <asp:Label ID="labelVisitasTotal" runat="server" Text=""> tickets</asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-auto">
                                                            <i class="fa fa-ticket-alt fa-2x text-danger"></i>
                                                            <i class="fa fa-calendar fa-2x text-danger"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">
                                            <telerik:RadHtmlChart runat="server" ID="lineChart" CssClass="form-control pl-3">
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:LineSeries DataFieldY="Datacenter" Name="Data Center"></telerik:LineSeries>
                                                        <telerik:LineSeries DataFieldY="Desarrollo" Name="Desarrollo"></telerik:LineSeries>
                                                        <telerik:LineSeries DataFieldY="Redes" Name="Redes"></telerik:LineSeries>
                                                        <telerik:LineSeries DataFieldY="Soporte" Name="Soporte Tec."></telerik:LineSeries>
                                                    </Series>
                                                    <XAxis DataLabelsField="Meses"></XAxis>
                                                </PlotArea>
                                            </telerik:RadHtmlChart>

                                        </div>
                                    </div>
                                </asp:Panel>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

