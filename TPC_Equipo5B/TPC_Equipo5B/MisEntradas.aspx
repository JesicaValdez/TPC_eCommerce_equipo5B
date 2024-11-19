<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisEntradas.aspx.cs" Inherits="TPC_Equipo5B.WebForm1" %>
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
                    <div class="title-style">Tu Carrito</div>
                </div>
            </div>
        </div>
    <div class="row row-cols-1 row-cols-md-1 g-4">
    <asp:Repeater ID="rptArticulos" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card-group">
                    <div class="card mb-3" style="max-width: 540px;">
                        <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%# Eval("evento.imagenes[0].Url") %>" class="img-fluid rounded-start" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                            <p class="card-text"><%# Eval("evento.codigo") %></p>
                            <h5 class="card-title"><%# Eval("evento.nombre") %></h5>
                            <p class="card-text"><%# Eval("evento.descripcion") %></p>
                            <p class="card-text"><%# Eval("evento.fecha", "{0:dddd, dd 'de' MMMM 'de' yyyy  hh:mm}") %></p>
                            <p class="card-text">Cantidad: <%# cantidad( Eval("evento.id"), Eval("precio.idPrecio")) %></p>
                            <p class="card-text">Tipo de Entrada: <%# Eval("precio.tipoEntrada") %></p>
                            <p class="card-text">Precio: <%# Eval("precio.precio") %></p>
                            <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%# Eval("precio.idPrecio") %>' CssClass="btn btn-warning" OnClick="Button1_Click">
                                <i class="bi bi-file-plus"></i> Sacar del carrito
                            </asp:LinkButton>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
    <div style="color: #F4F4F4; text-align: center; font-size: larger">
        <asp:Label ID="Label2" runat="server" Text="Subtotal:"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="text-align: center">
        <asp:Button ID="Button2" class="btn btn-light" runat="server" Text="Ir a Pagar" OnClick="Button2_Click" />
    </div>
</asp:Content>
