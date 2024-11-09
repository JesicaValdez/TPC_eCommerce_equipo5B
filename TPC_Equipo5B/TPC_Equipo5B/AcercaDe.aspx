<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AcercaDe.aspx.cs" Inherits="TPC_Equipo5B.AcercaDe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Style.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Título -->
    <div class="container info-section">
        <div class="row justify-content-center align-items-center">
            <div class="col-md-4 text-center">
                <i class="bi bi-info info-icon-page"></i>
                <div class="title-style">SOBRE NOSOTROS</div>
            </div>

            <!-- Descripción -->
            <div class="col-md-6 description-text">
                <p class="text-style">
                    En TUTICKET, nos dedicamos a la venta de tickets electrónicos para eventos de todo tipo. Nuestro objetivo es facilitar a nuestros clientes el acceso a experiencias memorables, ya sean conciertos, obras de teatro, festivales o eventos corporativos.
                </p>
                <p class="text-style">
                    Nos enorgullece ofrecer un servicio ágil y seguro, asegurando que la compra de entradas sea una experiencia sencilla y sin complicaciones. A través de nuestra plataforma, los usuarios pueden explorar una amplia variedad de eventos, elegir sus asientos y adquirir sus tickets en pocos clics.
                </p>
                <p class="text-style">
                    Nuestro equipo de profesionales está comprometido con brindar un soporte excepcional y atención al cliente, garantizando que cada cliente tenga la mejor experiencia posible desde el momento de la compra hasta el evento en sí. Trabajamos incansablemente para ofrecer las mejores opciones y precios, asegurando que cada evento sea accesible para todos. En TUTICKET, creemos en el poder de los eventos para conectar a las personas y crear recuerdos inolvidables. Únete a nosotros y descubre todo lo que tenemos para ofrecerte.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
