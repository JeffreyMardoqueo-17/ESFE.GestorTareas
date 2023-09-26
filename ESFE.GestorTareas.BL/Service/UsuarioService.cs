using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using Microsoft.EntityFrameworkCore;
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
        private readonly GestorTareasBdContext _context;
        public UsuarioService(IGenericRepository<Usuario> userRepo,GestorTareasBdContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            return await _userRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _userRepo.Eliminar(id);
        }

        public async Task<bool> ExisteCorreo(string correo)
        {
            return await _context.Usuarios.AnyAsync(u => u.Correo == correo);

        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await _userRepo.Insertar(modelo);
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _userRepo.Obtener(id);
        }

        public async Task<Usuario> ObtenerPorNombre(string nombreUsuario)
        {
            IQueryable<Usuario> queryUsuarioSQL = await _userRepo.ObtenerTodos();
            Usuario? usuario = queryUsuarioSQL.FirstOrDefault(c => c.Nombre == nombreUsuario);
            return usuario;
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _userRepo.ObtenerTodos();
        }
    }
}
