using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESFE.GestorTareas.EN;

public partial class AsignacionTarea
{
    [Key]
    public long Id { get; set; }

    [Required]
    public DateTime FechaAsignada { get; set; }

    [Required]
    public DateTime FechaFinalizacion { get; set; }

    [Required]
    public long IdTarea { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [Required]
    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
    public virtual Tarea IdTareaNaviagtion { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
