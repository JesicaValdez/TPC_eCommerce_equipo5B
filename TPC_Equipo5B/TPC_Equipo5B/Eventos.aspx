<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="TPC_Equipo5B.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Proximos Eventos</h1>
    <div class="col" style="padding: 50px">
        <asp:Label ID="Label1" runat="server" Text="Filtrar por tipo de evento: "></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEventos" CssClass="btn btn-outline-dark dropdown-toggle"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Filtrar" class="btn btn-primary" OnClick="Button1_Click" />
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <img src="<%# Eval("imagenurl") %>" />
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <asp:Button ID="Button2" runat="server" Text="Comprar" CssClass="btn btn-secondary" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>