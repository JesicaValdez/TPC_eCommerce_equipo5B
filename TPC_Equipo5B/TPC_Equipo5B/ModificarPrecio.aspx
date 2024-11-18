<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarPrecio.aspx.cs" Inherits="TPC_Equipo5B.ModificarPrecio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Título de la página -->
    <h1 class="text-center" style="color: #F4F4F4;">Actualizar Precio</h1>

    <!-- Mensaje de ayuda -->
    <div id="Crear" class="form-text text-center m-4" style="color: #F4F4F4;">
        Completa los campos para modificar el evento
    </div>

    <!-- Formulario de Crear Evento -->
    <div class="row mb-3">
        <!-- Columna para los tres campos -->
        <div class="col-12 d-flex justify-content-between">
            <!-- Campo Nombre -->
            <div class="col-4 d-flex flex-column align-items-start mb-3">
                <label for="txtNombreEntrada" class="form-label" style="color: #ffb700;">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombreEntrada" CssClass="form-control" placeholder="Ingrese descripción" Style="margin-right: 15px;" />
            </div>

            <!-- Campo Cantidad de Entradas -->
            <div class="col-4 d-flex flex-column align-items-start mb-3">
                <label for="txtCantidad" class="form-label" style="color: #ffb700;">Cantidad de entradas:</label>
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" placeholder="Entradas disponibles" Style="margin-right: 15px;" />
            </div>

            <!-- Campo Precio -->
            <div class="col-4 d-flex flex-column align-items-start mb-3">
                <label for="txtPrecio" class="form-label" style="color: #ffb700;">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="Ingrese precio" />
            </div>
        </div>
    </div>

    <!-- Botón de Agregar Precio -->
    <div class="row mb-5">
        <div class="col-12 d-flex justify-content-center">
            <asp:Button ID="BtnPrecio" runat="server" Text="Guardar" CssClass="btn btn-success explore-btn" OnClick="btnGuardar_Click" />
        </div>
    </div>



</asp:Content>
