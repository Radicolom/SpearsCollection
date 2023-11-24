$(function () {

    $("#imagenAnimal").on("change", function () {
        var foto = this.files[0];

        if (foto.type !== "image/jpeg") {
            Swal.fire({
                icon: 'warning',
                title: 'El formato de la imagen debe ser JPEG.',
                showConfirmButton: false,
                timer: 2500
            })
            $("#preview").hide();
            $("#imagenAnimal").val("");
            return;
        } else {
            var urlImagen = URL.createObjectURL(foto);
            $('#imgProducto').attr('src', urlImagen).show();
        }

    });



})