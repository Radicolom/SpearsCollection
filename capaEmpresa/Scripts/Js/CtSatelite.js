$(function () {


    var objTablaSat = null;
    var todosLosDatos = [];

    crearTablaSatelite();

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


    function crearTablaSatelite() {
        cargarAjax('MtdListarSatelite', function (datos) {
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
        if (objTablaSat != null) {
            $("#tblSatelite").dataTable().fnDestroy();
        }

        objTablaSat = $("#tblSatelite").DataTable({
            data: dataSet,
            responsive: true,
            ordering: false,
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json"
            }
        })
    }


    function listarCiudad(lugar) {
        return new Promise(function (resolve) {
            cargarAjax('MtdListarCiudad', function (data) {
                switch (lugar) {
                    case "modal":
                        if (lugar) {
                            const selectRol = $("#btsCiudad");
                            selectRol.empty();
                            selectRol.append("<option disabled selected value='0'>Seleccione una ciudad</option>");
                            data.forEach(function (item) {
                                selectRol.append("<option value=" + item.idCiudad + ">" + item.nombreCiudad + "</option>");
                            });
                        }
                        break;
                }
            });
            resolve();
        });
    }

    function listarRol(lugar) {
        return new Promise(function (resolve) {
            cargarAjax('MtdListarRol', function (data) {
                switch (lugar) {
                    case "modal":
                        if (lugar) {
                            const selectRol = $("#btsTipoUsuario");
                            selectRol.empty();
                            selectRol.append("<option disabled selected value='0'>Seleccione un puesto</option>");
                            data.forEach(function (item) {
                                selectRol.append("<option value=" + item.idRol + ">" + item.nombreRol + "</option>");
                            });
                        }
                        break;
                    case lugar:
                        const listaRoles = $("#listaRoles");
                        listaRoles.empty();
                        data.forEach(function (item) {
                            listaRoles.append("<li><a class='dropdown-item' data-id='" + item.idRol + "'>" + item.nombreRol + "</a></li>");
                        });
                        break;
                }
                resolve();
            });
        });
    }

    async function abrirModal() {

        await listarCiudad("modal");
        await listarRol("modal");

        $("#formModal").modal("show");


        $("#txtDocumento").val("");
        $("#txtNombre").val("");
        $("#txtApellido").val("")
        $("#txtTell").val("")
        $("#txtCorreo").val("")
        $("#txtDireccion").val("")
        $("#btsEstado").val(0)
        $("#btsTipoUsuario").val(0)
        $("#btsCiudad").val(0)

    }

    $("#btnRegistrar").on("click", async function () {
        await abrirModal();
        $(".modal-title").html('<i class="fas fa-user-plus"></i> Agregar Usuario');
    });


    $("#Guardar").on("click", function () {
        $(".modal-body").LoadingOverlay("show");

        var registro = {
            idUsuario: cargado,
            documentoUsuario: $("#txtDocumento").val(),
            nombreUsuario: $("#txtNombre").val(),
            apellidoUsuario: $("#txtApellido").val(),
            tellUsuario: $("#txtTell").val(),
            correoUsuario: $("#txtCorreo").val(),
            direccionUsuario: $("#txtDireccion").val(),
            estadoUsuario: 1,
            objRol: {
                idRol: $("#btsTipoUsuario").val()
            },
            objCiudad: {
                idCiudad: $("#btsCiudad").val()
            }
        };

        const datos = JSON.stringify({ objUsuario: registro });

        cargarAjaxPost("/Home/MtdGuardarUsuario", datos, function (dato) {
            if (dato.data == 1) {
                guardado();
                ListarTablaUsuarios();
                cerrarModal();
            } else {
                $("#alertaUsuario").text(dato.mensaje);
                $("#alertaUsuario").show();
            }
            $(".modal-body").LoadingOverlay("hide");
        });
    })

})