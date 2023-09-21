using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public class TareaService : ITareaService
    {
        private readonly IGenericRepository<Tarea> _tareRepo;
        public TareaService(IGenericRepository<Tarea> tareRepo)
        {
            _tareRepo = tareRepo;
        }
        public async Task<bool> Actualizar(Tarea modelo)
        {
            return await _tareRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _tareRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Tarea modelo)
        {
            return await _tareRepo.Insertar(modelo);
        }

        public Task<Tarea> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tarea> ObtenerPorNombre(string nombreTarea)
        {
            IQueryable<Tarea> queryTareaSQL = await _tareRepo.ObtenerTodos();
            Tarea tarea = queryTareaSQL.Where(c => c.Nombre == nombreTarea).FirstOrDefault();
            return tarea;
        }

        public async Task<IQueryable<Tarea>> ObtenerTodos()
        {
            return await _tareRepo.ObtenerTodos();
        }
    }
}
