<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPC_Equipo5B.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="title-style" style="color: #F4F4F4; padding: 20px;">Mi Carrito</h1>
    <div class="row row-cols-1 row-cols-md-2 g-4">
    <asp:Repeater ID="rptArticulos" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card-group">
                    <div class="card mb-3" style="max-width: 540px;">
                        <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%# Eval("imagenes[0].Url") %>" class="img-fluid rounded-start" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <p class="card-text"><%# Eval("codigo") %></p>
                                <h5 class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><%# Eval("descripcion") %></p>
                                <p class="card-text"><%# Eval("fecha", "{0:dddd, dd 'de' MMMM 'de' yyyy}") %></p>
                            <div class="card-footer text-center"> 
                                <asp:LinkButton ID="Button2" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="Button2_Click">
                                    <i class="bi bi-file-plus"></i> Ver Detalles del Evento
                                </asp:LinkButton>
                                <asp:LinkButton ID="ButtonFavorite" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="ButtonFavorite_Click">
                                    <i class="bi bi-heart"></i> Favorito
                                </asp:LinkButton>
                            
                                <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" OnClick="Button1_Click">
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
</asp:Content>
