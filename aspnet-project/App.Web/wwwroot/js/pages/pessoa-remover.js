function remover() {
    PessoaDeletar(($("[name='id']").val())).then(function () {
        window.location.href = '/pessoa';
    }, function (err) {
        alert(err);
    });
}
$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let pessoa = $('[name="nome"]').val();
    PessoaListaPessoas(pessoa).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.id) + '</td>' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.email || '--') + '</td>' +
                '<td>' + (obj.senha || '--') + '</td>' +
                '</tr>');
        });
    });
}

