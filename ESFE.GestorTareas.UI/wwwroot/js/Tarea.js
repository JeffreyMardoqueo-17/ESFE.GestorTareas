alert("ESTO FUNCIONA")

//MODELO BASE
const Modelo_base = {
    id: 0,
    nombre: "",
}

const mostrarModal = (m) => {

    $("#txtId").val(m.id);
    $("#txtNombre").val(m.nombre)

    $('.modal').modal('show');
}
$("#btnNuevo").click(() => {

    mostrarModal(Modelo_base);
});