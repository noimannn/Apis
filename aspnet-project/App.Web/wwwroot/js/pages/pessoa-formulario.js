function salvar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        email: ($("[name='email']").val() || ''),
        senha: ($("[name='senha']").val() || '')
    };
    PessoaSalvar(obj).then(function () {
        window.location.href = '/pessoa';
    }, function (err) {
        alert(err);
    });
}
