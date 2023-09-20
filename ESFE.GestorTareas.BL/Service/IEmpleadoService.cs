using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface IEmpleadoService
    {
        Task<bool> Insertar(Empleado modelo);
        Task<bool> Actualizar(Empleado modelo);
        Task<bool> Eliminar(int id);
        Task<Empleado> Obtener(int id);
        Task<IQueryable<Empleado>> ObtenerTodos();

        Task<Empleado> ObtenerPorNombre(string nombreTarea);
    }
}
