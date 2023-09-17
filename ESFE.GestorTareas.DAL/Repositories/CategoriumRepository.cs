using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.DAL.Repositories
{
    public class CategoriumRepository : IGenericRepository<Categorium>
    {
        private readonly GestorTareasBdContext _dbcontext;

        public CategoriumRepository(GestorTareasBdContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(Categorium modelo)
        {
            _dbcontext.Categoria.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Categorium modelo = _dbcontext.Categoria.First(c => c.Id == id);
            _dbcontext.Categoria.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Categorium modelo)
        {
            _dbcontext.Categoria.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Categorium> Obtener(int id)
        {
            return await _dbcontext.Categoria.FindAsync(id);
        }

        public async Task<IQueryable<Categorium>> ObtenerTodos()
        {
            IQueryable<Categorium> queryCategoriumSQL = _dbcontext.Categoria;
            return queryCategoriumSQL;
        }
    }
}
