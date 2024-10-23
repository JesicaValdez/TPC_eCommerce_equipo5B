<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Equipo5B.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center" style="color: #F4F4F4;">Login</h1>

    <div class="row justify-content-center">
        <div class="col-5"> 
            <div class="mb-3">
                <label for="txt_Email" class="form-label" style="color: #F4F4F4;">Email o Usuario</label>
                <asp:TextBox runat="server" ID="txt_Email" CssClass="form-control" placeholder="Ingrese Email o Usuario" />
            </div>

            <div class="mb-3">
                <label for="txt_Pass" class="form-label" style="color: #F4F4F4;">Password</label> 
                <asp:TextBox runat="server" ID="txt_Pass" CssClass="form-control" placeholder="Ingrese Password" TextMode="Password" />
            </div>

            <div id="Recuperar" class="form-text text-center"><a href="#" style="color: #F4F4F4;">¿Olvidaste tu contraseña?</a></div>

             <div class="d-grid"> 
                <asp:Button ID="btn_login" runat="server" Text="Entrar" class="btn btn-warning mt-3"/>
            </div>

            <div id="Crear" class="form-text text-center mt-4"><a href="#" style="color: #F4F4F4;">¿No tienes cuenta? Regístrate</a></div>

        </div>
    </div>
</asp:Content>

