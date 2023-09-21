using System;
using System.Collections.Generic;

namespace ESFE.GestorTareas.EN;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}