<%@ Page Language="C#" AutoEventWireup="true" Title="Generar Tickets" MasterPageFile="~/viewsUsers/users.Master" CodeBehind="estadisticasUsers.aspx.cs" Inherits="paginaOficial.viewsUsers.estadisticasUsers" %>

<asp:Content ID="BodyContenido" ContentPlaceHolderID="contenido" runat="server">
    <div>
        <div class="row  align-content-center">
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tramites generados</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-calendar fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tramites en ejecucion</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-calendar fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tramites realizados</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-calendar fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div>
    </div>

    <div>
    </div>
    <div>

        <asp:Chart ID="Chart3" runat="server">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

    </div>
    <div>

        <asp:Chart ID="Chart2" runat="server" Height="310px" OnLoad="Chart2_Load" Width="450px">
            <Series>
                <asp:Series ChartType="Pie" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>

