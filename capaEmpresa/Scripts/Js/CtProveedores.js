$(function() {

    var objTablaPro = null;
    var todosLosDatos = [];

    crearTablaProvedores();

    function cargarAjax(ruta, tarea) {
        $.ajax({
            url: "/Home/" + ruta,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function (data) {
            if (tarea) {
                tarea(data.data);
            } else {
                console.log("Error en la solicitud AJAX: ");
                tarea([]);
            }
        }).always(function () {
            $.LoadingOverlay("hide");
        });
    }

    function cargarAjaxPost(ruta, datos, tarea) {
        $.ajax({
            url: ruta,
            type: "POST",
            data: datos,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function (data) {
            if (tarea) {
                tarea(data);
            } else {
                console.log("Error en la tarea AJAXPos: ");
                tarea([]);
            }
        }).fail(function (er) {
            console.error(er);
            error(er);
        }).always(function () {
            $.LoadingOverlay("hide");
        });
    }


    function crearTablaProvedores() {
        cargarAjax('MtdListarProveedor', function (datos) {
            todosLosDatos = datos;
            if (datos != null) {
                var dataSet = [];
                var contar = 0;

                datos.forEach(listarUsuarios);

                function listarUsuarios(item, index) {

                    var objBotones = {
                        orderable: false,
                        searchable: false,
                        defaultContent: '<div class="btn-group">' +
                            '<button id="btnProvedor" type="button" class="btn btn-primary btn-sm"><i class="fas fa-hand-pointer"></i></button>' +
                            '<button id="btnProvedor" type="button" class="btn btn-primary btn-sm"><i class="fas fa-hand-pointer"></i></button>' +
                            '</div>'
                    };
                    contar++;

                    dataSet.push([contar, item.documentoUsuario, item.nombreUsuario, item.apellidoUsuario, item.tellUsuario, item.objRol.nombreRol,
                        (item.estadoUsuario ? '<span class="badge text-bg-success"><i>Activo</i></span>' : '<span class="badge text-bg-warning"><i>No Activo</i></span>'),
                        objBotones.defaultContent

                    ]);
                }

                armarTablaProveedores(dataSet);
            }

        });
    }

    function armarTablaProveedores(dataSet) {
        if (objTablaPro != null) {
            $("#tblProveedor").dataTable().fnDestroy();
        }

        objTablaPro = $("#tblProveedor").DataTable({
            data: dataSet,
            responsive: true,
            ordering: false,
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json"
            }
        })
    }



})