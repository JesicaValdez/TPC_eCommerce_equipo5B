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

    <!-- Sección Informativa -->
    <div class="container info-section">
        <!-- Llamada a la Acción -->
        <div class="text-center">
            <a href="eventos.aspx" class="explore-btn">Ver Eventos disponibles</a>
        </div>

        <div class="row">
            <div class="col-md-4 text-center info-card">
                <i class="bi bi-ticket info-icon"></i>
                <div class="info-title">Venta de Tickets Electrónicos</div>
                <div class="text-style">Ofrecemos una plataforma fácil de usar para adquirir entradas a tus eventos favoritos de manera rápida y segura.</div>
            </div>

            <div class="col-md-4 text-center info-card">
                <i class="bi bi-calendar info-icon"></i>
                <div class="info-title">Amplia Variedad de Eventos</div>
                <div class="text-style">Desde conciertos hasta obras de teatro, tenemos opciones para todos los gustos y preferencias.</div>
            </div>

            <div class="col-md-4 text-center info-card">
                <i class="bi bi-shield-lock info-icon"></i>
                <div class="info-title">Seguridad en las Transacciones</div>
                <div class="text-style">Garantizamos la protección de tus datos y la seguridad en cada transacción, para que compres con total tranquilidad.</div>
            </div>
        </div>
    </div>
</asp:Content>
