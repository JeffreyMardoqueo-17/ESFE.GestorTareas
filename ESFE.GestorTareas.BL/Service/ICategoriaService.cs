using ESFE.GestorTareas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.BL.Service
{
    public interface ICategoriaService
    {

        Task<bool> Insertar(Categorium modelo);
        Task<bool> Actualizar(Categorium modelo);
        Task<bool> Eliminar(int id);
        Task<Categorium> Obtener(int id);
        Task<IQueryable<Categorium>> ObtenerTodos();

        Task<Categorium> ObtenerPorNombre(string nombreCategorium);


    }
}
