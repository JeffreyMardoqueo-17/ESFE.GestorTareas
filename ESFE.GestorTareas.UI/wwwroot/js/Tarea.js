alert("ESTO FUNCIONA")

<<<<<<< HEAD
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
=======
//MODELO BASE
const Modelo_base = {
    id: 0,
    nombre: "",
>>>>>>> 0970cf533122e8cb9779090cced7c9a79a175a6b
}

const mostrarModal = (m) => {

    $("#txtId").val(m.id);
    $("#txtNombre").val(m.nombre)

    $('.modal').modal('show');
}
$("#btnNuevo").click(() => {

    mostrarModal(Modelo_base);
});