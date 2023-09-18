using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.DAL.DataContext;

namespace ESFE.GestorTareas.DAL.DataContext.Repositorios
{
    public class RegistroRepository : IGenericRepository<Usuario>
    {
        private readonly GestorTareasBdContext _dbContext;
        public Task<bool> Actualizar(Usuario modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insertar(Usuario modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Usuario>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
