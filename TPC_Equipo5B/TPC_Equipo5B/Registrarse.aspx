<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPC_Equipo5B.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center" style="color: #F4F4F4;">Regístrate</h1>

    <div id="Crear" class="form-text text-center m-4" style="color: #F4F4F4;">Registra tu cuenta de TuTiket y disfruta de tus eventos favoritos</div>

    <div class="row justify-content-center">
        <div class="col-6">

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
            <div class="mb-3">
                <label for="txtEmail" class="form-label" style="color: #F4F4F4;">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese Email" />
            </div>

            <div class="mb-3">
                <label for="txtTelefono" class="form-label" style="color: #F4F4F4;">Telefono</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Ingrese Telefono" />
            </div>

            <div class="row mb-3">
                <div class="col">
                    <label for="txtDireccion" class="form-label" style="color: #F4F4F4;">Dirección</label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Ingrese Direccion" />
                </div>

                <div class="col">
                    <label for="txtCiudad" class="form-label" style="color: #F4F4F4;">Ciudad</label>
                    <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" placeholder="Ingrese Ciudad" />
                </div>

                <div class="col">
                    <label for="txtCP" class="form-label" style="color: #F4F4F4;">CP</label>
                    <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" placeholder="Ingrese CP" />
                </div>

                <div class="mb-3">
                    <asp:Button ID="btn_registrar" runat="server" Text="Registrar" class="btn btn-warning mt-4" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
