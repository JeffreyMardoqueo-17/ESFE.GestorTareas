using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESFE.GestorTareas.EN;

public partial class Empleado
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Apellido { get; set; } = null!;

    [Required]
    [StringLength(9)]
    public string Telefono { get; set; } = null!;

    [Required]
    public byte IdCargo { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
