using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.DAL.Repositories
{
    public class CargoRepository : IGenericRepository<Cargo>
    {
        private readonly GestorTareasBdContext _dbcontext;

        public CargoRepository(GestorTareasBdContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(Cargo modelo)
        {
            _dbcontext.Cargos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cargo modelo = _dbcontext.Cargos.First(c => c.Id == id);
            _dbcontext.Cargos.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cargo modelo)
        {
            _dbcontext.Cargos.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Cargo> Obtener(int id)
        {
            return await _dbcontext.Cargos.FindAsync(id);
        }

        public async Task<IQueryable<Cargo>> ObtenerTodos()
        {
            IQueryable<Cargo> queryCargoSQL = _dbcontext.Cargos;
            return queryCargoSQL;
        }
    }
}
