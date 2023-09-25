using ESFE.GestorTareas.EN;


namespace ESFE.GestorTareas.UI.Models.ViewModels
{
    public class VMUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public string Pass { get; set; } = null!;
        public int IdEmpleado { get; set; }
        public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

        //RELACION ENTRE LLAVE FORANEA CON EL MODELO 
        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
    


}
}
