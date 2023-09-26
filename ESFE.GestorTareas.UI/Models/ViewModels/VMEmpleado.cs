using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESFE.GestorTareas.UI.Models.ViewModels
{
    public class VMEmpleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public byte IdCargo { get; set; }

        public List<SelectListItem> Cargos { get; set; } = null!;

    }
}
