using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public class EstadoTareaService : IEstadoTareaService
    {
        private readonly IGenericRepository<EstadoTarea> _estaRepo;
        public EstadoTareaService(IGenericRepository<EstadoTarea> estaRepo)
        {
            _estaRepo = estaRepo;
        }
        public async Task<bool> Actualizar(EstadoTarea modelo)
        {
            return await _estaRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _estaRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(EstadoTarea modelo)
        {
            return await _estaRepo.Insertar(modelo);
        }

        public async Task<EstadoTarea> Obtener(int id)
        {
            return await _estaRepo.Obtener(id);
        }

        public async Task<EstadoTarea> ObtenerPorNombre(string nombreEstadoTarea)
        {
            IQueryable<EstadoTarea> queryEstadoTareaSQL = await _estaRepo.ObtenerTodos();
            EstadoTarea? estadoTarea = queryEstadoTareaSQL.FirstOrDefault(c => c.Nombre == nombreEstadoTarea);
            return estadoTarea;
        }

        public async Task<IQueryable<EstadoTarea>> ObtenerTodos()
        {
            return await _estaRepo.ObtenerTodos();
        }
    }
}
