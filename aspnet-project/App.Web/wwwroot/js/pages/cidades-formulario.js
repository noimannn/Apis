function salvar() {
    let obj = {
        cep: ($("[name='cep']").val() || ''),
        nome: ($("[name='nome']").val() || ''),
        uf: ($("[name='uf']").val() || '')
    };
    CidadeSalvar(obj).then(function () {
        window.location.href = '/cidades';
    }, function (err) {
        alert(err);
    });
}


function remover() {
    /*$("[name='id']").val() || ''

    document.querySelector()
    */

    let id = ($("[name='id']").val() || '');
    CidadeRemover(id).then(function () {
        window.location.href = '/cidades';
    }, function (err) {
        alert(err);
    });
}