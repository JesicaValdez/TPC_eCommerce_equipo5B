<%@ Page Title="default" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo5B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <style>
       
        .category-card {
            border-radius: 10px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }
        .category-card:hover {
            transform: scale(1.05);
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
        }
        .explore-btn {
            background-color:#ffb700;
            border:none;
            text-decoration: none;
            color: #333;
            padding: 10px 20px;
            font-size: 18px;
            border-radius: 8px;
            transition: background-color 0.3s ease, transform 0.3s ease;
        }
        .explore-btn:hover {
            background-color: #e0a800;
            transform: scale(1.05);
        }
        .card-title {
            color: #333333;
            font-size: 20px;
            font-weight: bold;
        }
        .card-text {
            color: #666666;
            font-size: 16px;
        }
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
            font-size: 50px;
            color: #ffb700;
        }
        .info-section .info-title {
            font-size:20px;
            font-weight: bold;
            margin-top:15px;
            color: #ffffff;
        }
        .info-section .info-text {
            font-size: 16px;
            color: #f4f4f4;
            margin-top: 10px;
        }
        .info-section .info-card:hover {
            transform: scale(1.05);
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.4);
        }
        .title-style {
            color: #f4f4f4;
            font-size: 30px;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-0">
        <div id="carouselExample" class="carousel slide">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="https://www.sala-apolo.com/uploads/media/default/0001/09/thumb_8442_default_wide.jpeg" class="d-block w-100" alt="..." style="width: 100%; max-height: 400px; object-fit: cover;">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>Nombre Evento</h5>
                        <p>Fecha</p>
                    </div>
                </div>
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

                <!-- Tarjeta Deportes -->
                <div class="col">
                    <div class="card category-card">
                        <img src="https://www.nuevatribuna.es/media/nuevatribuna/images/2019/02/14/2019021417524471390.jpg" style="width: 100%; height: auto; max-height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <h5 class="card-title">Deportes</h5>
                            <p class="card-text">Descubre los mejores eventos deportivos, todos los emocionantes partidos de fútbol disponibles y más.</p>
                            <p class="card-text"><small class="text-muted"><i class="bi bi-star"></i>¡No te lo Pierdas!</small></p>
                        </div>
                    </div>
                </div>

                <!-- Tarjeta Recitales -->
                <div class="col">
                    <div class="card category-card">
                        <img src="https://estaticos-cdn.prensaiberica.es/clip/8d997404-dd37-4738-b716-cddcfd2e2ef2_alta-libre-aspect-ratio_default_0.jpg" style="width: 100%; height: auto; max-height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <h5 class="card-title">Recitales</h5>
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
                            <h5 class="card-title">Teatro</h5>
                            <p class="card-text">Sumergite en las mejores obras y producciones, desde dramas clásicos hasta comedias modernas.</p>
                            <p class="card-text"><small class="text-muted"><i class="bi bi-star"></i>¡No te lo Pierdas!</small></p>
                        </div>
                    </div>
                </div>
            
            </div>
        </div>

        <!-- Botón -->
        <div class="text-center mt-5">
            <!--<p class="card-text">Consulta nuestra selección de eventos imperdibles que no querrás perderte.</p> -->
            <a href="Eventos.aspx" class="explore-btn">Explorar Todos los Eventos</a>
        </div>
    </div>


        <!-- Sección Informativa -->
    <div class="container info-section">
     
        <div class="row">
            <!-- Opciones de Pago -->
            <div class="col-md-4">
                <i class="bi bi-credit-card info-icon"></i>
                 <div class="info-title">Elegí cómo pagar</div>
                <div class="info-text">Podés pagar con tarjeta, en cuotas, débito o transferencia a través de Mercado Pago.</div>
            </div>

            <!-- Envío de Tickets -->
            <div class="col-md-4 ">
                <i class="bi bi-box-seam info-icon"></i>
                        <div class="info-title">Recibe tus Tickets en Casa</div>
                  <div class="info-text">¡Disfrutá de la comodidad! Recibí tus tickets físicos en tu domicilio o elige la opción de QR que se enviará a tu correo electrónico.</div>
            </div>

            <!-- Atención al Cliente -->
            <div class="col-md-4 ">
                <i class="bi bi-shield-check info-icon"></i>
                        <div class="info-title">Atención al Cliente</div>
                        <div class="info-text">
                            Nuestro equipo de atención al cliente está disponible para resolver tus consultas y ofrecerte asistencia personalizada.
                        </div>
                    </div>
                </div>
        </div>
</asp:Content>
