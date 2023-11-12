$(function () {

    cargarDatos();
    ListarTablaUsuarios()

    var objTabla = null;
    var todosLosDatos = [];
    var cargado = -1;
    var dataFila = null;

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
        })
    }

    function cargarAjaxPost(ruta, datos, tarea) {
        $.ajax({
            url: ruta,
            type: "GET",
            data: datos;
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function (data) {
            if (tarea) {
                tarea(data);
            } else {
                console.log("Error en la solicitud AJAX: ");
                tarea([]);
            }
        })
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

                    dataSet.push([contar, item.documentoUsuario, item.nombreUsuario, item.apellidoUsuario, item.tellUsuario, item.correoUsuario, item.nombreRol,
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
            ordering: false,
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json"
            }
        })
    }

    function listarCiudad() {
        cargarAjax('/Home/MtdListarCiudad', function (data) {
            if (lugar) {
                const selectRol = $("#btsCiudad");
                selectRol.empty();
                selectRol.append("<option disabled selected value='0'>Seleccione una ciudad</option>");
                data.forEach(function (item) {
                    selectRol.append("<option value=" + item.idCiudad + ">" + item.nombreCiudad + "</option>");
                });
            }
        });
    }

    function listarRol(lugar) {
        cargarAjax('/Home/MtdListarRol', function (data) {
            if (lugar) {
                const selectRol = $("#btsTipoUsuario");
                selectRol.empty();
                selectRol.append("<option disabled selected value='0'>Seleccione un puesto</option>");
                data.forEach(function (item) {
                    selectRol.append("<option value=" + item.idRol + ">" + item.nombreRol + "</option>");
                });
            }
        });
    }


    function abrirModal() {

        $("#formModal").modal("show");

        listarRol(true);
        listarCiudad(true);

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
        cargado = -1;
    }

    //usuarios
    $("#btnRegistrar").on("click", function () {
        abrirModal();

    });
    //Para editar
    $("#tablaUsuarios").on("click", "#btnEditar", function () {
        //Selecciona la fila
        var filaSeleccionada = objTabla.row($(this).closest("tr"));
        //Selecciona los datos
        data = todosLosDatos[filaSeleccionada];
        console.log(data)
        abrirModal();

        $("#txtDocumento").val(data.documentoUsuario);
        $("#txtNombre").val(data.nombreUsuario);
        $("#txtApellido").val(data.apellidoUsuario);
        $("#txtTell").val(data.tellUsuario);
        $("#txtCorreo").val(data.correoUsuario);
        $("#txtDireccion").val(data.direccionUsuario);
        $("#btsEstado").val(data.estadoUsuario ? "0" : "1");
        $("#btsTipoUsuario").val(data.idRol);
        $("#btsCiudad").val(data.idCiudad);

        cargado = data.idUsuario;
    })

    $("#CancelarModal").on("click", function () {
        dataFila = null;
        cargado = -1;
    })

    $("#Guardar").on("click", function () {
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


        if (registro.documentoUsuario == false) {
            alert("crear");
        } else {
            alert("edi");
        }

        dataFila = null;
        cerrarModal();
    })



})
