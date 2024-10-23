<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="TPC_Equipo5B.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="col-md-3">
    <!-- Imagen del usuario -->
    <asp:Image 
        ID="img_Usuario" 
        runat="server" 
        Style="height: 100px; width: 100px; border-radius: 50%; border: 1px solid #F4F4F4; margin-top: 30px; margin-bottom: 30px; margin-left: 70px;" />

    <!-- Nombre y Apellido -->
    <div>
        <asp:Label ID="lbl_NomyApe" runat="server" Text="Nombre y Apellido" style="color: #F4F4F4; margin-left: 60px;"></asp:Label>
    </div>

    <!-- Lista menú -->
    <div class="row mt-4">
        <div class="col-12"> 
            <div class="list-group">
                <a href="#" class="list-group-item list-group-item-dark"><i class="fas fa-ticket-alt"></i> Mis Tikets</a>
                <a href="#" class="list-group-item list-group-item-dark"><i class="bi bi-person-fill"></i> Editar Cuenta</a>
                <a href="#" class="list-group-item list-group-item-dark"><i class="bi bi-unlock-fill"></i> Cambiar Contraseña</a>
                <a href="#" class="list-group-item list-group-item-dark"><i class="bi bi-box-arrow-right"></i> Desconectarse</a>
            </div>
        </div>
    </div>
</div>

   


</asp:Content>
