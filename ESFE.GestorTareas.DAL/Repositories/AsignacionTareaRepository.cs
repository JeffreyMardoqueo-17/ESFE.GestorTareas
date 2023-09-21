using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ESFE.GestorTareas.DAL.Repositories
{
    public class AsignacionTareaRepository : IGenericRepository<AsignacionTarea>
    {
        private readonly GestorTareasBdContext _dbcontext;

        public AsignacionTareaRepository(GestorTareasBdContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(AsignacionTarea modelo)
        {
            _dbcontext.AsignacionTareas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            AsignacionTarea modelo = _dbcontext.AsignacionTareas.First(c => c.Id == id);
            _dbcontext.AsignacionTareas.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(AsignacionTarea modelo)
        {
            _dbcontext.AsignacionTareas.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<AsignacionTarea> Obtener(int id)
        {
            return await _dbcontext.AsignacionTareas.FindAsync(id);
        }

        public async Task<IQueryable<AsignacionTarea>> ObtenerTodos()
        {
            IQueryable<AsignacionTarea> queryAsignacionTareaSQL = _dbcontext.AsignacionTareas;
            return queryAsignacionTareaSQL;
        }
    }
}
