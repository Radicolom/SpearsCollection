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

                    dataSet.push([contar, item.documentoUsuario, item.nombreUsuario, item.apellidoUsuario, item.correoUsuario, item.nombreRol,
                        (item.estadoUsuario ? '<span class="badge text-bg-success"><i>Activo</i></span>' : '<span class="badge text-bg-warning"><i>No Activo</i></span>'),
                        objBotones.defaultContent

                    ]);
                }

                cargarTablaUsuarios(dataSet);
            }

        });

    }

    function cargarTablaUsuarios(dataSet) {
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

    function abrirModal() {
        $("#formModal").modal("show");
        cargarAjax('/Home/MtdListarRol', function (data) {

            const selectRol = $("#btsTipoUsuario");
            selectRol.empty();
            selectRol.append("<option disabled selected>Seleccione un puesto</option>");
            data.forEach(function (item) {
                selectRol.append("<option value=" + item.idRol + ">" + item.nombreRol + "</option>");
            });
        });

        $("#txtDocumento").val("");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtCorreo").val("");
        $("#btsTipoUsuario").val("");
    }

    function cerrarModal() {
        $("#formModal").modal("hide");
        cargado = -1;
    }

    $("#btnRegistrar").on("click", function () {
        abrirModal();

    });
    //Para editar
    $("#tablaUsuarios").on("click", "#btnEditar", function () {
        //Selecciona la fila
        var filaSeleccionada = objTabla.row($(this).closest("tr")).index();
        //Selecciona los datos
        data = todosLosDatos[filaSeleccionada];
        console.log(data)
        abrirModal();

        $("#txtDocumento").val(data.documentoUsuario);
        $("#txtNombre").val(data.nombreUsuario);
        $("#txtApellido").val(data.apellidoUsuario);
        $("#txtCorreo").val(data.correoUsuario);
        $("#btsTipoUsuario").val(data.idRol);

        cargado = data.idUsuario;
    })

    $("#CancelarModal").on("click", function () {
        dataFila = null;
        cargado = -1;
    })

    $("#Guardar").on("click", function () {
        var registro = {
            documentoUsuario:$("#txtDocumento").val(),
            apellidoUsuario: $("#txtApellido").val(),
            correoUsuario: dataFila.correoUsuario,
            estadoUsuario: $("#btsTipoUsuario").val(),
            idRol: $("#btsTipoUsuario").val(),
            idUsuario: cargado,
            nombreUsuario: $("#txtNombre").val()
        }

        if (registro.documentoUsuario == false) {
            alert("crear");
        } else {
            alert("edi");
        }

        dataFila = null;
        cerrarModal();
    })



})
