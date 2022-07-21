// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//chamada do datatable

$('#table-lojas').dataTable({
    "ordering": false,
    "language": {
        "lengthMenu": "Mostrar _MENU_ linhas por página",
        "zeroRecords": "Nenhum registro encontrado",
        "info": "Mostrando _PAGE_ de _PAGES_",
        "infoEmpty": "Nenhum registro encontrado",
        "infoFiltered": "(Filtrando de _MAX_ Total registros)",
        "search": "Pesquisar",
        "paginate": {
            "first": "Primeiro",
            "last": "Ultimo",
            "next": "Seguinte",
            "previous": "Anterior"
        }
    }

});



$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

