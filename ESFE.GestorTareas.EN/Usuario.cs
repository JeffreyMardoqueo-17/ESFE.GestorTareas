using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESFE.GestorTareas.EN;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Nombre { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Correo { get; set; } = null!;

    [Required]
    [StringLength (50)]
    public string Pass { get; set; } = null!;

    [Required]
    public int IdEmpleado { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    //RELACION ENTRE LLAVE FORANEA CON EL MODELO 
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}