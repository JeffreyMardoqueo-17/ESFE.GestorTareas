using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _userRepo;
        public UsuarioService(IGenericRepository<Usuario> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            return await _userRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _userRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await _userRepo.Insertar(modelo);
        }

        public Task<Usuario> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObtenerPorNombre(string nombreUsuario)
        {
            IQueryable<Usuario> queryUsuarioSQL = await _userRepo.ObtenerTodos();
            Usuario usuario = queryUsuarioSQL.Where(c => c.Nombre == nombreUsuario).FirstOrDefault();
            return usuario;
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _userRepo.ObtenerTodos();
        }
    }
}
