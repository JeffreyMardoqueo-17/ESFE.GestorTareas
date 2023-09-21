using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface ICargoService
    {
        Task<bool> Insertar(Cargo modelo);
        Task<bool> Actualizar(Cargo modelo);
        Task<bool> Eliminar(int id);
        Task<Cargo> Obtener(int id);
        Task<IQueryable<Cargo>> ObtenerTodos();

        Task<Cargo> ObtenerPorNombre(string nombreCargo);
    }
}
