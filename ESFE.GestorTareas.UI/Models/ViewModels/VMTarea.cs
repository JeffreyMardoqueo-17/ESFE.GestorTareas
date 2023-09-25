using ESFE.GestorTareas.EN;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESFE.GestorTareas.UI.Models.ViewModels
{
    public class VMTarea
    {

        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; } = null!;

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public byte IdCategoria { get; set; }

        [Required]
        public byte IdPrioridad { get; set; }

        [Required]
        public byte IdEstadoTarea { get; set; }


        public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

        public virtual Categorium IdCategoriumNavigation { get; set; } = null!;

        public virtual EstadoTarea IdEstadoTareaNavigation { get; set; } = null!;

        public virtual Prioridad IdPrioridadNavigation { get; set; } = null!; 
    }
}
