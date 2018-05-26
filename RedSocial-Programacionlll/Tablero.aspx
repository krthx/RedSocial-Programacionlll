<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Tablero.aspx.cs" Inherits="RedSocial_Programacionlll.Tablero" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" Runat="Server"> 
        

    </asp:ScriptManager>
    <div class="ui two column doubling stackable grid container">
      <div class="column" style="width: 30%">
        <div class="ui special card">
          <div class="blurring dimmable image">
              <div class="ui dimmer">
                <div class="content">
                  <div class="center">
                      <asp:LinkButton runat="server" OnClick="CerrarSesion" CssClass="ui blue icon button">
                          <i class="power off icon"></i>
                      </asp:LinkButton>
                      <asp:LinkButton runat="server" OnClick="ActualizarDatos" CssClass="ui blue icon button">
                          <i class="pencil alternate icon"></i>
                      </asp:LinkButton>
                  </div>
                </div>
              </div>
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
                  <i class="paper plane icon"></i>
                    <%: Usuario.Publicaciones.Count %> Publicaciones
              </a>
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
        <div class="ui middle aligned selection list" style="height: 300px; margin-top: 10px; overflow-y: scroll">
            <asp:TextBox runat="server" ID="TxtHidden" Visible="false" ></asp:TextBox>
            <% var Enumerator_ = Usuario.Seguidos.EnumeratorList;%>
            <% var NodoSeg = Enumerator_.Inicio; %>

            <% while (NodoSeg != null) { %>
	            <% var Registro = Usuario.Seguidos.Buscar(NodoSeg.Dato); %>
                <% if(typeof(Usuario).Equals(Registro.GetType())) {%>
                    <% var item = (Usuario)Registro; %>
                    <% TxtHidden.Text = item.NombreUsuario; %>

                    <asp:LinkButton runat="server" data-usr="<%= TxtHidden.Text %>" CssClass="itm-block" OnClick="VisitarPerfil">
                        <div class="item">
		                    <img class="ui avatar image" src="https://semantic-ui.com/images/avatar/small/helen.jpg">
		                    <div class="content">
		                      <div class="header"><%= TxtHidden.Text %></div>
		                    </div>
		                </div>
                    </asp:LinkButton>

	            <%} else {%>
		            <% var Complex = (ListaEnlazada<Usuario>)Registro; %>
                    <% var NodoComp = Complex.Inicio; %>
                    <% while (NodoComp != null) { %>
                        <% var ncItem = NodoComp.Dato; %>
                        <% TxtHidden.Text = ncItem.NombreUsuario; %>
            
                        <asp:LinkButton runat="server" data-usr="<%= TxtHidden.Text %>" CssClass="itm-block" OnClick="VisitarPerfil">
                            <div class="item">
		                        <img class="ui avatar image" src="https://semantic-ui.com/images/avatar/small/helen.jpg">
		                        <div class="content">
		                          <div class="header"><%= TxtHidden.Text %></div>
		                        </div>
		                    </div>
                        </asp:LinkButton>

                       <% NodoComp = NodoComp.Enlace; %>
                    <% } %>

	            <% } %>

               <% NodoSeg = NodoSeg.Enlace; %>
            <% } %>
        </div>
          
        <h3>Seguidores</h3>
        <hr />
        <div class="ui middle aligned selection list" style="height: 300px; margin-top: 10px;  overflow-y: scroll">
            <% var EnumeratorS = Usuario.Seguidores.EnumeratorList;%>
            <% var NodoSeg2 = EnumeratorS.Inicio; %>


            <% while (NodoSeg2 != null) { %>
	            <% var Registro2 = Usuario.Seguidores.Buscar(NodoSeg2.Dato); %>
                <% if(typeof(Usuario).Equals(Registro2.GetType())) {%>
                    <% var item2 = (Usuario)Registro2; %>
                    <% TxtHidden.Text = item2.NombreUsuario; %>
                    
                    <asp:LinkButton runat="server" data-usr="<%= TxtHidden.Text %>" CssClass="itm-block" OnClick="VisitarPerfil">
                        <div class="item">
		                    <img class="ui avatar image" src="https://semantic-ui.com/images/avatar/small//helen.jpg">
		                    <div class="content">
		                      <div class="header"><%= TxtHidden.Text %></div>
		                    </div>
		                </div>
                    </asp:LinkButton>

	            <%} else {%>
		            <% var Complex2= (ListaEnlazada<Usuario>)Registro2; %>
                    <% var NodoComp2 = Complex2.Inicio; %>
                    <% while (NodoComp2 != null) { %>
                        <% var nssItem = NodoComp2.Dato; %>
                        <% TxtHidden.Text = nssItem.NombreUsuario; %>

                        <asp:LinkButton runat="server" data-usr="<%= TxtHidden.Text %>" CssClass="itm-block" OnClick="VisitarPerfil">
                            <div class="item">
		                        <img class="ui avatar image" src="https://semantic-ui.com/images/avatar/small/helen.jpg">
		                        <div class="content">
		                          <div class="header"><%= TxtHidden.Text %></div>
		                        </div>
		                    </div>
                        </asp:LinkButton>

                       <% NodoComp2 = NodoComp2.Enlace; %>
                    <% } %>

	            <% } %>

               <% NodoSeg2 = NodoSeg2.Enlace; %>
            <% } %>

        </div>
      </div>
      <div class="column" style="width: 70%;">
        <div class="ui search">
          <div class="ui icon input" style="width: 100%">
            <asp:TextBox runat="server" class="prompt txt-search" type="text" id="TxtBusqueda" placeholder="Buscar usuarios..."></asp:TextBox>
            <i class="search icon"></i>
          </div>
          <div runat="server" class="results"></div>
        </div>
        <div class="ui segment">
            <h3>¿Que es lo que piensas? Tienes 140 carácteres para decirlo</h3>
            <div class="ui comments">
                <div class="ui reply form">
                    <div class="field">
                      <asp:TextBox runat="server" ID="TxtPublicacion" TextMode="multiline" Columns="50" Rows="5" ></asp:TextBox>
                    </div>
                    <asp:LinkButton runat="server" CssClass="ui blue labeled submit icon button" OnClick="AgregarPublicacion"><i class="edit outline icon"></i>Publicar</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="ui segment" style="background: #f1f1f1; height: auto; min-height: 500px;">
            <% var NodoPub = Usuario.Muro.Primero; %>
            
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
    <asp:LinkButton runat="server" ID="hiddenButton" Visible="false" data-usr="" OnClick="VisitarPerfil"></asp:LinkButton>
</asp:Content>