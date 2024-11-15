<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="TPC_Equipo5B.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="CSS/Style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Sidebar de administración -->
            <div class="col-md-3 bg-dark text-light p-3">
                <i class="bi bi-person-fill-gear info-icon-page"></i>
                <h4 class="text-center mb-4 title-style">Panel</h4>
                <div class="list-group">
                    <!-- Opciones de administración -->
                    <asp:LinkButton ID="lnkVerUsuarios" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="VerListadoUsuarios">
                        <i class="bi bi-people-fill info-icon"></i> Listado de Usuarios 
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="VerListadoClientes">
                      <i class="bi bi-people-fill info-icon"></i> Listado de Clientes 
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkGestionEventos" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarGestionEventos">
                        <i class="bi bi-calendar-event-fill info-icon"></i> Gestión de Eventos
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkReportes" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarReportes">
                        <i class="bi bi-graph-up info-icon"></i> Reportes y Análisis
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="list-group-item admin-menu-item" OnClick="CerrarSesion">
                        <i class="bi bi-box-arrow-right info-icon"></i> Cerrar Sesión
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
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-style" />
                    </asp:Panel>

                    <!-- Contenedor del contenido -->
                    <asp:MultiView ID="MultiViewAdmin" runat="server" ActiveViewIndex="0">
                        <!-- Vista de Usuarios -->
                        <asp:View ID="ViewGestionUsuarios" runat="server">
                            <h3 class="info-title">Lista de Usuarios</h3>
                            <asp:TextBox ID="txtBuscarUsuario" runat="server" Placeholder="Buscar usuario..." CssClass="form-control mb-2 text-style"></asp:TextBox>
                            <asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" OnClick="btnBuscarUsuario_Click" CssClass="btn btn-secondary mb-3 explore-btn" />
                            <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="IdUsuario" CssClass="table table-dark table-striped category-card">
                                <Columns>
                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo de Usuario" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>

                        <!-- Vista de Clientes -->
                        <asp:View ID="View1" runat="server">
                            <h3 class="info-title">Lista de Clientes</h3>
                            <asp:TextBox ID="txtClientes" runat="server" Placeholder="Buscar Cliente..." CssClass="form-control mb-2 text-style"></asp:TextBox>
                            <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar" OnClick="btnBuscarCliente_Click" CssClass="btn btn-secondary mb-3 explore-btn" />
                            <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCliente" CssClass="table table-dark table-striped category-card">
                                <Columns>
                                    <asp:BoundField DataField="IdCliente" HeaderText="ID cliente" />
                                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre de Cliente" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido de Cliente" />
                                    <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha de Nacimiento" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                    
                                </Columns>
                            </asp:GridView>
                        </asp:View>

                        <!-- Vista de Gestión de Eventos -->
                        <asp:View ID="ViewGestionEventos" runat="server">
                            <h3 class="info-title">Gestión de Eventos</h3>
                            <p class="text-style">Aquí puedes gestionar los eventos del sistema.</p>
                            <asp:TextBox ID="txtBuscarEvento" runat="server" Text="Ingresa el ID del Evento:" CssClass="filter-container-label"></asp:TextBox>
                            <asp:Button ID="BtnBuscarEvento" runat="server" Text="Buscar" OnClick="btnBuscarEvento_Click" CssClass="btn btn-secondary explore-btn" />

                            <asp:GridView ID="dgvEventos" runat="server" CssClass="table table-dark table-striped category-card" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                    <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="lugar" HeaderText="Lugar" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                    <asp:BoundField DataField="entradasDisponibles" HeaderText="Cant. Entradas" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                    <asp:TemplateField HeaderText="Modificar">
                                        <ItemTemplate>
                                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning explore-btn" CommandName="Modificar" CommandArgument='<%# Eval("id") %>' OnClick="btnModificar_Click"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger explore-btn" CommandName="Eliminar" CommandArgument='<%# Eval("id") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <a href="CrearEvento.aspx" class="btn btn-success mt-3 explore-btn">Agregar Evento</a>
                        </asp:View>

                        <!-- Vista de Reportes y Análisis -->
                        <asp:View ID="ViewReportes" runat="server">
                            <h3 class="info-title">Reportes y Análisis</h3>
                            <asp:DropDownList ID="ddlReportes" runat="server" CssClass="form-select mb-3 text-style">
                                <asp:ListItem Text="Reporte de Usuarios" Value="1" />
                                <asp:ListItem Text="Reporte de Eventos" Value="2" />
                                <asp:ListItem Text="Reporte de Compras" Value="3" />
                            </asp:DropDownList>
                            <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-success explore-btn" OnClick="GenerarReporte" />
                            <asp:Panel ID="panelReporte" runat="server" CssClass="mt-3 text-style">
                                <!-- Aquí se mostrarán los datos del reporte -->
                            </asp:Panel>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
