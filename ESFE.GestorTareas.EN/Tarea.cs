using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESFE.GestorTareas.EN;

public partial class Tarea
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Descripcion { get; set; } = null!;

    [Required]
    public DateTime FechaVencimiento { get; set; }

    [Required]
    public byte IdCategoria { get; set; }

    [Required]
    public byte IdPrioridad { get; set; }

    [Required]
    public byte IdEstadoTarea { get; set; }


    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    [ForeignKey("IdCategoria")]
    public virtual Categorium Categorium { get; set; } = null!;

    [ForeignKey("IdEstadoTarea")]
    public virtual EstadoTarea EstadoTarea { get; set; } = null!;

    [ForeignKey("IdPrioridad")]
    public virtual Prioridad Prioridad { get; set; } = null!;
}
