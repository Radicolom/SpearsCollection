$(function () {

    var todosDatos = [];


    listarInsumo();

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

    function obtenerIdMaterialPorNombre(nombreMaterial, data) {
        // Función para obtener el idMaterial correspondiente a un nombre de material
        var idMaterial = null;
        for (var i = 0; i < data.length; i++) {
            if (data[i].objMaterial.nombreMaterial === nombreMaterial) {
                idMaterial = data[i].objMaterial.idMaterial;
                break;
            }
        }
        return idMaterial;
    }

    function filtrar(valoresColeccion, comparaTipo, atributos) {
        for (let i = 0; i < valoresColeccion.children.length; i++) {
            const elemento = valoresColeccion.children[i];
            const atributo = elemento.getAttribute(atributos);

            // Verificar si el atributo es null o undefined
            if (comparaTipo == -28) {
                elemento.style.display = "block";  // Mostrar el elemento si coincide
            } else if (atributo === null || atributo === undefined || atributo !== comparaTipo) {
                elemento.style.display = "none";
            } else {
                elemento.style.display = "block";  // Mostrar el elemento si coincide
            }
        }
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

    //Provedores
    function listarProveedor() {
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

    //Satelite

    function listarSatelite() {
        return new Promise(function (resolve) {
            cargarAjax("MtdListarSatelite", function (datos) {
                if (datos) {
                    const selectProveedor = $("#btsSatelite");
                    selectProveedor.empty();
                    selectProveedor.append("<option disabled selected value='0'>Seleccione un satelite</option>");
                    datos.forEach(function (item) {
                        selectProveedor.append("<option value=" + item.idUsuario + ">" + item.nombreUsuario + " " + item.apellidoUsuario + "</option>");
                    });
                    resolve();
                }
            })
        })
    }

    //lista Busqueda 
    function ListarBusquedaInsumo() {
        
        todosDatos.forEach(function (item) {
            $("#listaRegistroInsumo").append(`<option value="${ item.nombreInsumo }">`);
        });
    }

    function ListarBusquedaMaterial() {
        var materialesUnicos = new Set(todosDatos.map(item => item.objMaterial.nombreMaterial));
        var listaMateriales = Array.from(materialesUnicos);

        listaMateriales.forEach(function (item) {
            $("#listaRegistroMaterial").append(`<option value="${item}">`);
        });
    }



    $("#listaBusquedaMaterial").on("click", "#selecCionarBusquedaMaterial", function () {
        //relistaAnimal()
        let materialVal = $(this).first().attr('val');  // Obtener el valor usando .attr('val')
        const busquedaMaterial = $("#CartasInsumo");
        const atrComparar = "compM";
        filtrar(busquedaMaterial[0], materialVal, atrComparar);
    });

    $("#NoFiltrar").on("click", function () {

        const busquedaMaterial = $("#CartasInsumo");
        const atrComparar = "compM";

        filtrar(busquedaMaterial[0], -28, atrComparar);
    });

    //datos

    $("#CartasInsumo").on("click", "#btnInsumo", async function () {
        
        // Obtener la posición del botón en relación con sus elementos hermanos
        var posicion = $(this).data('indice');
        var datos = todosDatos[posicion];
        $("#CntInsumos").hide();
        $("#CntDatosInsumo").fadeIn(1000);
        await listarSatelite();

        $("#txtNombre").val(datos.nombreInsumo);
        $("#txtMaterial").val(datos.objMaterial.nombreMaterial);
        $("#txtCantidad").val(datos.cantidadInsumo);
        $("#txtDesInsumo").val(datos.descripcionInsumo);
        $("#txtDesMaterial").val(datos.objMaterial.descripcionMaterial);

    })

    $("#btnRegresar").on("click", function () {
        $("#CntDatosInsumo").hide();
        $("#CntInsumos").fadeIn(1000);

    })

    $("#btnRegresar2").on("click", function () {
        $("#CntRegistrarInsumo").hide();
        $("#CntInsumos").fadeIn(1000);

    })

    //Material

    $("#GuardarMaterial").on("click", function () {
        $(".modal-body").LoadingOverlay("show");


        var registro = {
            nombreMaterial: $("#txtRegMaterial").val(),
            descripcionMaterial: $("#txtRegDesInsumo").val()

        };

        const datos = JSON.stringify({ objMaterial: registro });

        cargarAjaxPost("MtdGuardarMaterial", datos, function (dato) {
            if (dato.data == 1) {
                guardado();
            } else {
                error(dato.mensaje);
            }
        })


    });

    $("#registroCompraInsumo").on("click", async function () {

        $("#CntInsumos").hide();
        $("#CntRegistrarInsumo").fadeIn(1000);

        await listarProveedor();
        await ListarBusquedaInsumo();
        await ListarBusquedaMaterial();

    })

    //Cambios

    $("#InsumoRegistro").on("change", function () {
        for (var i = 0; i < todosDatos.length; i++) {
            const item = todosDatos[i];
            if ($("#InsumoRegistro").val() == item.nombreInsumo) {
                $("#datoDescripcionInsumo").text(item.descripcionInsumo);
                $("#datoDescripcionInsumo").prop("disabled", true);
                break;
            } else {
                $("#datoDescripcionInsumo").prop("disabled", false);
            }
        }
    });

    $("#MaterialRegistro").on("change", function () {
        for (var i = 0; i < todosDatos.length; i++) {
            const item = todosDatos[i];
            if ($("#MaterialRegistro").val() == item.objMaterial.nombreMaterial) {
                $("#datoDescripcionMaterial").text(item.objMaterial.descripcionMaterial);
                $("#datoDescripcionMaterial").prop("disabled", true);
                break;
            } else {
                $("#datoDescripcionMaterial").prop("disabled", false);
            }
        }
    })


    //REGISTROS

    $("#btnGuardarFactura").on("click", function () {


        var factura = {
            cantidadCompra: $("#txtCantidadReg").val(),
            precioCompra: $("#txtPrecio").val(),
            objCompra: {
                numeroCompra: $("#txtNumeroCompraReg").val(),
                estadoCompra: (parseInt($("#btsEstado").val()) == 0 ? true : false),
                objProveedor: {
                    idUsuario: $("#btsProveedor").val()
                }
            },
            objInsumo: {
                nombreInsumo: $("#InsumoRegistro").val(),
                descripcionInsumo: $("#datoDescripcionInsumo").val(),
                objMaterial: {
                    nombreMaterial: $("#MaterialRegistro").val(),
                    descripcionMaterial: $("#datoDescripcionMaterial").val()
                }
            }

        }

        console.log(factura)

    });

    $("#btnRegistrarEnvioSatelite").on("click", function () {

        var satelite = {

        }
    })



})