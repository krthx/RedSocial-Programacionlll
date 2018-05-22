<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Tablero.aspx.cs" Inherits="RedSocial_Programacionlll.Perfil" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="ui two column doubling stackable grid container">
      <div class="column" style="width: 30%">
        <div class="ui card">
          <div class="image">
            <img src="https://semantic-ui.com/images/avatar2/large/kristy.png">
          </div>
          <div class="content">
            <a class="header"><%: Usuario.NombreUsuario %></a>
            <div class="meta">
              <span class="date">Se unió en <%: Usuario.Creacion.Year %></span>
            </div>
            <div class="description">
              <%: Usuario.Nombre %>
            </div>
          </div>
          <div class="extra content">
                <a>
                    <i class="user icon"></i>
                    <%: Usuario.Seguidores.Count %> Seguidores
                </a>
                <a>
                    <i class="user icon"></i>
                    <%: Usuario.Seguidos.Count %> Seguidos
                </a>
          </div>
        </div>

        <h3>Seguidos</h3>
        <hr />
        <div class="ui middle aligned selection list" style="height: 30%; margin-top: 10px; overflow-y: scroll">
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/helen.jpg">
            <div class="content">
              <div class="header">Helen</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/christian.jpg">
            <div class="content">
              <div class="header">Christian</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
        </div>
          
        <h3>Seguidores</h3>
        <hr />
        <div class="ui middle aligned selection list" style="height: 30%; margin-top: 10px;  overflow-y: scroll">
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/helen.jpg">
            <div class="content">
              <div class="header">Helen</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/christian.jpg">
            <div class="content">
              <div class="header">Christian</div>
            </div>
          </div>
          <div class="item">
            <img class="ui avatar image" src="/images/avatar/small/daniel.jpg">
            <div class="content">
              <div class="header">Daniel</div>
            </div>
          </div>
        </div>
      </div>
      <div class="column" style="width: 70%;">
        <div class="ui segment">
            <h3>¿Que es lo que piensas? Tienes 140 carácteres para decirlo</h3>
            <div class="ui comments">
                <div class="ui reply form">
                    <div class="field">
                      <textarea></textarea>
                    </div>
                    <div class="ui blue labeled submit icon button">
                      <i class="icon edit"></i> Add Reply
                    </div>
                </div>
            </div>
        </div>
        <div class="ui segment" style="background: #f1f1f1; height: auto; min-height: 500px;">
            <div class="ui raised card"  style="width: 100%;">
              <div class="content">
                <div class="header">Cute Dog</div>
                <div class="meta">
                  <span class="category">Animals</span>
                </div>
                <div class="description">
                  <p></p>
                </div>
              </div>
              <div class="extra content">
                <div class="right floated author">
                  <img class="ui avatar image" src="/images/avatar/small/matt.jpg"> Matt
                </div>
              </div>
            </div>
            
            <div class="ui raised card" style="width: 100%;">
              <div class="content">
                <div class="header">Cute Dog</div>
                <div class="meta">
                  <span class="category">Animals</span>
                </div>
                <div class="description">
                  <p></p>
                </div>
              </div>
              <div class="extra content">
                <div class="right floated author">
                  <img class="ui avatar image" src="/images/avatar/small/matt.jpg"> Matt
                </div>
              </div>
            </div>
        </div>
      </div>
    </div>

</asp:Content>