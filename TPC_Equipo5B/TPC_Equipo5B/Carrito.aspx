<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_Equipo5B.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="title-style" style="color: #F4F4F4;">Mi Carrito</h1>
    <div class="row row-cols-1 row-cols-md-1 g-4">
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
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                            
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="container p-4" style="margin-top: 50px; color: #F4F4F4;">
        <asp:Label ID="Label1" runat="server" Text="TOTAL: $"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="container p-4">
        <asp:Button ID="Button1" runat="server" Text="Ir a pagar" class="btn me-2" style="color: #F4F4F4; border-color: #F4F4F4;" OnClick="Button1_Click" />
    </div>
</asp:Content>
