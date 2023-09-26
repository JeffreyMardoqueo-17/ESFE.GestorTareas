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
//MODELO BASE
const modeloBase = {
    id: 0,
    nombre: "",
}

const mostrarModal = (m) => {

    $("#txtId").val(m.id);
    $("#txtNombre").val(m.nombre);
    $("#txtTDesc").val(m.Descripcion);
    $("#dtFecha").val(m.FechaVencimiento);
    $("#cbxCategoria").val(m.Categoria);

    $('.modal').modal('show');
}
$("#btnNuevo").click(() => {

    mostrarModal(modeloBase);
});