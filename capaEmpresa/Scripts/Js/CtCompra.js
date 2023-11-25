$(function () {

    var objTablaCom = null;
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
                        (item.objCompra.estadoCompra ? '<span class="badge text-bg-success"><i>Pago</i></span>' : '<span class="badge text-bg-warning"><i>Pendiente</i></span>'),
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

    function listarProveedror() {
        return new Promise(function (resolve) {
            cargarAjax("MtdListarProveedor", function (datos) {
                if (datos) {
                    const selectProveedor = $("#btsProveedor");
                    selectProveedor.empty();
                    selectProveedor.append("<option disabled selected value='0'>Seleccione un proveedor</option>");
                    datos.forEach(function (item) {
                        selectProveedor.append("<option value=" + item.idUsuario + ">" + item.nombreUsuario + " " + item.apellidoUsuario + "</option>");
                    });
                    resolve();
                }
            })
        })
    }



    //compras
    $("#tablaCompras").on("click", "#btnDatos", async function () {
        var indiceFila = objTablaCom.row($(this).closest("tr")).index();
        var valores = todosDatosCom[indiceFila];
        await listarProveedror();
        $("#numeroCompra").html(valores.objCompra.numeroCompra);
        $("#txtFechaCompra").val(valores.objCompra.fechaCompra);
        $("#btsProveedor").val(valores.objCompra.objProveedor.idUsuario);
        $("#txtTell").val(valores.objCompra.objProveedor.tellUsuario);
        $("#txtInsumo").val(valores.objInsumo.nombreInsumo + " - " + valores.objInsumo.objMaterial.nombreMaterial);
        $("#txtCantidad").val(valores.cantidadCompra);
        $("#txtPrecio").val(valores.precioCompra);


        console.log(valores)
        $("#modalCompra").modal("show");






    })










})