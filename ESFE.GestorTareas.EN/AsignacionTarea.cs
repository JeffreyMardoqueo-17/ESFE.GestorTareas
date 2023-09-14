using ESFE.GestorTareas.DAL.DataContext;
using System;
using System.Collections.Generic;

namespace ESFE.GestorTareas.EN;

public partial class AsignacionTarea
{
    public long Id { get; set; }

    public DateTime FechaAsignada { get; set; }

    public DateTime FechaFinalizacion { get; set; }

    public long IdTarea { get; set; }

    public int IdUsuario { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Tarea IdTareaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
