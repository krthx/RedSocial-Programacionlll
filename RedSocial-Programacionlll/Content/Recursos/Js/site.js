var Site = {};

Site.ui = {
	buscar: function (a, b, c) {
		jQuery.ajax({
			url: 'Tablero.aspx/BuscarPerfil',
			type: 'POST',
			dataType: 'json',
			data: "{ 'Busqueda:' + $('#TxtBusqueda').value }",
			contentType: "application/json; charset=utf-8",
			success: function (data) {
				console.log(JSON.stringify(data));

			}
		});
	},
	inicioTablero: function () {
		$('.special.card .image').dimmer({ on: 'hover' });

		$('#TxtBusqueda').on('keyup', buscar);
	}
}


$(document).ready(Site.ui.inicioTablero);