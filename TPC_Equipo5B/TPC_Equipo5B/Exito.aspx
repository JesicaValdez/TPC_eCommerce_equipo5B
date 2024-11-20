<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="TPC_Equipo5B.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f5f5f5; 
            color: #333; 
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .success-container {
            text-align: center;
            padding: 20px 30px;
            background-color: #fff;
            border: 1px solid #ddd; 
            border-radius: 8px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1); 
        }
        .success-container h1 {
            font-size: 2rem;
            margin-bottom: 15px;
            color: #5cb85c; 
        }
        .success-container p {
            font-size: 1rem;
            margin-bottom: 20px;
            color: #555; 
        }
        .success-container .icon {
            font-size: 3rem;
            margin-bottom: 20px;
            color: #5cb85c;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="success-container">
        <div class="icon">✅</div>
        <h1>¡Operación exitosa!</h1>
        <p>La acción se completó correctamente.</p>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        <br />
        <a href="Default.aspx" class="btn btn-success">Volver a la página principal</a>
    </div>
</asp:Content>
