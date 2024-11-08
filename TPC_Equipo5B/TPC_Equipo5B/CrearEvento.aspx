<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearEvento.aspx.cs" Inherits="TPC_Equipo5B.CrearEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar metas, estilos adicionales o scripts -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center" style="color: #F4F4F4;">Crear Evento</h1>

    <div id="Crear" class="form-text text-center m-4" style="color: #F4F4F4;">
        Completa los campos para crear un nuevo evento
    </div>

    <div class="row justify-content-center">
        <div class="col-6">

            <!-- Código del Evento -->
            <div class="mb-3">
                <label for="txtCodigoEvento" class="form-label" style="color: #F4F4F4;">Código del Evento</label>
                <asp:TextBox runat="server" ID="txtCodigoEvento" CssClass="form-control" placeholder="Ingrese código único del evento" />
            </div>

            <!-- Nombre del Evento -->
            <div class="mb-3">
                <label for="txtNombreEvento" class="form-label" style="color: #F4F4F4;">Nombre del Evento</label>
                <asp:TextBox runat="server" ID="txtNombreEvento" CssClass="form-control" placeholder="Ingrese nombre del evento" />
            </div>

            <!-- Descripción del Evento -->
            <div class="mb-3">
                <label for="txtDescripcionEvento" class="form-label" style="color: #F4F4F4;">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcionEvento" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Ingrese una descripción del evento" />
            </div>

            <!-- Fecha del Evento -->
            <div class="mb-3">
                <label for="txtFechaEvento" class="form-label
                    " style="color: #F4F4F4;">Fecha del Evento</label>
                <asp:TextBox runat="server" ID="txtFechaEvento" CssClass="form-control" placeholder="Ingrese fecha del evento" />
                </div>

            <!-- URL Imagenes del Evento -->
            <div class="mb-3">
                <label for="txtImagenEvento" class="form-label
                    " style="color: #F4F4F4;">URL Imagenes del Evento</label>
                <asp:TextBox runat="server" ID="txtImagenEvento" CssClass="form-control" placeholder="Ingrese URL de la imagen del evento" />
                </div>

            <!-- Tipo de Evento -->
            <div class="mb-3">
                <label for="ddlTipoEvento" class="form-label
                    " style="color: #F4F4F4;">Tipo de Evento</label>
                <asp:DropDownList runat="server" ID="ddlTipoEvento" CssClass="form-control">
                    <asp:ListItem Text="Seleccionar Tipo de Evento" />
                    <asp:ListItem Text="Recital" Value="Recital" />
                    <asp:ListItem Text="Obra de Teatro" Value="Obra de Teatro" />
                    <asp:ListItem Text="Show" Value="Show" />
                    </asp:DropDownList>
                </div>

            <!-- Lugar del Evento -->
            <div class="mb-3">
                <label for="txtLugarEvento" class="form-label
                    " style="color: #F4F4F4;">Lugar del Evento</label>
                <asp:TextBox runat="server" ID="txtLugarEvento" CssClass="form-control" placeholder="Ingrese lugar del evento" />
                </div>

            <!-- Entradas Disponibles -->
            <div class="mb-3">
                <label for="txtEntradasDisponibles" class="form-label
                    " style="color: #F4F4F4;">Entradas Disponibles</label>
                <asp:TextBox runat="server" ID="txtEntradasDisponibles" CssClass="form-control" placeholder="Ingrese cantidad de entradas disponibles" />
                </div>

            <!-- Precio del Evento -->



            <!-- Botón de Crear Evento -->
            <asp:Button runat="server" ID="btnCrearEvento" Text="Crear Evento" class="btn btn-success mt-3" OnClick="btnCrearEvento_Click" />

            <asp:Label runat="server" ID="lblResultado" CssClass="form-text text-center" />

        </div>
    </div>
</asp:Content>
