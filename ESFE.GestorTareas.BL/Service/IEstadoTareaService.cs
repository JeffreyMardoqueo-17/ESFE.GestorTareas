using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface IEstadoTareaService
    {
        Task<bool> Insertar(EstadoTarea modelo);
        Task<bool> Actualizar(EstadoTarea modelo);
        Task<bool> Eliminar(int id);
        Task<EstadoTarea> Obtener(int id);
        Task<IQueryable<EstadoTarea>> ObtenerTodos();

        Task<EstadoTarea> ObtenerPorNombre(string nombreEstadoTarea);
    }
}
