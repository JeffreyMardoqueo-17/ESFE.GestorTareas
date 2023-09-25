alert("ESTO FUNCIONA")

//MODELO BASE, de donde se tomara como mold
const Modelo_base = {
    id: 0,
    nombre: "",
    Descripcion: "",
    FechaVencimiento: "",
    Categoria: "",
    Prioridad: "",
    EstadoTarea: "",
    Asignacion: "",
    Categoria: "",
    Estado: "",
    Prioridad: "",
}

const mostrarModal = (m) => {

    $("#txtId").val(m.id);
    $("#txtNombre").val(m.nombre)

    $('.modal').modal('show');
}
$("#btnNuevo").click(() => {

    mostrarModal(Modelo_base);
});