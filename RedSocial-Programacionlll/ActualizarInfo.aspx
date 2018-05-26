<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarInfo.aspx.cs" Inherits="RedSocial_Programacionlll.ActualizarInfo" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="ui form">
        <h4 class="ui dividing header">Actualizar Datos</h4>
        <div class="field">
            <label>Name</label>
            <div class="field">
                <asp:TextBox  runat="server" ID="TxtNombre" type="text"  placeholder="Nombre"></asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label>Foto</label>
            <div class="field">
                <asp:TextBox runat="server" ID="TxtUsuario" type="text"   placeholder="Usuario" disabled="true"></asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label>Fecha Nacimiento</label>
            <div class="field">
                <asp:TextBox runat="server" ID="TxtFecha" type="date" placeholder="Fecha Nacimiento"></asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label>Foto</label>
            <div class="field">
                <asp:TextBox runat="server" ID="TxtFoto" type="text"  placeholder="Foto"></asp:TextBox>
            </div>
        </div>

        <asp:LinkButton runat="server" CssClass="ui green left labeled icon button" OnClick="ActualizarCambios" tabindex="0"  style="width: 200px;">
            <i class="save outline icon"></i> 
            Actualizar
        </asp:LinkButton>

        <br />
        <br />
        <asp:LinkButton runat="server" CssClass="ui red left labeled icon button" OnClick="EliminarCuenta" tabindex="0"  style="width: 200px;">
            <i class="exclamation triangle icon"></i>
            Eliminar Cuenta
        </asp:LinkButton>
    </div>
</asp:Content>