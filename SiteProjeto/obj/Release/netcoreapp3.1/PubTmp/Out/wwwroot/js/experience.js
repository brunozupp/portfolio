﻿const CONTROLLER = "Experience";

// Assim que carregar a página
$(document).ready(function () {

    loadTable();
});

function loadTable() {

    var url = buildBaseURL(CONTROLLER, 'GetAll');

    $.get(url, function(response) {

        // Sucesso
        if (!response.error) {

            if (response.data.length > 0) {

                var trs = "";

                response.data.forEach(function (item) {
                    trs += `
                        <tr>
                            <td>${item.id}</td>
                            <td>${item.company}</td>
                            <td>${item.description}</td>
                            <td>${showDate(item.begin)}</td>
                            <td>${showDate(item.end)}</td>
                            <td>
                                <a href="/${CONTROLLER}/Save/${item.id}" title="Editar">
                                    <i class="fas fa-pen-square fa-2x"></i>
                                </a>
                                <a href="/${CONTROLLER}/Details/${item.id}" title="Detalhes">
                                    <i class="fas fa-list-alt fa-2x"></i>
                                </a>
                                <button class="deleteConfirmation btn btn-sm" data-value='{"id": ${item.id}}'
                                        data-controller="${CONTROLLER}" data-action="Delete" title="Deletar">
                                    <i class="fas fa-trash fa-2x"></i>
                                </button>
                            </td>
                        </tr>
                    `;
                });

                $("#tbodyLoad").empty();
                $("#tbodyLoad").append(trs);

                settings();
            }
        }
    });
}

function settings() {

    $(".deleteConfirmation").on('click', function (event) {

        var btn = $(this);

        var value = btn.data("value");
        var url = buildBaseURL(CONTROLLER, 'Delete');

        deleteRegister(url, value, loadTable);
    });
}

