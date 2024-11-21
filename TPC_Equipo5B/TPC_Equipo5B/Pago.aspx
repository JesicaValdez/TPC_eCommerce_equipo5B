<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="TPC_Equipo5B.Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col" style="background-color: #F4F4F4;">
        <h1 class="title-style" style="padding: 20px">FINALIZA TU COMPRA</h1>
        <div class="border-top my-3"></div>
        <div class="card">
            <div class="card-body">
                <div style="background-color: #F4F4F4">
                    <div style="font-size:x-large;">
                        <asp:Label ID="Label1" runat="server" Text="Resumen"></asp:Label>
                    </div>
                    <div style="font-size:larger">
                        <asp:Label ID="Label2" runat="server" Text="Subtotal: $"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="font-size:larger">
                        <asp:Label ID="Label3" runat="server" Text="Costo de servicio: $"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="font-size:larger">
                        <asp:Label ID="Label4" runat="server" Text="Total: $"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="border-top my-3"></div>
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-9">
                        <div style="font-size:x-large;">
                            <asp:Label ID="Label8" runat="server" Text="Informacion de pago"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="txtTarjeta" class="form-label">Numero de la tarjeta</label>
                            <asp:TextBox runat="server" ID="txtTarjeta" CssClass="form-control" />
                            <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" style="color:crimson" ControlToValidate="txtTarjeta" runat="server" />
                            <div>
                                <asp:Label ID="lblTarjeta" runat="server" Text="Ingrese los 16 digitos de la tarjeta" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            
                        </div>

                        <div class="row mb-3">
                            <div class="col-6">
                                <label for="txtCodigo" class="form-label">Codigo de seguridad</label>
                                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" style="color:crimson" ControlToValidate="txtCodigo" runat="server" />
                            </div>

                            <div class="col-3">
                                <label for="txtMes" class="form-label">Mes de vencimiento</label>
                                <asp:TextBox runat="server" ID="txtMes" CssClass="form-control" />
                                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" style="color:crimson" ControlToValidate="txtMes" runat="server" />
                            </div>
                            <div class="col-3">
                                <label for="txtAño" class="form-label">Año de vencimiento</label>
                                <asp:TextBox runat="server" ID="txtAño" CssClass="form-control" />
                                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" style="color:crimson" ControlToValidate="txtAño" runat="server" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-8">
                                <label for="txtTitular" class="form-label">Nombre completo del titular</label>
                                <asp:TextBox runat="server" ID="txtTitular" CssClass="form-control" />
                                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" style="color:crimson" ControlToValidate="txtTitular" runat="server" />
                            </div>

                            <div class="col-4">
                                <label for="txtDNI" class="form-label">DNI del titular</label>
                                <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
                                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" style="color:crimson" ControlToValidate="txtDNI" runat="server" />
                                <div>
                                    <asp:Label ID="lblDNI" runat="server" Text="Ingrese un DNI de 8 dígitos" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="border-top my-3"></div>
        <div class="card">
            <div class="card-body">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="E-Ticket" GroupName="Entrega" Checked/>
                <div class="card-text"><i class="bi bi-info-circle"></i> Una vez confirmada la operacion las entradas se enviaran por correo electronico a la casilla usada al registrarse</div>
                <div class="my-3"></div>
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Retiro en punto de entrega" GroupName="Entrega" />
                <div class="card-text"><i class="bi bi-info-circle"></i> Una vez confirmada la operacion se dispondra de 5 dias habiles para relirar las entradas por el punto de entrega de Av. Hipolito Yrigoyen 288, Gril. Pacheco, Tigre</div>
                
            </div>
        </div>
        <div style="text-align: center; padding: 50px">
            <div>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Acepto los terminios y condiciones de compra de TuTicket" />
                
            </div>
            <asp:Label runat="server" ID="lblTerminos" Text="Debe aceptar los terminos y condiciones para continuar" Visible="false" ForeColor="Red"/>
            <div>
                <asp:Button ID="Button1" class="btn btn-success btn-lg" runat="server" Text="Confirmar compra" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>
