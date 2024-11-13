<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TPC_Equipo5B.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para el Titulo */
        .info-section {
            text-align: center;
            margin: 50px auto;
        }

        .info-section .info-card {
            padding: 20px;
            border: none;
            background-color: transparent;
        }

        .info-section .info-icon {
            font-size: 70px;
            color: #ffb700;
        }

        .info-section .title-style {
            font-size: 2.5rem;
            font-weight: bold;
            color: #f4f4f4;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            text-transform: uppercase;
            letter-spacing: 2px;
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.1);
        }

        .info-section .info-text {
            font-size: 16px;
            color: #f4f4f4;
            margin-top: 10px;
        }

        /* Estilos del formulario */
        .form-section {
            margin: 50px auto;
            padding: 30px;
            background-color: #eaeaea; /* Fondo gris claro */
            border-radius: 10px;
            width: 35%; /* Ajusta el ancho del formulario */
        }

        .form-label {
            color: #F4F4F4;
        }

        .form-section .btn {
            font-weight: bold;
        }

        /* Separación del footer */
        .mt-5 {
            margin-top: 5rem;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Titulo-->
    <div class="container info-section">
        <div class="row justify-content-center">
            <div class="col-md-4 text-center">
                <i class="bi bi-headset info-icon"></i>
                <div class="title-style">Contáctate con TuTicket</div>
                <div class="info-text">¿Necesitas ayuda? Llena el formulario y te contactaremos.</div>
            </div>
        </div>
    </div>

    <!-- Formulario -->
    <div class="container form-section">
        <div class="row md-6">
        <div class="mb-3">
            <label for="txtNombre" class="form-label" style="color: #ffb700;">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese Nombre" />
        </div>
        <div class="mb-3">
            <label for="txtApellido" class="form-label" style="color: #ffb700;">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingrese Apellido" />
        </div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label" style="color: #ffb700;">Email <i class="bi bi-envelope-at" style="color: #ffb700;"></i></label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese Email" />
        </div>
        <div class="mb-3">
            <label for="txtTelefono" class="form-label" style="color: #ffb700;">Teléfono <i class="bi bi-telephone" style="color: #ffb700;"></i></label>
            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Ingrese Telefono" />
        </div>
        <div class="mb-3">
            <label for="txtNombreEvento" class="form-label" style="color: #ffb700;">Nombre Evento <i class="bi bi-ticket-perforated" style="color: #ffb700;"></i></label>
            <asp:TextBox runat="server" ID="txtNombreEvento" CssClass="form-control" placeholder="Ingrese Nombre del Evento" />
        </div>
        <div class="mb-3">
            <div class="form-floating">
                <asp:TextBox runat="server" ID="txtMensaje" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Escribir Mensaje"></asp:TextBox>
                <label for="txtMensaje">Escribir Mensaje <i class="bi bi-chat-square-dots" style="color: #ffb700;"></i></label>
            </div>
        </div>
        <div class="d-grid">
            <asp:Button ID="btn_Contactar" runat="server" Text="Enviar Mensaje" class="btn btn-warning mt-5" />
        </div>
    
        </div>
    </div>
</asp:Content>
