using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public class PrioridadService : IPrioridadService
    {
        private readonly IGenericRepository<Prioridad> _prioRepo;
        public PrioridadService(IGenericRepository<Prioridad> prioRepo)
        {
            _prioRepo = prioRepo;
        }
        public async Task<bool> Actualizar(Prioridad modelo)
        {
            return await _prioRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _prioRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Prioridad modelo)
        {
            return await _prioRepo.Insertar(modelo);
        }

        public Task<Prioridad> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Prioridad> ObtenerPorNombre(string nombrePrioridad)
        {
            IQueryable<Prioridad> queryPrioridadSQL = await _prioRepo.ObtenerTodos();
            Prioridad prioridad = queryPrioridadSQL.Where(c => c.Nombre == nombrePrioridad).FirstOrDefault();
            return prioridad;
        }

        public async Task<IQueryable<Prioridad>> ObtenerTodos()
        {
            return await _prioRepo.ObtenerTodos();
        }
    }
}
