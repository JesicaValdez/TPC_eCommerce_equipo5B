<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="TPC_Equipo5B.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f8f9fa;
        }

        .admin-menu-item {
            transition: background-color 0.3s;
        }

            .admin-menu-item:hover {
                background-color: #e0a800;
                cursor: pointer;
            }

        .admin-header {
            background-color: #343a40;
            color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            margin-bottom: 20px;
            text-align: center;
        }

            .admin-header h2 {
                margin: 0;
            }

        .admin-content {
            padding: 20px;
            border-radius: 8px;
            background-color: #ffffff;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        /* Estilo para las tablas */
        .table th {
            background-color: #343a40;
            color: #ffffff;
        }

        .table-dark {
            background-color: #343a40;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Sidebar de administración -->
            <div class="col-md-3 bg-dark text-light p-3">
                <i class="bi bi-person-fill-gear"></i>
                <h4 class="text-center mb-4">Panel de Administración</h4>
                <div class="list-group">
                    <!-- Opciones de administración -->
                    <asp:LinkButton ID="lnkVerUsuarios" runat="server" CssClass="list-group-item admin-menu-item" OnClick="VerListadoUsuarios">
                        <i class="bi bi-people-fill"></i> Ver Listado de Usuarios 
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkGestionEventos" runat="server" CssClass="list-group-item admin-menu-item" OnClick="MostrarGestionEventos">
                        <i class="bi bi-calendar-event-fill"></i> Gestión de Eventos
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkReportes" runat="server" CssClass="list-group-item admin-menu-item" OnClick="MostrarReportes">
                        <i class="bi bi-graph-up"></i> Reportes y Análisis
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="list-group-item admin-menu-item" OnClick="CerrarSesion">
                        <i class="bi bi-box-arrow-right"></i> Cerrar Sesión
                    </asp:LinkButton>
                </div>
            </div>

            <!-- Área de contenido dinámico -->
            <div class="col-md-9">
                <div class="admin-header">
                    <h2>Panel de Administración</h2>
                </div>

                <div class="admin-content">
                    <!-- Contenedor del contenido -->
                    <asp:MultiView ID="MultiViewAdmin" runat="server" ActiveViewIndex="0">

                        <!-- Vista de Gestión de Usuarios -->
                        <asp:View ID="ViewGestionUsuarios" runat="server">
                            <h3>Listado de Usuarios</h3>
                            <p>Listado de Clientes dados de alta en el sistema.</p>
                            <asp:Button ID="btnVerListado" runat="server" Text="Ver Listado" CssClass="btn btn-warning mb-3" OnClick="ListadoCLientes" />
                            <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="False"
                                EmptyDataText="No hay usuarios disponibles en el sistema.">
                                <Columns>
                                    <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>


                        <!-- Vista de Gestión de Eventos -->
                        <asp:View ID="ViewGestionEventos" runat="server">
                            <h3>Gestión de Eventos</h3>
                            <p>Aquí puedes gestionar los eventos del sistema, incluyendo la creación, edición y eliminación de eventos.</p>
                            <asp:Button ID="btnAgregarEvento" runat="server" Text="Agregar Evento" CssClass="btn btn-warning mb-3" OnClick="AgregarEvento" />
                            <asp:GridView ID="gvEventos" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="IdEvento" HeaderText="ID" />
                                    <asp:BoundField DataField="NombreEvento" HeaderText="Nombre" />
                                    <asp:BoundField DataField="FechaEvento" HeaderText="Fecha" />
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>

                        <!-- Vista de Reportes y Análisis -->
                        <asp:View ID="ViewReportes" runat="server">
                            <h3>Reportes y Análisis</h3>
                            <p>Consulta informes de usuarios y eventos del sistema.</p>
                            <asp:DropDownList ID="ddlReportes" runat="server" CssClass="form-select mb-3">
                                <asp:ListItem Text="Reporte de Usuarios" Value="1" />
                                <asp:ListItem Text="Reporte de Eventos" Value="2" />
                            </asp:DropDownList>
                            <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-success" OnClick="GenerarReporte" />
                            <asp:Panel ID="panelReporte" runat="server" CssClass="mt-3">
                                <!-- Aquí se mostrarán los datos del reporte -->
                            </asp:Panel>
                        </asp:View>

                    </asp:MultiView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
