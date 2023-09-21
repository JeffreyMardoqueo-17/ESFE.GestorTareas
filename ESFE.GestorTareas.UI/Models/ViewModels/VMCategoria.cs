using ESFE.GestorTareas.EN;

namespace ESFE.GestorTareas.UI.Models.ViewModels
{
    public class VMCategoria
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
