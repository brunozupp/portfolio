// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// https://localhost:44361
const URL_BASE = window.location.origin;

$('input[type="file"]').change(function (e) {
    var fileName = e.target.files[0].name;
    $('.custom-file-label').html(fileName);
});

function loadFile (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};

function buildBaseURL(controller, action) {
    return URL_BASE + "/" + controller + "/" + action;
}

function showDate(value) {
    if (value === null || value === "") return "Não informado";

    var datePart = value.split('T')[0];
    var parts = datePart.split('-');

    // Realmente no formato americano
    if (parts[0].length === 4) {
        var day = parts[2];
        var month = parts[1];
        var year = parts[0];

        return `${day}/${month}/${year}`;
    }

    // Para evitar qualquer falta de informação, retorna o que veio
    return value;
}

function deleteRegister(url, data, callback) {
    $.confirm({
        title: 'Remoção de registro!',
        content: 'Essa ação é irreversível, tem certeza que deseja deletar?',
        type: 'red',
        typeAnimated: true,
        buttons: {
            Yes: {
                text: 'Sim',
                btnClass: 'btn-red',
                action: function () {

                    $.get(url, data, function (response) {

                        console.log(response);

                        // Sucesso
                        if (!response.error) {

                            // Chamar função de reload da tabela
                            callback();

                            // Chamar o toast de sucesso
                            toastr.success('Registro deletado com sucesso', 'Sucesso!')

                        } else {

                            // Chamar o toast de erro
                            toastr.error('Registro não deletado', 'Erro!')
                        }
                    });

                }
            },
            Voltar: function () {

            }
        }
    });
}

function notification(type, content, title) {

    switch (type) {

        case "success":
            notificationSuccess(content, title);
            break;

        case "error":
            notificationError(content, title);

        default:
            return;
    }
}

function notificationSuccess(content,title) {

    if (content == null || content == "")
        content = "Operação realizada com sucesso";

    if (title == null || title == "")
        title = "Sucesso!";

    toastr.success(content, title);
}

function notificationError(content, title) {

    if (content == null || content == "")
        content = "Operação não realizada";

    if (title == null || title == "")
        title = "Erro!";

    toastr.error(content, title);
}