<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TPC_Equipo5B.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <h2>Agregar Usuario</h2>
            
            <label for="txtNombreUsuario">Nombre de Usuario:</label>
            <input type="text" id="txtNombreUsuario" runat="server" required />
            <br />

            <label for="txtEmail">Email:</label>
            <input type="email" id="txtEmail" runat="server" required />
            <br />

            <label for="txtPass">Contraseña:</label>
            <input type="password" id="txtPass" runat="server" required />
            <br />

            <label for="ddlTipoUsuario">Tipo de Usuario:</label>
            <select id="ddlTipoUsuario" runat="server" required>
                <option value="Admin">Administrador</option>
                <option value="User">Usuario</option>
            </select>
            <br />

            <button type="submit" id="btnGuardar" runat="server" OnClick="btnGuardar_Click">Guardar</button>
            <button type="button" id="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</button>
</asp:Content>
