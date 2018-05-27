<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="RedSocial_Programacionlll.Perfil" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <% if (Usuario != null)
        { %>
        <div class="ui two column doubling stackable grid container">
          <div class="column" style="width: 30%">
            <asp:LinkButton runat="server" CssClass="ui blue left labeled icon button" OnClick="Regresar">
                <i class="left arrow icon"></i>
                Regresar al Tablero
            </asp:LinkButton>

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

              <asp:LinkButton runat="server" ID="SeguirBtn" OnClick="SeguirUsuario" CssClass="ui blue left labeled icon button" style="width: 200px">
                  <i class="user plus icon"></i> Seguir
              </asp:LinkButton>
              
            <asp:TextBox runat="server" ID="TxtHidden" Visible="false" ></asp:TextBox>

            <h3>Seguidos</h3>
            <hr />
            <div class="ui middle aligned selection list" style="height: 30%; margin-top: 10px; overflow-y: scroll">
              <% var Enumerator_ = Usuario.Seguidos.EnumeratorList;%>
                <% var NodoSeg = Enumerator_.Inicio; %>


                <% while (NodoSeg != null) { %>
	                <% var Registro = Usuario.Seguidos.Buscar(NodoSeg.Dato); %>
                    <% if(typeof(Usuario).Equals(Registro.GetType())) {%>
                        <% TxtHidden.Text = ((Usuario)Registro).NombreUsuario; %>
                        
                        <asp:LinkButton runat="server" data-usr="<%: TxtHidden.Text; %>" CssClass="itm-block" OnClick="VisitarPerfil">
                            <div class="item">
		                        <img class="ui avatar image" src="https://semantic-ui.com/images/avatar2/large/kristy.png">
		                        <div class="content">
		                          <div class="header"><%= TxtHidden.Text %></div>
		                        </div>
		                    </div>
                        </asp:LinkButton>

	                <%} else {%>
		                <% var Complex = (ListaEnlazada<Usuario>)Registro; %>
                        <% var NodoComp = Complex.Inicio; %>
                        <% while (NodoComp != null) { %>
                
                            <% TxtHidden.Text = NodoComp.Dato.NombreUsuario; %>
                            
                            <asp:LinkButton runat="server" data-usr="<%: TxtHidden.Text; %>" CssClass="itm-block" OnClick="VisitarPerfil">
                                <div class="item">
		                            <img class="ui avatar image" src="https://semantic-ui.com/images/avatar2/large/kristy.png">
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
            <div class="ui middle aligned selection list" style="height: 30%; margin-top: 10px;  overflow-y: scroll">
              <% var EnumeratorS = Usuario.Seguidores.EnumeratorList;%>
                <% var NodoSeg2 = EnumeratorS.Inicio; %>


                <% while (NodoSeg2 != null) { %>
	                <% var Registro2 = Usuario.Seguidores.Buscar(NodoSeg2.Dato); %>
                    <% if(typeof(Usuario).Equals(Registro2.GetType())) {%>
                        <% TxtHidden.Text = ((Usuario)Registro2).NombreUsuario; %>
                        
                        <asp:LinkButton runat="server" data-usr="<%: TxtHidden.Text; %>" CssClass="itm-block" OnClick="VisitarPerfil">
                            <div class="item">
		                        <img class="ui avatar image" src="https://semantic-ui.com/images/avatar2/large/kristy.png">
		                        <div class="content">
		                          <div class="header"><%= TxtHidden.Text %></div>
		                        </div>
		                    </div>
                        </asp:LinkButton>

	                <%} else {%>
		                <% var Complex2= (ListaEnlazada<Usuario>)Registro2; %>
                        <% var NodoComp2 = Complex2.Inicio; %>
                        <% while (NodoComp2 != null) { %>
                
                            <% TxtHidden.Text = NodoComp2.Dato.NombreUsuario; %>
                
                            <%--<asp:LinkButton runat="server" data-usr="<%: TxtHidden.Text; %>" CssClass="itm-block" OnClick="VisitarPerfil">--%>
                                <div class="item" onclick="Site.ui.VisitarPerfil('<%: NodoComp2.Dato.NombreUsuario %>')">
		                            <img class="ui avatar image" src="https://semantic-ui.com/images/avatar2/large/kristy.png">
		                            <div class="content">
		                              <div class="header"><%: NodoComp2.Dato.NombreUsuario %></div>
		                            </div>
		                        </div>
                            <%--</asp:LinkButton>--%>
                           <% NodoComp2 = NodoComp2.Enlace; %>
                        <% } %>

	                <% } %>

                   <% NodoSeg2 = NodoSeg2.Enlace; %>
                <% } %>
            </div>
          </div>
          <div class="column" style="width: 70%;">
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
    <% }
        else
        {
            Response.Redirect("Tablero.aspx");
        } %>
    

</asp:Content>