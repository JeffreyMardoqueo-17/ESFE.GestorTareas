using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface ITareaService
    {
        Task<bool> Insertar(Tarea modelo);
        Task<bool> Actualizar(Tarea modelo);
        Task<bool> Eliminar(int id);
        Task<Tarea> Obtener(int id);
        Task<IQueryable<Tarea>> ObtenerTodos();

        Task<Tarea> ObtenerPorNombre(string nombreTarea);
    }
}
