<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarInfo.aspx.cs" Inherits="RedSocial_Programacionlll.ActualizarInfo" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h4 class="ui dividing header">Shipping Information</h4>
    <div class="field">
        <label>Name</label>
        <div class="field">
        <input type="text" name="shipping[first-name]" placeholder="First Name">
        </div>
    </div>
    <div class="field">
        <label>Billing Address</label>
        <div class="twelve wide field">
            <input type="text" name="shipping[address]" placeholder="Street Address">
        </div>
    </div>

    <div class="ui button" tabindex="0">Actualizar</div>
</asp:Content>