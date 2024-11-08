<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="TPC_Equipo5B.Usuario" %>

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
                Style="height: 100px; width: 100px; border-radius: 50%; margin-top: 30px; margin-bottom: 30px; margin-left: 70px;" />

            <!-- Nombre y Apellido -->
            <div>
                <asp:Label ID="lbl_NomyApe" runat="server" Text="Nombre y Apellido" Style="color: #F4F4F4; margin-left: 60px;"></asp:Label>
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
                </asp:View>

                <!-- Vista de Editar Cuenta -->
                <asp:View ID="ViewEditarCuenta" runat="server">
                    <h3 style="color: #F4F4F4; margin-top: 10px;">Editar Cuenta</h3>
                    <div class="row justify-content-center">
                        <div class="col-8">

                            <div class="mb-3">
                                <label for="txtdni" class="form-label" style="color: #F4F4F4;">DNI</label>
                                <asp:TextBox runat="server" ID="txtdni" CssClass="form-control" placeholder="Ingrese Dni" />
                                <asp:Label ID="lblResultado" runat="server"></asp:Label>
                            </div>

                            <div class="row mb-3">

                                <div class="col">
                                    <label for="txtNombre" class="form-label" style="color: #F4F4F4;">Nombre</label>
                                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese Nombre" />
                                </div>

                                <div class="col">
                                    <label for="txtApellido" class="form-label" style="color: #F4F4F4;">Apellido</label>
                                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingrese Apellido" />
                                </div>
                            </div>

                            <label for="txtCalendario" class="form-label" style="color: #F4F4F4;">Fecha de Nacimiento</label>
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="inputGroup-sizing-sm">
                                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="calendarClickUser" />
                                </span>
                                <asp:TextBox runat="server" ID="txtCalendario" CssClass="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" />
                            </div>

                            <asp:Calendar ID="calendarioUser" runat="server" CssClass="custom-calendar" OnSelectionChanged="selecChangedUser"></asp:Calendar>

                            <div class="mb-3">
                                <label for="txtTelefono" class="form-label" style="color: #F4F4F4;">Telefono</label>
                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Ingrese Telefono" />
                            </div>

                            <div class="mb-3">
                                <asp:Button ID="btn_Editar" runat="server" Text="Editar" class="btn btn-warning mt-4" />
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
                                <label for="txt_PassAnterior" class="form-label" style="color: #F4F4F4;">Contraseña Actual</label>
                                <asp:TextBox runat="server" ID="txt_PassAnterior" CssClass="form-control" placeholder="Ingrese Contraseña Actual" TextMode="Password" />
                            </div>

                            <div class="mb-3">
                                <label for="txt_PassNuevo" class="form-label" style="color: #F4F4F4;">Contraseña Nueva</label>
                                <asp:TextBox runat="server" ID="txt_Pass" CssClass="form-control" placeholder="Ingrese Contraseña Nueva" TextMode="Password" />
                            </div>

                            <div class="mb-3">
                                <label for="txt_PassNuevoRepetir" class="form-label" style="color: #F4F4F4;">Confirmar Contraseña Nueva</label>
                                <asp:TextBox runat="server" ID="txt_PassNuevoRepetir" CssClass="form-control" placeholder="Confirmar Contaseña Nueva" TextMode="Password" />
                            </div>

                            <div class="d-grid">
                                <asp:Button ID="btn_login" runat="server" Text="Cambiar Contaseña" class="btn btn-warning mt-3" />
                            </div>

                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>

</asp:Content>
