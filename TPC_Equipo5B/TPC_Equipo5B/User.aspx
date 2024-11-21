<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="TPC_Equipo5B.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .list-group-item-dark:hover {
            background-color: #e0a800;
            cursor: pointer;
        }

        h3 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!-- Columna de Menú a la izquierda -->
        <div class="col-md-3">
            <!-- Imagen del usuario -->
            <asp:Image
                ID="img_Usuario"
                runat="server"
                Style="height: 100px; width: 100px; border-radius: 50%; margin-top: 30px; margin-bottom: 30px; margin-left: 80px;" />

            <!-- Usuario -->
            <div>
                <asp:Label ID="lblemailU" runat="server" Text="" Style="color: #F4F4F4; margin-left: 25px;"></asp:Label>
            </div>

            <!-- Lista menú -->
            <div class="row mt-4">
                <div class="col-12">
                    <div class="list-group">
                        <!-- Los enlaces activan las vistas -->
                        <asp:LinkButton ID="lnkMisTikets" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarMisTikets">
                            <i class="fas fa-ticket-alt"></i> Mis Tikets
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkEditarCuenta" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarEditarCuenta">
                            <i class="bi bi-person-fill"></i> Editar Cuenta
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkCambiarContrasena" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarCambiarContrasena">
                            <i class="bi bi-unlock-fill"></i> Cambiar Contraseña
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkEliminarCuenta" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="MostrarEliminarCuenta">
                            <i class="bi bi-trash-fill"></i> Eliminar Cuenta
                        </asp:LinkButton>
                        <asp:LinkButton ID="link_Desconectar" runat="server" CssClass="list-group-item list-group-item-dark" OnClick="Desconectarse">
                            <i class="bi bi-box-arrow-right"></i>Desconectarse
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <!-- Columna de contenido dinámico a la derecha -->
        <div class="col-md-9">
            <!-- Paneles de contenido dinámico -->
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <!-- Vista de Mis Tikets -->
                <asp:View ID="ViewMisTikets" runat="server">
                    <h3 style="color: #F4F4F4; margin-top: 10px;">Mis Tikets</h3>
                    <p>Aquí puedes ver tus tikets.</p>
                        <div class="mx-auto">
                            <asp:Repeater ID="rptEntradas" runat="server">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card-group">
                                            <div class="card mb-3 mx-auto" style="max-width: 540px;">
                                                <div class="row g-0">
                                                <div class="col-md-4">
                                                    <img src="<%# Eval("evento.imagenes[0].Url") %>" class="img-fluid rounded-start" alt="...">
                                                </div>
                                                <div class="col-md-8">
                                                    <div class="card-body">
                                                    <p class="card-text"><%# Eval("evento.codigo") %></p>
                                                    <h5 class="card-title"><%# Eval("evento.nombre") %></h5>
                                                    
                                                    <p class="card-text"><%# Eval("evento.fecha", "{0:dddd, dd 'de' MMMM 'de' yyyy  hh:mm}") %></p>
                                                    <p class="card-text">Entrada: <%# Eval("precio.tipoEntrada") %></p>
                                                    <p class="card-text">Precio: <%# Eval("precio.precio") %></p>
                                                    
                                                    
                                                    
                                                    </div>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                </asp:View>

                <!-- Vista de Editar Cuenta -->
                <asp:View ID="ViewEditarCuenta" runat="server">
                    <h3 style="color: #F4F4F4; margin-top: 10px;">Editar Cuenta</h3>
                    <div class="row justify-content-center">
                        <div class="col-8">

                            <div class="mb-3">
                                <label for="txtdni" class="form-label" style="color: #F4F4F4;">DNI</label>
                                <asp:TextBox runat="server" ID="txtb_dni" CssClass="form-control" placeholder="Ingrese Dni" />
                                <asp:Label ID="lblDni" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="row mb-3">
                                <div class="col">
                                    <label for="txtNombre" class="form-label" style="color: #F4F4F4;">Nombre</label>
                                    <asp:TextBox runat="server" ID="txtb_Nombre" CssClass="form-control" placeholder="Ingrese Nombre" />
                                    <asp:Label ID="lblNombre" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="col">
                                    <label for="txtApellido" class="form-label" style="color: #F4F4F4;">Apellido</label>
                                    <asp:TextBox runat="server" ID="txtb_Apellido" CssClass="form-control" placeholder="Ingrese Apellido" />
                                    <asp:Label ID="lblApellido" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                            <label for="txtCalendario" class="form-label" style="color: #F4F4F4;">Fecha de Nacimiento</label>
                            <div class="mb-3">
                                <asp:TextBox runat="server" ID="txtb_FechaNacimiento" CssClass="form-control" TextMode="Date"/>
                                <asp:Label ID="lblfechaN" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="mb-3">
                                <label for="txtTelefono" class="form-label" style="color: #F4F4F4;">Telefono</label>
                                <asp:TextBox runat="server" ID="txtb_Telefono" CssClass="form-control" placeholder="Ingrese Telefono" />
                                <asp:Label ID="lblTel" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="mb-3">
                                <asp:Button ID="btn_Editar" runat="server" Text="Editar" class="btn btn-warning mt-4 w-100" OnClick="btn_clickEditar"/>
                            </div>
                            
                        </div>
                    </div>
                </asp:View>

                <!-- Vista de Cambiar Contraseña -->
                <asp:View ID="ViewCambiarContrasena" runat="server">
                    <h3 style="color: #F4F4F4; margin-top: 10px;">Cambiar Contraseña</h3>

                    <div class="row justify-content-center">
                        <div class="col-8">             

                            <div class="mb-3">
                                <label for="txt_PassNuevo" class="form-label" style="color: #F4F4F4;">Contraseña Nueva</label>
                                <asp:TextBox runat="server" ID="txt_PassNuevo" CssClass="form-control" placeholder="Ingrese Contraseña Nueva" TextMode="Password" />
                                <asp:Label ID="lbl_passNuevo" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="mb-3">
                                <label for="txt_PassNuevoRepetir" class="form-label" style="color: #F4F4F4;">Confirmar Contraseña Nueva</label>
                                <asp:TextBox runat="server" ID="txt_PassNuevoConfirmar" CssClass="form-control" placeholder="Confirmar Contaseña Nueva" TextMode="Password" />
                                <asp:Label ID="lbl_passNuevoConfirmar" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="d-grid">
                                <asp:Button ID="btn_login" runat="server" Text="Cambiar Contaseña" class="btn btn-warning mt-3" OnClick="btn_EditarPass"/>
                            </div>

                        </div>
                    </div>
                </asp:View>

                <!-- Nueva Vista de Eliminar Cuenta -->
                <asp:View ID="ViewEliminarCuenta" runat="server">
                    <h3 style="color: #F4F4F4; margin-top: 10px;">Eliminar Cuenta</h3>
                    <p style="text-align: center; color: #F4F4F4;">
                        Esta acción es irreversible. Si eliminas tu cuenta, perderás toda la información asociada.
                    </p>
                    <div class="d-grid col-6 mx-auto">
                        <asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-danger" />
                    </div>
                </asp:View>

            </asp:MultiView>
        </div>
    </div>

</asp:Content>
