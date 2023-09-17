using System;
using System.Collections.Generic;

namespace ESFE.GestorTareas.EN;

public partial class Tarea
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Prioridad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaVencimiento { get; set; }

    public byte IdCategoria { get; set; }

    public byte IdPrioridad { get; set; }

    public byte IdEstadoTarea { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual EstadoTarea IdEstadoTareaNavigation { get; set; } = null!;

    public virtual Prioridad IdPrioridadNavigation { get; set; } = null!;
}
