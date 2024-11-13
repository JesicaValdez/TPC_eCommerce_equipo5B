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
                <asp:Label ID="lbl_Dni" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="row mb-3">
                <div class="col">
                    <label for="txtNombre" class="form-label" style="color: #F4F4F4;">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese Nombre" />
                    <asp:Label ID="lbl_Nombre" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>

                <div class="col">
                    <label for="txtApellido" class="form-label" style="color: #F4F4F4;">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingrese Apellido" />
                    <asp:Label ID="lbl_Apellido" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <label for="txtCalendarioFN" class="form-label" style="color: #F4F4F4;">Fecha de Nacimiento</label>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="txtCalendarioFN" CssClass="form-control" TextMode="Date" />
                <asp:Label ID="lbl_FechaN" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>
            
            <div class="mb-3">
                <label for="txtTelefono" class="form-label" style="color: #F4F4F4;">Telefono</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Ingrese Telefono" />
                <asp:Label ID="lbl_tel" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label" style="color: #F4F4F4;">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese Email"/>
                <asp:Label ID="lbl_Email" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="txtUser" class="form-label" style="color: #F4F4F4;">Usuario</label>
                <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" placeholder="Ingrese Usuario" aria-describedby="emailHelp" />
                <asp:Label ID="lbl_Usuario" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="txtPass" class="form-label" style="color: #F4F4F4;">Contraseña</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" placeholder="Ingrese Contraseña" TextMode="Password" />
                <asp:Label ID="lbl_Pass" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <div class="form-check">
                <asp:CheckBox ID="checkCondiciones" class="form-check-label" runat="server" />
                <label for="check_TC" class="form-check-label" style="color: #F4F4F4;">Acepto los términos y condiciones</label>               
            </div>
             <asp:Label runat="server" ID="lbl_Chek" Text="" Visible="false" ForeColor="Red"/>
            <br />

            <div class="mb-3">
                <asp:Button ID="btn_registrar" runat="server" Text="Registrarse" class="btn btn-warning mt-3 w-100" OnClick="btn_clickRegistro" />
            </div>

        </div>
    </div>

</asp:Content>
