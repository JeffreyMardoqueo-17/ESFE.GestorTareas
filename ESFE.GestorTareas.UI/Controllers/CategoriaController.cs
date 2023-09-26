using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using ESFE.GestorTareas.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class CategoriaController : Controller
    {
        //Constructor de la clase Categoria
        //Recibe un parametro que se utiliza para inyectar dependencia de esa clase (Categoria)
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService CateServ)
        {
            //asigno
            _categoriaService = CateServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categoria()
        {
            return View();
        }

        [HttpGet]
        //lista
        public async Task<IActionResult> Lista()
        {

            IQueryable<Categorium> queryCategoriumSQL = await _categoriaService.ObtenerTodos();
            // Pasa los objetos Cargo en objetos VMCategoria y los almacena en una lista
            List<VMCategoria> lista = queryCategoriumSQL
                                      .Select(c => new VMCategoria()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            //rtorna una respuesta http con un código de estado 200 OK y la lista de objetos VMCategoriaS como resultado.
            return StatusCode(StatusCodes.Status200OK, lista); //exito obvio
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMCategoria modelo)
        {
            //creamos un hijito de Categoriaa
            Categorium NuevoModelo = new Categorium()
            {
                Nombre = modelo.Nombre
            };
            //lllama de manera asincronica al metodo insertar de _categoriaService para insertar el nuevo modlo
            bool respuesta = await _categoriaService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta }); //exito
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMCategoria modelo)
        {
            //una instancia
            Categorium NuevoModelo = new Categorium()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            //pasamos el nuevo modelo (la instancia)
            bool respuesta = await _categoriaService.Actualizar(NuevoModelo);
            //exito
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            //borramos por medio del id que es el paramtro
            bool respuesta = await _categoriaService.Eliminar(id);
            //exitos
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
