using System;
using System.Collections.Generic;

namespace ESFE.GestorTareas.EN;

public partial class Cargo
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
