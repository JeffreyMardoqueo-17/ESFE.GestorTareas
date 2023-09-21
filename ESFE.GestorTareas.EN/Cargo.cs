using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESFE.GestorTareas.EN;

public partial class Cargo
{
    [Key]
    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
