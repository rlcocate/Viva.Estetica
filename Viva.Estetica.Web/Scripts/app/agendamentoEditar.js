$('document').ready(function () {

    var edicao = $('#edicao').val();

    if (edicao == '0')
        $('#editar *').attr('disabled', 'disabled').off('click');

});

function alterouServico() {

    $('#sessao').removeAttr('disabled');

    // Verifica se selecionou outros serviços.
    if ($('#servico').val() == '1') {

        //$('[id=sessao] option').filter(function () {
        //    return ($(this).text() == 'Unica');
        //}).prop('selected', true);

        $('#sessao').attr('disabled', 'disabled');
    }
}

function alterouSessao() {

    // 1 - Unica
    // 2 - Duas Sessões

    // Verifica se é sessão dupla;
    if ($('#sessao').val() == '2') {
        $('#Duracao').val(30);
        $('#Duracao').attr('disabled', 'disabled');
    } else {
        $('#Duracao').removeAttr('disabled');
    }
}
