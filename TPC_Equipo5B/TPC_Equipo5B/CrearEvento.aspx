<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearEvento.aspx.cs" Inherits="TPC_Equipo5B.CrearEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Agregar ScriptManager antes de UpdatePanel -->
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <!-- Título de la página -->
    <h1 class="text-center" style="color: #F4F4F4;">Crear Evento</h1>

    <!-- Mensaje de ayuda -->
    <div id="Crear" class="form-text text-center m-4" style="color: #F4F4F4;">
        Completa los campos para crear un nuevo evento
    </div>


    <!-- Formulario de Crear Evento -->
    <div class="row">
        <div class="col-6">

            <!-- Código del Evento -->
            <div class="mb-3">
                <label for="txtCodigoEvento" class="form-label" style="color: #F4F4F4;">Código:</label>
                <asp:TextBox runat="server" ID="txtCodigoEvento" CssClass="form-control" placeholder="Ingrese código único del evento" />
                 <asp:Label ID="lblCodigoError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- Nombre del Evento -->
            <div class="mb-3">
                <label for="txtNombreEvento" class="form-label" style="color: #F4F4F4;">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombreEvento" CssClass="form-control" placeholder="Ingrese nombre del evento" />
                <asp:Label ID="lblNombreError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- Lugar del Evento -->
            <div class="mb-3">
                <label for="txtLugarEvento" class="form-label" style="color: #F4F4F4;">Lugar:</label>
                <asp:TextBox runat="server" ID="txtLugarEvento" CssClass="form-control" placeholder="Ingrese lugar del evento" />
                <asp:Label ID="lblLugarError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- Dirección del Evento -->
            <div class="mb-3">
                <label for="txDireccionEvento" class="form-label" style="color: #F4F4F4;">Dirección:</label>
                <asp:TextBox runat="server" ID="txtDireccionEvento" CssClass="form-control" placeholder="Ingrese dirección del evento" />
                <asp:Label ID="lblDireccionError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- Fecha del Evento -->
            <div class="mb-3">
                <label for="txtFechaEvento" class="form-label" style="color: #F4F4F4;">Fecha:</label>
                <asp:TextBox runat="server" ID="txtFechaEvento" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:Label ID="lblFechaEventoError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- Cantidad de Entradas-->
            <div class="mb-3">
                <label for="txtCantEntradas" class="form-label" style="color: #F4F4F4;">Cantidad Entradas:</label>
                <asp:TextBox runat="server" ID="txtCantEntradas" CssClass="form-control" placeholder="Ingrese cantidad de entradas" />
                <asp:Label ID="lblCantEntradasError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- Botón de Crear/Cancelar Evento -->
            <div class="mb-3">
                <asp:Button runat="server" ID="btnCrearEvento" Text="Crear Evento" class="btn btn-success mt-3" OnClick="btnCrearEvento_Click" />
                <asp:Button runat="server" ID="Button1" Text="Cancelar" class="btn btn-warning mt-3" OnClick="btnCancelar_Click" />
            </div>

            <!-- Mensaje de Resultado -->
            <div class="mb-3">
                <asp:Label runat="server" ID="lblResultado" CssClass="form-text text-center" />
            </div>
        </div>

        <!-- Tipo de Evento -->
        <div class="col-6">
            <div class="mb-3">
                <label for="ddlTipoEvento" class="form-label" style="color: #F4F4F4;">Tipo de Evento: </label>
                <asp:DropDownList runat="server" ID="ddlTipoEvento" CssClass="btn btn-secondary dropdown-toggle form-select">
                </asp:DropDownList>
            </div>

            <!-- Descripción del Evento -->
            <div class="mb-3">
                <label for="txtDescripcionEvento" class="form-label" style="color: #F4F4F4;">Descripción:</label>
                <asp:TextBox runat="server" ID="txtDescripcionEvento" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Ingrese una descripción del evento" />
                <asp:Label ID="lblDescripcionError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

            <!-- URL Imagenes del Evento -->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!-- Contenido dentro del UpdatePanel -->
                    <div class="mb-3">
                        <label for="txtImagenEvento" class="form-label" style="color: #F4F4F4;">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenEvento" CssClass="form-control" placeholder="Ingrese URL de la imagen del evento" 
                            AutoPostBack="true" OnTextChanged="txtImagenEvento_TextChanged" />
                        <asp:Label ID="lblImagenEventoError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgEvento" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
