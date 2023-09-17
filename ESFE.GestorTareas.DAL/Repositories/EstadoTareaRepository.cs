using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.DAL.Repositories
{
    internal class EstadoTareaRepository : IGenericRepository<EstadoTarea>
    {
        private readonly GestorTareasBdContext _dbcontext;

        public EstadoTareaRepository(GestorTareasBdContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(EstadoTarea modelo)
        {
            _dbcontext.EstadoTareas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            EstadoTarea modelo = _dbcontext.EstadoTareas.First(c => c.Id == id);
            _dbcontext.EstadoTareas.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(EstadoTarea modelo)
        {
            _dbcontext.EstadoTareas.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<EstadoTarea> Obtener(int id)
        {
            return await _dbcontext.EstadoTareas.FindAsync(id);
        }

        public async Task<IQueryable<EstadoTarea>> ObtenerTodos()
        {
            IQueryable<EstadoTarea> queryEstadoTareaSQL = _dbcontext.EstadoTareas;
            return queryEstadoTareaSQL;
        }
    }
}
