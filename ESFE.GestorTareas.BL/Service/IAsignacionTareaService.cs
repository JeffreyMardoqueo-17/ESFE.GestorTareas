using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface IAsignacionTareaService
    {
        Task<bool> Insertar(AsignacionTarea modelo);
        Task<bool> Actualizar(AsignacionTarea modelo);
        Task<bool> Eliminar(int id);
        Task<AsignacionTarea> Obtener(int id);
        Task<IQueryable<AsignacionTarea>> ObtenerTodos();

        Task<IQueryable<AsignacionTarea>> ObtenerPorIdEmpleado(int IdEmpleado);
    }
}
