using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.DAL.DataContext.Repositorios
{
    //Aqui le decimos q sera un tipo de clase 
    public interface IGenericRepository<TIntityModel> where TIntityModel : class
    {
        Task<bool> Insertar(TIntityModel modelo);
        Task<bool> Actualizar(TIntityModel modelo);
        Task<bool> Eliminar(int id);
        Task<bool> Obtener(int id);
        Task<IQueryable<TIntityModel>> ObtenerTodos();

    }
}
