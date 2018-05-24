<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Tablero.aspx.cs" Inherits="RedSocial_Programacionlll.Tablero" %>


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
              <a>
                  <i class="paper plane icon"></i>
                    <%: Usuario.Publicaciones.Count %> Pubs
              </a>
          </div>
        </div>

        <h3>Seguidos</h3>
        <hr />
        <div class="ui middle aligned selection list" style="height: 300px; margin-top: 10px; overflow-y: scroll">
            <% var Enumerator_ = Usuario.Seguidores.EnumeratorList;%>
            <% var NodoSeg = Enumerator_.Inicio; %>


            <% while (NodoSeg != null) { %>
	            <% var Registro = Usuario.Seguidores.Buscar(NodoSeg.Dato); %>
                <% if(typeof(Usuario).Equals(Registro.GetType())) {%>
    
                    <div class="item">
		                <img class="ui avatar image" src="/images/avatar/small/helen.jpg">
		                <div class="content">
		                  <div class="header"><%: ((Usuario)Registro).NombreUsuario %></div>
		                </div>
		            </div>

	            <%} else {%>
		            <% var Complex = (ListaEnlazada<Usuario>)Registro; %>
                    <% var NodoComp = Complex.Inicio; %>
                    <% while (NodoComp != null) { %>
                        <div class="item">
		                    <img class="ui avatar image" src="/images/avatar/small/helen.jpg">
		                    <div class="content">
		                      <div class="header"><%: ((Usuario)NodoComp.Dato).NombreUsuario %></div>
		                    </div>
		                </div>
                       <% NodoComp = NodoComp.Enlace; %>
                    <% } %>

	            <% } %>

               <% NodoSeg = NodoSeg.Enlace; %>
            <% } %>
          <%--<div class="item">
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
          </div>--%>
        </div>
          
        <h3>Seguidores</h3>
        <hr />
        <div class="ui middle aligned selection list" style="height: 300px; margin-top: 10px;  overflow-y: scroll">
            <% var EnumeratorS = Usuario.Seguidos.EnumeratorList;%>
            <% var NodoSeg2 = EnumeratorS.Inicio; %>


            <% while (NodoSeg2 != null) { %>
	            <% var Registro2 = Usuario.Seguidos.Buscar(NodoSeg2.Dato); %>
                <% if(typeof(Usuario).Equals(Registro2.GetType())) {%>
    
                    <div class="item">
		                <img class="ui avatar image" src="/images/avatar/small/helen.jpg">
		                <div class="content">
		                  <div class="header"><%: ((Usuario)Registro2).NombreUsuario %></div>
		                </div>
		            </div>

	            <%} else {%>
		            <% var Complex2= (ListaEnlazada<Usuario>)Registro2; %>
                    <% var NodoComp2 = Complex2.Inicio; %>
                    <% while (NodoComp2 != null) { %>
                        <div class="item">
		                    <img class="ui avatar image" src="/images/avatar/small/helen.jpg">
		                    <div class="content">
		                      <div class="header"><%: ((Usuario)NodoComp2.Dato).NombreUsuario %></div>
		                    </div>
		                </div>
                       <% NodoComp2 = NodoComp2.Enlace; %>
                    <% } %>

	            <% } %>

               <% NodoSeg2 = NodoSeg2.Enlace; %>
            <% } %>
          <%--<div class="item">
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
          </div>--%>
        </div>
      </div>
      <div class="column" style="width: 70%;">
        <div class="ui search">
          <div class="ui icon input" style="width: 100%">
            <input class="prompt" type="text" placeholder="Buscar usuarios...">
            <i class="search icon"></i>
          </div>
          <div class="results"></div>
        </div>
        <div class="ui segment">
            <h3>¿Que es lo que piensas? Tienes 140 carácteres para decirlo</h3>
            <div class="ui comments">
                <div class="ui reply form">
                    <div class="field">
                      <asp:TextBox runat="server" ID="TxtPublicacion" TextMode="multiline" Columns="50" Rows="5" ></asp:TextBox>
                    </div>
                    <asp:Button runat="server" CssClass="ui blue submit icon button" OnClick="AgregarPublicacion" Text="Publicar"/>
                </div>
            </div>
        </div>
        <div class="ui segment" style="background: #f1f1f1; height: auto; min-height: 500px;">
            <% var NodoPub = Usuario.Publicaciones.Primero; %>
            
            <% while (NodoPub != null) { %>
                <% var Pub = (Publicacion) NodoPub.Dato; %>
                <div class="ui raised card" style="width: 100%;">
                  <div class="content">
                    <div class="header"><%: Usuario.Nombre %></div>
                    <div class="meta">
                      <span class="category"><%: Pub.FechaCreacion.ToString("dd/MMM/yyyy hh:mm") %></span>
                    </div>
                    <div class="description">
                        <p><%: Pub.Descripcion %></p>
                    </div>
                  </div>
                  <div class="extra content">
                    <%: Pub.Dislikes %><i class="thumbs down outline icon"></i>
                    <%: Pub.Likes %><i class="thumbs up outline icon"></i>
                    <div class="right floated author">
                      <img class="ui avatar image" src="https://semantic-ui.com/images/avatar2/large/kristy.png"> <%: Usuario.NombreUsuario %>
                    </div>
                  </div>
                </div>
               <% NodoPub = NodoPub.Siguiente; %>
            <% } %>
        </div>
      </div>
    </div>

</asp:Content>