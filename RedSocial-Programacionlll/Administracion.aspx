<%@ Page Title="Administracion" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Intento2.Administracion" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Button runat="server" ID="BtnTwits" OnClick="btnTuits" Text="Leer TuiTs"  CssClass="ui green button"/>
        <asp:Button runat="server" ID="BtnUsuarios" OnClick="btnUsuario" Text="Leer Usuarios"  CssClass="ui green button"/>
        <asp:Button runat="server" ID="BtnSeguidos" OnClick="btnSeguidos" Text="Leer Seguidos"  CssClass="ui green button"/>
        <div runat="server" id="richTexbox"> </div>
    </div>
</asp:Content>
