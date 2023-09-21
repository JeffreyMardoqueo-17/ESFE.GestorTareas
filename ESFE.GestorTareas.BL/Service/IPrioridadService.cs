using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface IPrioridadService
    {
        Task<bool> Insertar(Prioridad modelo);
        Task<bool> Actualizar(Prioridad modelo);
        Task<bool> Eliminar(int id);
        Task<Prioridad> Obtener(int id);
        Task<IQueryable<Prioridad>> ObtenerTodos();

        Task<Prioridad> ObtenerPorNombre(string nombrePrioridad);
    }
}
