$(function () {

    var todosDatos = [];
    var cargado = 0;

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

    function listarInsumo() {
        cargarAjax("MtdListarInsumo/", function (data) {
            todosDatos = data;
            console.log(data);
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

    function armarCartas(dataSet) {
        //debugger;
        var objCarta = $("#CartasInsumo");

        if (objCarta != null) {
            objCarta.empty();
        }

        objCarta.html(dataSet.join(''));
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

    $("#CartasInsumo").on("click", "#btnInsumo", function () {
        
        // Obtener la posición del botón en relación con sus elementos hermanos
        var posicion = $(this).data('indice');
        var datos = todosDatos[posicion];
        $("#CntInsumos").hide();
        $("#CntDatosInsumo").fadeIn(1000);

        $("#txtNombre").val(datos.nombreInsumo);
        $("#txtMaterial").val(datos.objMaterial.nombreMaterial);
        $("#txtCantidad").val(datos.cantidadInsumo);
        $("#txtDesInsumo").val(datos.descripcionInsumo);
        $("#txtDesMaterial").val(datos.objMaterial.descripcionMaterial);

    })

    $("#btnRegresar").on("click", function () {
        console.log("sd")
        $("#CntDatosInsumo").hide();
        $("#CntInsumos").fadeIn(1000);

    })
    



})