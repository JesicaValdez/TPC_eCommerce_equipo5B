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
                <h4 class="text-center mb-4">Panel</h4>
                <div class="list-group">
                    <!-- Opciones de administración -->
                    <asp:LinkButton ID="lnkVerUsuarios" runat="server" CssClass="list-group-item admin-menu-item" OnClick="VerListadoUsuarios">
                        <i class="bi bi-people-fill"></i> Gestión de Usuarios 
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

                    <!-- Panel para mostrar mensajes -->
                    <asp:Panel ID="panelMessage" runat="server" Visible="false" CssClass="alert alert-info">
                        <asp:Label ID="lblMessage" runat="server"/>
                    </asp:Panel>

                    <!-- Contenedor del contenido -->
                    <asp:MultiView ID="MultiViewAdmin" runat="server" ActiveViewIndex="0">

                        <!-- Vista de Gestión de Usuarios -->
                        <asp:View ID="ViewGestionUsuarios" runat="server">
                            <h3>Listado de Usuarios</h3>
                            <p>Desde este lugar podes, agregar, modificar o eliminar usuarios.</p>

                            <!--Boton para buscar usuario-->
                            <asp:TextBox ID="txtBuscarUsuario" runat="server" Placeholder="Buscar usuario..."></asp:TextBox>
                            <asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" OnClick="btnBuscarUsuario_Click" />

                            <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="IdUsuario" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo de Usuario" />
                                    <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" />
                                </Columns>
                            </asp:GridView>

                            <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario" OnClick="btnAgregarUsuario_Click" />
                            <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar Usuario" OnClick="btnModificarUsuario_Click" />
                            <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar Usuario" OnClick="btnEliminarUsuario_Click" />
                        </asp:View>



                        <!-- Vista de Gestión de Eventos -->
                        <asp:View ID="ViewGestionEventos" runat="server">
                            <h3>Gestión de Eventos</h3>
                            <p>Aquí podes gestionar los eventos del sistema, incluyendo la creación, edición y eliminación de eventos.</p>

                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select mb-3" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Seleccionar Acción" Value="0" />
                                <asp:ListItem Text="Crear Evento" Value="1" />
                                <asp:ListItem Text="Modificar Evento" Value="2" />
                                <asp:ListItem Text="Eliminar Evento" Value="3" />
                            </asp:DropDownList>

                            <asp:GridView ID="gvEventos" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="IdEvento" HeaderText="ID" />
                                    <asp:BoundField DataField="NombreEvento" HeaderText="Nombre" />
                                    <asp:BoundField DataField="FechaEvento" HeaderText="Fecha" />
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>

                        <!-- Vista de Gestión de Compras -->
                        <asp:View ID="View1" runat="server">
                            <h3>Gestión de Compras</h3>
                            <p>Desde aquí podes gestionar las compras realizadas por los usuarios.</p>
                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select mb-3">
                                <asp:ListItem Text="Agregar Compra" Value="1" />
                                <asp:ListItem Text="Modificar Compra" Value="2" />
                                <asp:ListItem Text="Eliminar Compra" Value="3" />
                            </asp:DropDownList>

                            <asp:GridView ID="GridViewCompras" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="IdCompra" HeaderText="ID" />
                                    <asp:BoundField DataField="IdCliente" HeaderText="Usuario" />
                                    <asp:BoundField DataField="IdEvento" HeaderText="Evento" />
                                    <asp:BoundField DataField="FechaCompra" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total" />
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
                                <asp:ListItem Text="Reporte de Compras" Value="3" />
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
