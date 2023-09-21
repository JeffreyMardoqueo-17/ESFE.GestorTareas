using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESFE.GestorTareas.EN;

public partial class Categorium
{
    [Key]
    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
