var Site = {};

Site.ui = {
	buscarPerfil: function (a, b, c) {

        console.log("Event");

        $.ajax({
            type: "GET",
            url: 'Tablero.aspx/BuscarPerfil?Busqueda="' + $('.txt-search')[0].value + '"',
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var src = JSON.parse(data.d),
                    searchSrc = [];
                console.log(src);

                Array.prototype.forEach.call(src, function (a, b, c) {
                    searchSrc.push({ title: a.NombreUsuario, category: a.Categoria, image: 'https://semantic-ui.com/images/avatar2/large/kristy.png' });
                });
                
                $('.ui.search')
                    .search({
                        type: 'category',
                        source: searchSrc,
                        onSelect: function (result, response) {
                            $.ajax({
                                type: "GET",
                                url: 'Tablero.aspx/VisitarPerfil?Usr="' + result.title + '"',
                                data: '',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    window.location.href = 'Perfil.aspx';
                                }
                            });
                        }
                    });
            },
            failure: function(response) {
                alert(response.d);
            }
        });
	},
    inicioTablero: function () {
        console.log("inicioTablero");
        $('.special.card .image').dimmer({ on: 'hover' });

        $('.txt-search').on('keyup', Site.ui.buscarPerfil);
    },
    VisitarPerfil: function (usr) {
        $.ajax({
            type: "GET",
            url: 'Tablero.aspx/VisitarPerfil?Usr="' + usr + '"',
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                window.location.href = 'Perfil.aspx';
            }
        });
    }
}

$(document).ready(Site.ui.inicioTablero);