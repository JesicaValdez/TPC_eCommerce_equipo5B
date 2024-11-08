<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TPC_Equipo5B.AgregarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 text-light">
        <h2 class="logo-style mb-4">Agregar Usuario</h2>

        <asp:Panel ID="panelMessage" runat="server" Visible="false" CssClass="alert" />

        <!-- Formulario de Agregar Usuario -->
        <div class="form-group">
            <label for="txtNombreUsuario">Nombre de Usuario:</label>
            <input type="text" id="txtNombreUsuario" runat="server" class="form-control bg-encabezado text-light border-0" required />
        </div>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <input type="email" id="txtEmail" runat="server" class="form-control bg-encabezado text-light border-0" required />
        </div>

        <div class="form-group">
            <label for="txtPass">Contraseña:</label>
            <input type="password" id="txtPass" runat="server" class="form-control bg-encabezado text-light border-0" required />
        </div>

        <div class="form-group">
            <label for="ddlTipoUsuario">Tipo de Usuario:</label>
            <select id="ddlTipoUsuario" runat="server" class="form-control bg-encabezado text-light border-0" required>
                <option value="Admin">Administrador</option>
                <option value="User">Usuario</option>
            </select>
        </div>

        <!-- Botones de acción con clases de Bootstrap y estilos personalizados -->
        <div class="form-group">
            <button type="submit" id="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click">Guardar</button>
            <button type="button" id="btnCancelar" runat="server" class="btn btn-secondary" OnClick="btnCancelar_Click">Cancelar</button>
        </div>
    </div>
</asp:Content>
