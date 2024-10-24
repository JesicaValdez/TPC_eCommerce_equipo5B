<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisEntradas.aspx.cs" Inherits="TPC_Equipo5B.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="title-style" style="color: #F4F4F4; padding: 20px;">Eventos Favoritos</h1>
    <div class="row row-cols-1 row-cols-md-2 g-4">
    <asp:Repeater ID="rptArticulos" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card-group">
                    <div class="card mb-3" style="max-width: 540px;">
                        <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%# Eval("imagenurl") %>" class="img-fluid rounded-start" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                            <p class="card-text"><%# Eval("codigo") %></p>
                            <h5 class="card-title"><%# Eval("Evento.nombre") %></h5>
                            <p class="card-text"><%# Eval("Evento.descripcion") %></p>
                            <p class="card-text"><%# Eval("fechaCompra") %></p>
                        
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
