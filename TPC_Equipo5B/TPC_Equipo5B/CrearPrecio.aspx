<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearPrecio.aspx.cs" Inherits="TPC_Equipo5B.ModificarPrecio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Título de la página -->
    <h1 class="text-center" style="color: #F4F4F4;">Cargar Precio</h1>

    <!-- Mensaje de ayuda -->
    <div id="Crear" class="form-text text-center m-4" style="color: #F4F4F4;">
        Completa los campos para cargar los tipos y precios de entrada
    </div>

    <!-- Formulario de Crear Precio -->
    <div class="row justify-content-center">       
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lbl_Disponibilidad" runat="server" Text="Label" ForeColor="WhiteSmoke" Visible="false"></asp:Label>
            </div>
            <div class="mb-3">                
                <label for="txtEventos" class="form-label" style="color: #F4F4F4;">Eventos: </label>     
                <asp:TextBox runat="server" ID="txtEventos" CssClass="form-control" />
            </div>

            <!-- Ingreso de Tipo de Entrada y Precios -->

            <div class="mb-3">
                <label for="txtNombreEntrada" class="form-label me-2" style="color: #F4F4F4;">Nombre del tipo de entrada:</label>
                <asp:TextBox runat="server" ID="txtNombreEntrada" CssClass="form-control" placeholder="Ingrese descripción" />
            </div>
            <div class="mb-3">
                <label for="txtCantidad" class="form-label me-2" style="color: #F4F4F4;">Cantidad de entradas:</label>
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" placeholder="Entradas disponibles" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label me-2" style="color: #F4F4F4;">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="Ingrese precio" />
            </div>


            <div class="row mb-5">
                <div class="col-12 d-flex justify-content-center">
                    <asp:Button ID="BtnPrecio" runat="server" Text="Agregar Precio" CssClass="btn btn-success explore-btn" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
