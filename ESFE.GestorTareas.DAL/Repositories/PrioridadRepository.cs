using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.DAL.Repositories
{
    internal class PrioridadRepository : IGenericRepository<Prioridad>
    {
        private readonly GestorTareasBdContext _dbcontext;

        public PrioridadRepository(GestorTareasBdContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(Prioridad modelo)
        {
            _dbcontext.Prioridads.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Prioridad modelo = _dbcontext.Prioridads.First(c => c.Id == id);
            _dbcontext.Prioridads.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Prioridad modelo)
        {
            _dbcontext.Prioridads.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Prioridad> Obtener(int id)
        {
            return await _dbcontext.Prioridads.FindAsync(id);
        }

        public async Task<IQueryable<Prioridad>> ObtenerTodos()
        {
            IQueryable<Prioridad> queryPrioridadSQL = _dbcontext.Prioridads;
            return queryPrioridadSQL;
        }
    }
}
