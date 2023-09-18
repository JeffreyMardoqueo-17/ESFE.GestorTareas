using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;

namespace ESFE.GestorTareas.DAL.DataContext;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;
    public string ConfirmarContrasenia { get; set; } = null!;
    public int IdEmpleado { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
