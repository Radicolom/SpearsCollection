$(function () {

    cargarDatos();
    ListarTablaUsuarios()
    listarRol();

    var objTabla = null;
    var todosLosDatos = [];
    var cargado = 0;

    function cargarAjax(ruta, tarea) {
        $.ajax({
            url: ruta,
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

    function ListarTablaUsuarios(datos) {
        cargarAjax('/Home/MtdListarUsuario', function (datos) {
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
                            '<button id="btnEditar" type="button" class="btn btn-primary"><i class="fas fa-pen"></i></button>' +
                            '<button id="btnEliminar" type="button" class="btn btn-danger"><i class="fas fa-trash"></i></button>' +
                            '</div>'
                    };
                    contar++;

                    dataSet.push([contar, item.documentoUsuario, item.nombreUsuario, item.apellidoUsuario, item.tellUsuario, item.objRol.nombreRol,
                        (item.estadoUsuario ? '<span class="badge text-bg-success"><i>Activo</i></span>' : '<span class="badge text-bg-warning"><i>No Activo</i></span>'),
                        objBotones.defaultContent
                    ]);
                }

                armarTablaUsuarios(dataSet);
            }

        });

    }

    function armarTablaUsuarios(dataSet) {
        if (objTabla != null) {
            $("#tablaUsuarios").dataTable().fnDestroy();
        }

        objTabla = $("#tablaUsuarios").DataTable({
            data: dataSet,
            responsive: true,
            ordering: true,
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json"
            }
        })
    }

    function listarCiudad(lugar) {
        cargarAjax('/Home/MtdListarCiudad', function (data) {
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
    }

    function listarRol(lugar) {
        cargarAjax('/Home/MtdListarRol', function (data) {
            switch (lugar) {
                case lugar:
                    const listaRoles = $("#listaRoles");
                    listaRoles.empty();
                    data.forEach(function (item) {
                        listaRoles.append("<li><a class='dropdown-item' data-id='" + item.idRol + "'>" + item.nombreRol + "</a></li>");
                    });
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
            }
        });
    }

    function abrirModal() {

        $("#formModal").modal("show");

        listarRol("modal");
        listarCiudad("modal");

        $("#txtDocumento").val("");
        $("#txtNombre").val("");
        $("#txtApellido").val("")
        $("#txtTell").val("")
        $("#txtCorreo").val("")
        $("#txtDireccion").val("")
        $("#btsEstado").val("")
        $("#btsTipoUsuario").val("")
        $("#btsCiudad").val("")

    }

    function cerrarModal() {
        $("#formModal").modal("hide");
        cargado = 0;
    }

    function guardado() {
        Swal.fire({
            icon: "success",
            timer: 1500,
            showConfirmButton: false,
            customClass: {
                popup: 'bg-dark text-white',
                content: 'text-white',
                title: 'text-white'
                // Puedes agregar más clases según sea necesario
            }
        });
    }

    function alerta(mensaje, tarea) {
        Swal.fire({
            title: "Advertencia",
            text: `¿Estás seguro de que deseas ${mensaje}?`,
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Confirmar",
            cancelButtonText: "Cancelar",
            customClass: {
                popup: 'bg-dark text-white',
                content: 'text-white',
                title: 'text-white'
                // Puedes agregar más clases según sea necesario
            }
        }).then((result) => {
            if (result.isConfirmed) {
                if (tarea) {
                    tarea();
                }
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                error("Se canceló");
            }
        });
    }

    function error(mensaje) {
        Swal.fire({
            title: mensaje,
            icon: "error",
            timer: 1500,
            showConfirmButton: false,
            customClass: {
                popup: 'bg-dark text-white',
                content: 'text-white',
                title: 'text-white'
                // Puedes agregar más clases según sea necesario
            }
        });
    }


    //usuarios
    $("#btnRegistrar").on("click", function () {
        abrirModal();
        $(".modal-title").html('<i class="fas fa-user-plus"></i> Agregar Usuario');
    });

    $("#tablaUsuarios").on("click", "#btnEditar", function () {
        var fila = objTabla.row($(this).closest("tr")).index();
        var data = todosLosDatos[fila];

        abrirModal();

        $(".modal-title").html('<i class="fas fa-user"></i><i class="fas fa-pen fa-xs"></i> EditarUsuario');

        $("#txtDocumento").val(data.documentoUsuario);
        $("#txtNombre").val(data.nombreUsuario);
        $("#txtApellido").val(data.apellidoUsuario);
        $("#txtTell").val(data.tellUsuario);
        $("#txtCorreo").val(data.correoUsuario);
        $("#txtDireccion").val(data.direccionUsuario);
        $("#btsEstado").val(data.estadoUsuario ? "0" : "1");
        $("#btsTipoUsuario").val(data.objRol.idRol.toString());
        $("#btsCiudad").val(data.objCiudad.idCiudad.toString());
        debugger;
        cargado = data.idUsuario;
    });

    $("#tablaUsuarios").on("click", "#btnEliminar", function () {
        var indiceFila = objTabla.row($(this).closest("tr")).index();
        var valorDeseado = todosLosDatos[indiceFila];
        alerta("eliminar Usuario", function () {
            var usuario = {
                idUsuario: valorDeseado.idUsuario
            }
            const data = JSON.stringify({ objUsuario: usuario })
            cargarAjaxPost("/Home/MtdEliminarUsuario", data, function (dato) {
                if (dato.data == 1) {
                    guardado();
                    ListarTablaUsuarios();
                } else {
                    error(dato.mensaje);
                }
            });
        });
    });

    $("#CancelarModal").on("click", function () {
        cargado = 0;
    })

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
            estadoUsuario: (parseInt($("#btsEstado").val()) == 0),
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

    //Rol

    $("#GuardarRol").on("click", function () {

        $(".modal-body").LoadingOverlay("show");

        var rol = {
            nombreRol: $("#txtRol").val()
        }

        const objeto = JSON.stringify({ objRol: rol });

        cargarAjaxPost("/Home/MtdGuardarRol", objeto, function (data) {
            debugger
            if (data.data == 1) {
                $("#txtRol").val("");
                guardado();
                listarRol();
                $("#MdRol").modal("hide");
            } else {
                error(data.mensaje);
            }
            $(".modal-body").LoadingOverlay("hide");
        });

    });
    //eliminar rol
    $("#listaRoles").on("click", ".dropdown-item", function () {
        var rol = $(this).data("id");
        var dato = {
            idRol: rol
        }

        const datos = JSON.stringify({ objRol: dato });
                
        alerta("eliminar el Rol", function () {
            cargarAjaxPost("/Home/MtdEliminarRol", datos, function (data) {
                console.log(data);
                if (data.data == 1) {
                    guardado();
                } else {
                    error(data.mensaje);
                }
                listarRol();
            }); 
        });
    });


})
