<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="TPC_Equipo5B.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .list-group-item-dark:hover {
            background-color: #e0a800;
            cursor: pointer;
        }
        h3
        {
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
                    <p>Aquí puedes editar tu cuenta.</p>
                </asp:View>

                <!-- Vista de Cambiar Contraseña -->
                <asp:View ID="ViewCambiarContrasena" runat="server">
                    <h3 style="color: #F4F4F4; margin-top: 10px;">Cambiar Contraseña</h3>
                    <p>Aquí puedes cambiar tu contraseña.</p>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>

</asp:Content>
