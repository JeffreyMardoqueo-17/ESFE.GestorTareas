using ESFE.GestorTareas.EN;

namespace ESFE.GestorTareas.UI.Models.ViewModels
{
    public class VMCargo
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
