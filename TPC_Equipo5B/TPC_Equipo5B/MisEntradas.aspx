<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisEntradas.aspx.cs" Inherits="TPC_Equipo5B.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="title-style" style="color: #F4F4F4; padding: 20px;">Eventos Favoritos</h1>
    <div class="row row-cols-1 row-cols-md-1 g-4">
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
                            <p class="card-text">Cantidad: <%# cantidad( Eval("id")) %></p>
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
