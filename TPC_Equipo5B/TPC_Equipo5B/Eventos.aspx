﻿<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="TPC_Equipo5B.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 class="title-style" style="color: #F4F4F4; padding: 20px;">Proximos Eventos</h1>
    </div>
    <div class="col" style="padding: 20px; color: #F4F4F4;">
        <asp:Label ID="Label1" runat="server" Text="Filtrar por tipo de evento: "></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEventos" CssClass="btn btn-outline-dark dropdown-toggle" style="color: #F4F4F4; border-color: #F4F4F4;"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Filtrar" class="btn btn-primary" OnClick="Button1_Click" />
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card-group">
                        <div class="card h-100" style="width: 20rem; padding: 10px">
                            <div class="card-body">
                                <img class="card-img-top" src="<%# Eval("imagenurl") %>" />
                                <p style= "text-align: center" class="card-text"><%# Eval("fecha.date") %></p> 
                                <h5 class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><%# Eval("descripcion") %></p>

                                <asp:Button ID="Button2" runat="server" Text="Agregar al carrito" Class="btn btn-secondary" onclick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>