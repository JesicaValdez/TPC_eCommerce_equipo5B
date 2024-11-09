<%@ Page Title="default" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo5B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/Style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-0">
    <div id="carouselExample" class="carousel slide">
        <div class="carousel-inner" runat="server" id="carouselInner">
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
</div>

    <!-- Sección Categorias por tipos de Eventos -->
    <div class="container mt-5 info-section">
        <div class="card-group">
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <!-- Tarjeta Recitales -->
                <div class="col">
                    <div class="card category-card">
                        <img src="https://estaticos-cdn.prensaiberica.es/clip/8d997404-dd37-4738-b716-cddcfd2e2ef2_alta-libre-aspect-ratio_default_0.jpg" style="width: 100%; height: auto; max-height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <h5 class="card-title">RECITALES</h5>
                            <p class="card-text">Viví la magia de la música en vivo con los mejores conciertos de tus artistas favoritos.</p>
                            <p class="card-text"><small class="text-muted"><i class="bi bi-star"></i>¡No te lo Pierdas!</small></p>
                        </div>
                    </div>
                </div>
                <!-- Tarjeta Teatro -->
                <div class="col">
                    <div class="card category-card">
                        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/At_Rio_de_Janeiro_2019_396.jpg/230px-At_Rio_de_Janeiro_2019_396.jpg" style="width: 100%; height: auto; max-height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <h5 class="card-title">TEATRO</h5>
                            <p class="card-text">Sumergite en las mejores obras y producciones, desde dramas clásicos hasta comedias modernas.</p>
                            <p class="card-text"><small class="text-muted"><i class="bi bi-star"></i>¡No te lo Pierdas!</small></p>
                        </div>
                    </div>
                </div>
                <!-- Tarjeta Shows -->
                <div class="col">
                    <div class="card category-card">
                        <img src="https://media.istockphoto.com/id/1471448614/pt/foto/crowd-of-people-dancing-at-a-music-show-in-barcelona-during-the-summer-of-2022.jpg?b=1&s=612x612&w=0&k=20&c=kSm_SY5KCBSgwRM5Oftw4ematFMZ4d4ygGo8JfLTO24=" style="width: 100%; height: auto; max-height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <h5 class="card-title">SHOWS</h5>
                            <p class="card-text">Disfruta de la agenda de espectáculos más impresionantes en vivo.</p>
                            <p class="card-text"><small class="text-muted"><i class="bi bi-star"></i>¡No te lo Pierdas!</small></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Botón -->
        <div class="text-center mt-5">
            <a href="Eventos.aspx" class="explore-btn" style="text-decoration: none;">Explorar Todos los Eventos</a>
        </div>
    </div>

    <!-- Sección Informativa -->
    <div class="container info-section">
        <div class="row">
            <!-- Opciones de Pago -->
            <div class="col-md-4">
                <i class="bi bi-credit-card info-icon"></i>
                <div class="info-title">Elegí cómo pagar</div>
                <div class="text-style">Podés pagar con tarjeta, en cuotas, débito o transferencia a través de Mercado Pago.</div>
            </div>

            <!-- Envío de Tickets -->
            <div class="col-md-4 ">
                <i class="bi bi-box-seam info-icon"></i>
                <div class="info-title">Recibe tus Tickets en Casa</div>
                <div class="text-style">¡Disfrutá de la comodidad! Recibí tus tickets físicos en tu domicilio o elige la opción de QR que se enviará a tu correo electrónico.</div>
            </div>

            <!-- Atención al Cliente -->
            <div class="col-md-4 ">
                <i class="bi bi-shield-check info-icon"></i>
                <div class="info-title">Atención al Cliente</div>
                <div class="text-style">
                    Nuestro equipo de atención al cliente está disponible para resolver tus consultas y ofrecerte asistencia personalizada.
                </div>
            </div>
        </div>
    </div>
</asp:Content>
