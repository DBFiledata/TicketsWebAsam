<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/viewsAdmin/admin.Master" CodeBehind="EstadisticasFiltro.aspx.cs" Inherits="paginaOficial.viewsAdmin.EstadisticasFiltro" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
    </telerik:RadScriptManager>
    <script>
        window.onresize = function () {
            $find("<%=lineChart.ClientID%>").get_kendoWidget().resize();
        }
    </script>

    <div class="card-header bg-gradient-secondary">
        <h3 class=" text-center">Estadisticas </h3>
    </div>

    <div class="container col-12 py-1 pb-2 ">
        <div class="d-flex align-items-center justify-content-center">
            <div class="col-md-12  bg-dark mt-2 pb-5 pt-5 rounded">
                <div class="row">
                    <div class="col-md-12 mx-auto">
                        <div class="card border-secondary">
                            <div class="col-12 d-flex flex-row mt-3">
                                <div class="col-11">
                                    <div class="bg-white collapse-inner rounded">
                                        <div class="form-group d-flex align-items-center justify-content-center">
                                            <div class="form-group col-3">
                                                <asp:Label ID="Label4" runat="server" Text="Label">Area</asp:Label>
                                                <asp:DropDownList ID="dlistArea" DataValueField="codigos" DataTextField="tipos" OnSelectedIndexChanged="dlistArea_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Height="32px" ToolTip="🏛️ Escoja el area" runat="server">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group col-3">
                                                <asp:Label ID="Label3" runat="server" Text="Label">Tecnico</asp:Label>
                                                <asp:DropDownList ID="dlistTecnico" DataValueField="id" DataTextField="nombres" Enabled="false" CssClass="form-control" Height="32px" ToolTip="👷‍ Escoja el tecnico" runat="server">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group col-3">
                                                <asp:Label ID="Label1" runat="server" Text="Label">Desde</asp:Label>
                                                <asp:TextBox ID="txtDesde" CssClass="form-control" runat="server" ToolTip="📅 inicio de rango de busqueda" TextMode="Date"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-3">
                                                <asp:Label ID="Label2" runat="server" Text="Label">Hasta</asp:Label>
                                                <asp:TextBox ID="TxtHasta" CssClass="form-control" runat="server" ToolTip="📅 final de rago de busqueda" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-1">
                                    <div class="bg-white collapse-inner form-group mt-3">
                                        <asp:Button ID="btnFiltrar" CssClass="btn btn-success btn-lg" OnClick="btnFiltrar_Click" ToolTip="Aplicar Filtro" runat="server" Text="🔎" />
                                    </div>
                                </div>
                            </div>



                            <div class="card-body">

                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <div class="row">
                                        <div class="col-xl-12 col-md-12 mb-2">
                                            <div class="card border-left-primary shadow h-100 py-2">
                                                <div class="card-body">
                                                    <div class="row no-gutters align-items-center">
                                                        <div class="col mr-2">
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">No se encuentran tickets para esta consulta</div>
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
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tickets totales</div>
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

                                    <div class="card-header">
                                        <h3 class=" text-center">Desglose total</h3>
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

                                    <%--<div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">
                                            <telerik:RadHtmlChart ID="donutChart" runat="server">
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </div>--%>
                                </asp:Panel>

                                <asp:Panel ID="Panel3" runat="server" Visible="false">
                                    <div class="row">
                                        <div class="col-xl-12 col-md-12 mb-2">
                                            <div class="card border-left-primary shadow h-100 py-2">
                                                <div class="card-body">
                                                    <div class="row no-gutters align-items-center">
                                                        <div class="col mr-2">
                                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">No se encuentran tickets para esta consulta</div>
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
                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">

                                            <telerik:RadHtmlChart runat="server" ID="lineChart" Width="100%" Height="100%">
                                                <%--CssClass="pr-1 ml-n5"--%>
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:LineSeries DataFieldY="cantidades"></telerik:LineSeries>
                                                    </Series>
                                                    <XAxis DataLabelsField="fecha">
                                                        <LabelsAppearance>
                                                            <TextStyle Color="Black" FontSize="8pt" />
                                                        </LabelsAppearance>
                                                    </XAxis>
                                                </PlotArea>
                                            </telerik:RadHtmlChart>

                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel7" runat="server">
                                    <div class="card-header">
                                        <h3 class=" text-center">Desglose por area</h3>
                                    </div>
                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-6">
                                            <telerik:RadHtmlChart ID="donutChart" runat="server">
                                            </telerik:RadHtmlChart>
                                        </div>
                                        <div class="form-group col-6">
                                            <telerik:RadHtmlChart runat="server" ID="barChartArea" Transitions="true">
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </div>
                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">

                                            <telerik:RadHtmlChart runat="server" ID="lineChart1" Width="100%" Height="100%">
                                                <%--CssClass="pr-1 ml-n5"--%>
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:LineSeries DataFieldY="DataCenter" Name="Data Center"></telerik:LineSeries>
                                                        <telerik:LineSeries DataFieldY="Desarrollo" Name="Desarrollo"></telerik:LineSeries>
                                                        <telerik:LineSeries DataFieldY="Redes" Name="Redes"></telerik:LineSeries>
                                                        <telerik:LineSeries DataFieldY="Soporte" Name="Soporte Tec."></telerik:LineSeries>
                                                    </Series>
                                                    <XAxis DataLabelsField="Fecha">
                                                        <LabelsAppearance>
                                                            <TextStyle Color="Black" FontSize="8pt" />
                                                        </LabelsAppearance>
                                                    </XAxis>
                                                </PlotArea>
                                            </telerik:RadHtmlChart>

                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel5" runat="server">
                                    <div class="card-header">
                                        <h3 class=" text-center">Cantidades por tecnicos</h3>
                                    </div>
                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">

                                            <asp:GridView ID="gridViewCantidades" AllowPaging="true" OnPageIndexChanging="gridViewCantidades_PageIndexChanging" PageSize="25"
                                                AutoGenerateColumns="false" CssClass="table table-striped table-dark table-bordered table table-condensed" Font-Size="Small"
                                                Width="100%" CellSpacing="0" runat="server">
                                                <%--OnRowDataBound="gridViewHistorico_RowDataBound"--%>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                                <PagerStyle BackColor="White" CssClass="dataTables_paginate paging_simple_numbers" VerticalAlign="Bottom"
                                                    HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="Area" HeaderText="Area" />
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel6" runat="server">
                                    <div class="card-header bg-light">
                                        <h3 class=" text-center">Tickets de tecnicos</h3>
                                    </div>
                                    <div class="form-group d-flex align-items-center justify-content-center">
                                        <div class="form-group col-12">

                                            <asp:GridView ID="gridViewHistorico" AllowPaging="true" OnPageIndexChanging="gridViewHistorico_PageIndexChanging" PageSize="30"
                                                AutoGenerateColumns="false" CssClass="table table-striped table-dark table-bordered table table-condensed" Font-Size="Small"
                                                Width="100%" CellSpacing="0" runat="server">
                                                <%--OnRowDataBound="gridViewHistorico_RowDataBound"--%>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                                <PagerStyle BackColor="White" CssClass="dataTables_paginate paging_simple_numbers" VerticalAlign="Bottom"
                                                    HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="idtickets" HeaderText="id" />
                                                    <asp:BoundField DataField="descripciones" HeaderText="Descripciones" />
                                                    <asp:BoundField DataField="problemas" HeaderText="Problemas" />
                                                    <asp:BoundField DataField="Solicitante" HeaderText="Solicitante" />
                                                    <asp:BoundField DataField="tecnico" HeaderText="Tecnico" />
                                                    <asp:BoundField DataField="area" HeaderText="Area" />
                                                    <asp:BoundField DataField="fechascreacion" HeaderText="Creación" />
                                                    <asp:BoundField DataField="fechasfinalizacion" HeaderText="Finalización" />
                                                    <asp:BoundField DataField="fechaCierre" HeaderText="Cierre" />
                                                </Columns>
                                            </asp:GridView>

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
