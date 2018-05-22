<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="RedSocial_Programacionlll.Login" %>

<asp:Content runat="server" ID="Background"  ContentPlaceHolderID="Background">    
    <div class="background"></div>
    <div class="background-cover"></div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %></h2>
    <div class="ui form" style="margin-top: 30%">
        <div class="ui container form-accent" style="width: 330px">

            <h4>Cree una cuenta nueva</h4>
            <hr />
            <br />

            <p class="text-danger">
                <asp:Label runat="server" ID="ErrorMessage" />
            </p>

            
            <div class="field">
                <label>Nombre</label>
                <asp:TextBox runat="server" ID="Nombre" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre"
                    CssClass="ui negative message" ErrorMessage="El campo de nombre es obligatorio." />--%>
            </div>
        
            <div class="field">
                <label>Nombre de Usuario</label>
                <asp:TextBox runat="server" ID="Usuario" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Usuario"
                    CssClass="ui negative message" ErrorMessage="El campo de usuario es obligatorio." />--%>
            </div>

            <div class="field">
                <label>Fecha de Nacimiento</label>
                <asp:TextBox  runat="server" type="date" ID="FechaNacimiento" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre"
                    CssClass="ui negative message" ErrorMessage="El campo de nombre es obligatorio." />--%>
            </div>

            <div class="field">
                <label>Contraseña</label>
                <asp:TextBox runat="server" ID="Contrasena" TextMode="Password" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />--%>
            </div>

            <div class="field">
                <label>Confirmar contraseña</label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                <asp:CompareValidator runat="server" ControlToCompare="Contrasena" ControlToValidate="ConfirmaContrasena"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />--%>
            </div>
            
            <br />

            <div class="field">
                <asp:Button runat="server" OnClick="IniciarSesion" Text="¿Ya tienes cuenta?" CssClass="ui green button" />
                <asp:Button runat="server" OnClick="CrearCuenta" Text="Registrarse" CssClass="ui blue button" />
            </div>
        </div>
    </div>
</asp:Content>
