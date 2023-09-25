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
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService CateServ)
        {
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
        public async Task<IActionResult> Lista()
        {

            IQueryable<Categorium> queryCategoriumSQL = await _categoriaService.ObtenerTodos();

            List<VMCategoria> lista = queryCategoriumSQL
                                      .Select(c => new VMCategoria()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMCategoria modelo)
        {

            Categorium NuevoModelo = new Categorium()
            {
                Nombre = modelo.Nombre
            };
            bool respuesta = await _categoriaService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMCategoria modelo)
        {

            Categorium NuevoModelo = new Categorium()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            bool respuesta = await _categoriaService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _categoriaService.Eliminar(id);

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
