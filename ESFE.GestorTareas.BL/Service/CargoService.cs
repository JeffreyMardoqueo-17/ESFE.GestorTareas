using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public class CargoService : ICargoService
    {
        private readonly IGenericRepository<Cargo> _carRepo;
        public CargoService(IGenericRepository<Cargo> carRepo)
        {
            _carRepo = carRepo;
        }
        public async Task<bool> Actualizar(Cargo modelo)
        {
            return await _carRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _carRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Cargo modelo)
        {
            return await _carRepo.Insertar(modelo);
        }

        public Task<Cargo> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cargo> ObtenerPorNombre(string nombreCargo)
        {
            IQueryable<Cargo> queryCargoSQL = await _carRepo.ObtenerTodos();
            Cargo cargo = queryCargoSQL.Where(c => c.Nombre == nombreCargo).FirstOrDefault();
            return cargo;
        }

        public async Task<IQueryable<Cargo>> ObtenerTodos()
        {
            return await _carRepo.ObtenerTodos();
        }
    }
}
