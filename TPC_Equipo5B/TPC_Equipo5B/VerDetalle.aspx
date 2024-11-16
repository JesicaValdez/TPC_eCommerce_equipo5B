<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="TPC_Equipo5B.VerDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         /*Estilo Titulo*/
         .title-style {
            font-size: 3rem; 
            font-weight: bold;
            text-align: center; 
            color: #FFB700; 
            margin-top: 20px;
            margin-bottom: 30px;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; 
            text-transform: uppercase;
            letter-spacing: 2px; 
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.1); 
         }

        /*Estilo boton*/
        .explore-btn {
            background-color: #ffb700;
            border: none;
            text-decoration: none;
            color: #333;
            padding: 5px 10px;
            font-size: 17px;
            border-radius: 8px;
            transition: background-color 0.3s ease, transform 0.3s ease;
        }

            .explore-btn:hover {
                background-color: #e0a800;
                transform: scale(1.05);
            }


        /* Contenedor de la info del evento */
        .card {
            background-color: #fff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        .card-title {
            font-size: 2rem; 
            font-weight: bold;
        }

        .card-text {
            font-size: 1.2rem; 
            line-height: 1.6; /* Mejora la legibilidad */
        }

        /* Fecha y hora del evento */
        .fecha-hora-evento {
            font-size: 1.2rem;
            color: black;
            font-weight: bold;
            padding: 10px; 
            background-color: #f9f9f9; 
            border: 1px solid #ddd; 
            border-radius: 5px;
            display: block; /* Asegura que ocupe toda la fila */
            margin-top: 20px;
            text-align: center;
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1); /* Sombra sutil */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid p-0" style="width: 100%; margin-bottom: 30px;"></div>
<h1 class="title-style">Información de tu Próximo Evento</h1>

<!--Contenedor del evento -->
<!--Contenedor del evento -->
 <asp:Repeater ID="detalle" runat="server">
    <ItemTemplate>
        <div class="card mb-3">
            <div class="row g-0">
     
                <!-- Imagen del evento -->
                <div id="carousel" class="col-md-4">
                    <img class="card-img-top" src='<%# (Eval("imagenes") != null && ((List<Dominio.Imagen>)Eval("imagenes")).Count > 0) ? ((List<Dominio.Imagen>)Eval("imagenes"))[0].Url : "defaultImageUrl" %>'>

                </div>
                <!-- Información del evento -->
                <div class="col-md-8">
                  <div class="card-body">
                    <h5 class="card-title"><%# Eval("nombre") %></h5>
                    <p class="card-text"><i class="bi bi-ticket-perforated-fill"></i><%# Eval("descripcion") %></p>
                    <p class="card-text"><small class="text-body-secondary"><i class="bi bi-file-plus"></i><%# entradas() %></small></p>
                    <p class="card-text"><small class="text-body-secondary"><i class="bi bi-map"></i> <%# Eval("lugar") %>, <%# Eval("direccion") %></small></p>
                    <p class="card-text"><small class="text-body-secondary"><i class="bi bi-bag-check"></i> Asegura tu lugar en este evento comprando tu entrada</small></p>
                
                  </div>
                </div>
                <asp:Label ID="lblFechaHora" runat="server" CssClass="fecha-hora-evento"> <i class="bi bi-clock"></i><%# Eval("fecha", "{0:dddd, dd 'de' MMMM 'de' yyyy}") %></asp:Label>
       
            </div>
        </div>
    </ItemTemplate>
 </asp:Repeater>

<div class="card ">
  <div class="row justify-content-center">
            <div class="col-md-6">
              <div class="card-body">
                <asp:Label ID="Label1" runat="server" Text="Cantidad:"></asp:Label>
                <asp:DropDownList ID="DropDownList1" CssClass="btn explore-btn dropdown-toggle" runat="server">
                    <asp:ListItem Text="1" />
                    <asp:ListItem Text="2" />
                    <asp:ListItem Text="3" />
                    <asp:ListItem Text="4" />
                    <asp:ListItem Text="5" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlEntradas" runat="server" Class="btn explore-btn dropdown-toggle" data-bs-toggle="dropdown"></asp:DropDownList>
                <asp:LinkButton ID="Button1" runat="server"  CssClass="btn btn-warning" OnClick="Button1_Click">
                    <i class="bi bi-file-plus"></i> Obtene tu Ticket
                </asp:LinkButton>
              </div>
            </div>
  </div>
</div>
  

</asp:Content>
