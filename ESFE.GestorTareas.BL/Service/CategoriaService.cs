using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.GestorTareas.BL.Service;

namespace ESFE.GestorTareas.BL.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categorium> _cateRepo;
        public CategoriaService(IGenericRepository<Categorium> cateRepo)
        {
            _cateRepo = cateRepo;
        }
        public async Task<bool> Actualizar(Categorium modelo)
        {
            return await _cateRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _cateRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Categorium modelo)
        {
            return await _cateRepo.Insertar(modelo);
        }

        public async Task<Categorium> Obtener(int id)
        {
            return await _cateRepo.Obtener(id);
        }

        public async Task<Categorium> ObtenerPorNombre(string nombreCategorium)
        {
            IQueryable<Categorium> queryCategoriumSQL = await _cateRepo.ObtenerTodos();
            Categorium? categorium = queryCategoriumSQL.FirstOrDefault(c => c.Nombre == nombreCategorium);
            return categorium;
        }

        public async Task<IQueryable<Categorium>> ObtenerTodos()
        {
            return await _cateRepo.ObtenerTodos();
        }
    }
}


