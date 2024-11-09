<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPC_Equipo5B.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center" style="color: #F4F4F4;">Regístrate</h1>

    <div id="Crear" class="form-text text-center m-4" style="color: #F4F4F4;">Registra tu cuenta de TuTiket y disfruta de tus eventos favoritos</div>

    <div class="row justify-content-center">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtdni" class="form-label" style="color: #F4F4F4;">DNI</label>
                <asp:TextBox runat="server" ID="txtdni" CssClass="form-control" placeholder="Ingrese Dni" />
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>

            <div class="row mb-3">
                <div class="col">
                    <label for="txtNombre" class="form-label" style="color: #F4F4F4;">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese Nombre" />
                </div>

                <div class="col">
                    <label for="txtApellido" class="form-label" style="color: #F4F4F4;">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingrese Apellido" />
                </div>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <label for="txtCalendarioFN" class="form-label" style="color: #F4F4F4;">Fecha de Nacimiento</label>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="inputGroup-sizing-sm">
                            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="calendarClick" ImageUrl="~/icons8-calendar-24.png" />
                        </span>
                        <asp:TextBox runat="server" ID="txtCalendarioFN" CssClass="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" />
                    </div>

                    <asp:Calendar ID="calendarioFN" runat="server" CssClass="custom-calendar" OnSelectionChanged="calendarioSChanged"></asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="mb-3">
                <label for="txtTelefono" class="form-label" style="color: #F4F4F4;">Telefono</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Ingrese Telefono" />
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label" style="color: #F4F4F4;">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese Email" />
            </div>

            <div class="mb-3">
                <label for="txtUser" class="form-label" style="color: #F4F4F4;">Usuario</label>
                <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" placeholder="Ingrese Usuario" aria-describedby="emailHelp" />
            </div>

            <div class="mb-3">
                <label for="txtPass" class="form-label" style="color: #F4F4F4;">Contraseña</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" placeholder="Ingrese Contraseña" />
            </div>

            <div class="mb-3">
                <asp:Button ID="btn_registrar" runat="server" Text="Registrarse" class="btn btn-warning mt-3 w-100"/>
            </div>

        </div>
    </div>

</asp:Content>
