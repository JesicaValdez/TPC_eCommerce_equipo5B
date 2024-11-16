<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPC_Equipo5B.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    
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


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container info-section">
    <div class="row justify-content-center">
        <div class="col-md-4 text-center">
            <div class="title-style">Tus Eventos Favoritos</div>
        </div>
    </div>
</div>
    <div class="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater ID="rptArticulos" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card h-100">
                    <img class="card-img-top" src="<%# Eval("imagenes[0].Url") %>" alt="Imagen del evento" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("nombre") %></h5>
                        <p class="card-text event-date"><i class="bi bi-calendar-check"></i> <%# Eval("fecha", "{0:dddd, dd 'de' MMMM 'de' yyyy}") %></p>
                        <p class="card-text"><%# Eval("lugar") %></p>
                    </div>
                    <div class="card-footer text-center"> 
                        <asp:LinkButton ID="Button2" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="Button2_Click">
                            <i class="bi bi-file-plus"></i> Ver Detalles del Evento
                        </asp:LinkButton>
                        <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="Button1_Click" autopostback="true">
                             Sacar de favoritos
                        </asp:LinkButton>
                        
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
