using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.DAL.DataContext;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.DAL.Repositories
{
    public class EmpleadoRepository : IGenericRepository<Empleado>
    {
        private readonly GestorTareasBdContext _dbcontext;

        public EmpleadoRepository(GestorTareasBdContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Actualizar(Empleado modelo)
        {
            _dbcontext.Empleados.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            Empleado modelo = _dbcontext.Empleados.First(c => c.Id == id);
            _dbcontext.Empleados.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Empleado modelo)
        {
            _dbcontext.Empleados.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Empleado> Obtener(int id)
        {
            return await _dbcontext.Empleados.FindAsync(id);
        }

        public async Task<IQueryable<Empleado>> ObtenerTodos()
        {
            IQueryable<Empleado> queryEmpleadoSQL = _dbcontext.Empleados;
            return queryEmpleadoSQL;
        }
    }
}
