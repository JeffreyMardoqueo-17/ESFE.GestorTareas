using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    internal class AsignacionTareaService : IAsignacionTareaService
    {
        private readonly IGenericRepository<AsignacionTarea> _asignaRepo;
        public AsignacionTareaService(IGenericRepository<AsignacionTarea> asignaRepo)
        {
            _asignaRepo = asignaRepo;
        }
        public async Task<bool> Actualizar(AsignacionTarea modelo)
        {
            return await _asignaRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _asignaRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(AsignacionTarea modelo)
        {
            return await _asignaRepo.Insertar(modelo);
        }

        public Task<AsignacionTarea> Obtener(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<IQueryable<AsignacionTarea>> ObtenerPorIdEmpleado(int IdEmpleado)
        {
            IQueryable<AsignacionTarea> queryAsignacionTareaSQL = await _asignaRepo.ObtenerTodos();
            IQueryable<AsignacionTarea> asignacionesPorEmpleado = queryAsignacionTareaSQL.Where(c => c.IdEmpleado == IdEmpleado);
            return asignacionesPorEmpleado.AsQueryable();

        }

        public async Task<IQueryable<AsignacionTarea>> ObtenerTodos()
        {
            return await _asignaRepo.ObtenerTodos();
        }
    }
}
