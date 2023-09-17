using System;
using System.Collections.Generic;

namespace ESFE.GestorTareas.EN;

public partial class Categorium
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
