$(function () {

    var datosMaterial = null;

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
            url: "/DatoInsumo/" + ruta,
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

    function listarInsumo() {
        cargarAjax("MtdListarInsumo/", function (data) {
            todosDatos = data;
            if (data != null) {
                var dataSet = [];

                var materialesUnicos = new Set(data.map(item => item.objMaterial.nombreMaterial));
                var listaMateriales = Array.from(materialesUnicos);

                $("#listaBusquedaMaterial").empty();

                listaMateriales.forEach(function (material) {
                    // Obtener el idMaterial correspondiente al material actual
                    var idMaterial = obtenerIdMaterialPorNombre(material, data);

                    $("#listaBusquedaMaterial").append('<a class="dropdown-item" href="#" id="selecCionarBusquedaMaterial" val="' + idMaterial + '">' + material + '</a>');

                });

                data.forEach(listarCartas);

                function listarCartas(item, index) {
                    dataSet.push([
                        '<div class="col" compM="' + item.objMaterial.idMaterial +
                        '"><button id="btnInsumo" type="button" class="btn" data-indice="' + index + '"' +
                        '><div class="colorest card" style="width: 250px; background-color:#ffc273;">' +

                        '<div class="card-body">' +
                        '<h5><strong>Nombre:</strong> ' + item.nombreInsumo + '</h5>' +
                        '<h5><strong>Material:</strong> ' + item.objMaterial.nombreMaterial + '</h5>' +
                        '<h5><strong>Stock:</strong> ' + item.cantidadInsumo + '</h5>' +
                        '</div></div></button></div>'
                    ]);
                }
                armarCartas(dataSet);
            }
        })
    }

    function armarCartas(dataSet) {
        //debugger;
        var objCarta = $("#CartasInsumo");

        if (objCarta != null) {
            objCarta.empty();
        }

        objCarta.html(dataSet.join(''));
    }

    //Alertas
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




    //Vista Principal
    $("#btnRegProduc").on("click", function () {
        $("#contenedorGuardarProducto").fadeIn(1000);
        cargarAjax("/Mantenedor/MtdListarMaterial", function (data) {
            data.forEach(function (item) {
                $("#listaRegistroMaterial").append(`<option value="${item.nombreMaterial}">`)
            });

        });


    });









    //Registro

    $("#imagenProductoReg").on("change", function () {
        var foto = this.files[0];

        if (foto.type !== "image/jpeg") {

            error("Formato incorrecto");
            $("#imgProducto").hide();
            $("#imagenProductoReg").val("");
            return;
        } else {
            var urlImagen = URL.createObjectURL(foto);
            $('#imgProducto').attr('src', urlImagen).show();
        }

    });

    $("#btnGuardarProducto").on("click", function () {
        $("#imagenProductoReg")[0].files[0];

        var producto = {
            codigoProducto: $("#nombreCodProduc").val(),
            nombreProducto: $("#nombreProductoReg").val(),
            descripcionProduct: $("#descripcionProducRegistrar").val(),
            //estadoProducto: parseInt() == 0 ? false : true,
            idMaterial: $("#selectMaterialReg").val(),
            idCategoria: $("#selectCategoriaReg").val()

        }

    });




})