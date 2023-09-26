using ESFE.GestorTareas.EN;
using System.ComponentModel.DataAnnotations;

namespace ESFE.GestorTareas.UI.Models.ViewModels
{
    public class VMPrioridad
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
