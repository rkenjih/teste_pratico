/// <reference path="../../Scripts/jquery-1.10.2.js" />
/// <reference path="../../Scripts/bootstrap.js" />

// Legal né, essas linhas mágicas aí de cima permitem o Visual Studio a montar o Intellisense do jQuery aqui como ele já faz com o C#.
// Não apague elas, elas são do bem.

"use strict"

var TAREFA2 = TAREFA2 || {
    Carregar: () => {
        $("[id$='_btnEstranho']").on('click', () => {
            return TAREFA2.Autodestruir();
        });
        /*Confesso que javascript não é o meu forte, sei apenas o básico e a maioria do código fiz pesquisando comandos*/
        $("[id$='_btnGravar']").on('click', () => {
            return TAREFA2.Validar();
        });

        $('input[id$="txtCpf"]').on('input', function () {
            let txtCpf = $(this);
            let value = txtCpf.val();

            value = value.replace(/\D/g, '');

            if (value.length > 0) {
                value = value.substr(0, 3) + '.' + value.substr(3, 3) + '.' + value.substr(6, 3) + '-' + value.substr(9, 2);
            }

            txtCpf.val(value);
        });

    },
    Autodestruir: () => {
        window.alert('Este computador se autodestruirá em 20 segundos...\r\nTodos os seus códigos serão descartados e não poderão ser recuperados.');
        window.setTimeout(() => {
            window.alert('A autodestruição era brincadeira tá!')
        }, 3000);
        return false;
    },
    Validar: ()=> {
        let campos = [];
        let valido = true;

        let valor = $('input[id$="txtNome"]').val().trim();
        if (valor === '') {
            campos.push("Nome");
            valido = false;
        }

        valor = $('input[id$="txtCpf"]').val().trim();
        if (valor === '') {
            campos.push("Cpf");
            valido = false;
        }

        valor = $('input[id$="txtRg"]').val().trim();
        if (valor === '') {
            campos.push("Rg");
            valido = false;
        }

        valor = $('input[id$="txtDataNascimento"]').val().trim();
        if (valor === '') {
            campos.push("Data Nascimento");
            valido = false;
        }

        if (!valido) {
            alert('Campos inválidos: ' + campos.join(', '));
        }
        return valido;
    }
}

// Isso aqui são coisas que usamos pra fazer os scripts funcionarem bem com o WebForms
// Pode ser que você tenha um código muito melhor!
// Use este modelo se preferir.

var postBackPage = postBackPage || Sys.WebForms.PageRequestManager.getInstance();

$(document).ready(function () {
    TAREFA2.Carregar();
});

postBackPage.add_endRequest(function () {
    TAREFA2.Carregar();
});