<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="TPC_Equipo5B.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="CSS/Style.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Titulo-->
    <div class="container info-section">
        <div class="row justify-content-center">
            <div class="col-md-4 text-center">
                <i class="bi bi-megaphone info-icon-page"></i>
                <div class="title-style">PRÓXIMOS EVENTOS</div>
            </div>
        </div>
    </div>

    <!--Label Filtro por Tipo de EVENTO-->
    <div class="col filter-container" style="padding: 20px;">
        <asp:Label ID="Label1" runat="server" Text="Filtrar por tipo de evento:" CssClass="filter-container-label"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEventos" CssClass="btn btn-outline-dark dropdown-toggle" Style="color: #F4F4F4; border-color: #F4F4F4;"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Filtrar" class="explore-btn" OnClick="Button1_Click" />
    </div>

    <!--Repeater para generar las tarjetas-->
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rptArticulos" runat="server">
    <ItemTemplate>
        <div class="col">
            <div class="card h-100">
                <img class="card-img-top" src="<%# Eval("imagenes[0].Url") %>" alt="Imagen del evento" />
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("nombre") %></h5>
                    <p class="card-text event-date"><i class="bi bi-calendar-check"></i> <%# Eval("fecha", "{0:dddd, dd 'de' MMMM 'de' yyyy}") %></p>
                    <p class="card-text"><%# Eval("descripcion") %></p>
                </div>
               <div class="card-footer text-center"> 
                    <asp:LinkButton ID="Button2" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="Button2_Click">
                        <i class="bi bi-file-plus"></i> Ver Detalles del Evento
                    </asp:LinkButton>
                   <asp:LinkButton ID="ButtonFavorite" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="ButtonFavorite_Click">
                        <i class="bi bi-heart"></i> Favorito
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

    </div>
</asp:Content>
