<%@ Page Title="Inicio Sesion" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="RedSocial_Programacionlll.InicioSesion" %>

<asp:Content runat="server" ID="Background"  ContentPlaceHolderID="Background">    
    <div class="background-2"></div>
    <div class="background-cover"></div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %></h2>

    <div class="ui form" style="margin-top: 30%">
        <div class="ui container form-accent" style="width: 300px">

            <h4>Inicie sesión</h4>
            <hr />
            <br />
            
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <div class="field">
                <label>Nombre de Usuario</label>
                <asp:TextBox runat="server" ID="Usuario" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Usuario"
                    CssClass="ui negative message" ErrorMessage="El campo de usuario es obligatorio." />--%>
            </div>

            <div class="field">
                <label>Contraseña</label>
                <asp:TextBox runat="server" ID="Contrasena" TextMode="Password" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />--%>
            </div>

            <br />

            <div class="field">
                <asp:Button runat="server" OnClick="Registrarse" Text="Registrarse" CssClass="ui green button" />
                <asp:Button runat="server" OnClick="IniciarSesion" Text="Ir" CssClass="ui blue button" />
            </div>
        </div>
    </div>
</asp:Content>
