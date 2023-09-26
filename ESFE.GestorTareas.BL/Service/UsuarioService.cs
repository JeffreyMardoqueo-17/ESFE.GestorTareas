﻿using ESFE.GestorTareas.DAL.DataContext;
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
        private readonly GestorTareasBdContext _dbcontext;

        public UsuarioService(IGenericRepository<Usuario> userRepo,GestorTareasBdContext dbcontext)
        {
            _userRepo = userRepo;
            _dbcontext = dbcontext;
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
            return await _dbcontext.Usuarios.AnyAsync(u => u.Correo == correo);

        }

        public async Task<Usuario> GetUsuario(string nombre, string correo, string pass)
        {
            Usuario usuarioEncontrado = await _dbcontext.Usuarios.Where(u => u.Nombre == nombre && u.Correo == correo && u.Pass == pass)
                .FirstOrDefaultAsync();

            return usuarioEncontrado;

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

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();

            return modelo;
        }
    }
}
