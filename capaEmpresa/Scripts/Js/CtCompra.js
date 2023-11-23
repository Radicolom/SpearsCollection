﻿$(function () {

    var objTablaPro = null;
    var objTablaCom = null;
    var todosLosDatos = [];
    var todosDatosCom = [];
    crearTablaCompras();
    function cargarAjax(ruta, tarea) {
        $.ajax({
            url: "/DatoInsumo/" + ruta,
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

    function cargarDatos() {
        cargarAjax('/Home/MtdListarUsuario', function (data) {
            console.log(data);
        });
    }

    //Provedores
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
                            '<button id="btnProvedor" type="button" class="btn btn-primary"><i class="fas fa-hand-pointer"></i></button>' +
                            '</div>'
                    };
                    contar++;

                    dataSet.push([contar, item.documentoUsuario, item.nombreUsuario, item.apellidoUsuario, item.tellUsuario,
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

    //Compras
    function crearTablaCompras() {
        cargarAjax('MtdListarCompra', function (datos) {
            todosDatosCom = datos;
            if (datos != null) {
                var dataSet = [];
                var contar = 0;

                datos.forEach(listarCompra);

                function listarCompra(item, index) {

                    var objBotones = {
                        orderable: false,
                        searchable: false,
                        defaultContent: '<center>' +
                            '<button id="btnDatos" type="button" class="btn btn-primary btn-sm"><i class="fas fa-eye"></i></button>' +
                            '</center>'
                    };
                    contar++;

                    dataSet.push([contar, item.objCompra.numeroCompra, item.objCompra.fechaCompra,
                        (item.objCompra.estadoCompra ? '<span class="badge text-bg-success"><i>Activo</i></span>' : '<span class="badge text-bg-warning"><i>No Activo</i></span>'),
                        item.objCompra.objProveedor.nombreUsuario,
                        objBotones.defaultContent
                    ]);
                }

                armarTablaCompras(dataSet);
            }

        });
    }

    function armarTablaCompras(dataSet) {
        if (objTablaCom != null) {
            $("#tablaCompras").dataTable().fnDestroy();
        }

        objTablaCom = $("#tablaCompras").DataTable({
            data: dataSet,
            responsive: true,
            ordering: true,
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json"
            }
        })
    }

    //proveedor

    $("#btnProveedores").on("click", function () {

        $("#MdProveedor").modal("show");
        crearTablaProvedores();
    });

    $("#tblProveedor").on("click", "#btnProvedor", function () {
        var indiceFila = objTablaPro.row($(this).closest("tr")).index();
        var valorDeseado = todosLosDatos[indiceFila];
        $("#MdProveedor").modal("hide");
        $("#txtNumeroCompra").val(valorDeseado.idUsuario);

    })

    //compras
    $("#tablaCompras").on("click", "#btnDatos", function () {
        var indiceFila = objTablaCom.row($(this).closest("tr")).index();
        var valorDeseado = todosDatosCom[indiceFila];
        
        $("#modalCompra").modal("show");






    })










})