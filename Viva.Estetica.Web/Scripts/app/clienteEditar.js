$('document').ready(function () {
    var edicao = $('#edicao').val();

    if (edicao == '0')
        $('#editar *').attr('disabled', 'disabled').off('click');
});