using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using ESFE.GestorTareas.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class EstadoTareaController : Controller
    {
        private readonly IEstadoTareaService _estadoTareaService;

        public EstadoTareaController(IEstadoTareaService EstadoServ)
        {
            _estadoTareaService = EstadoServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EstadoTarea()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<EstadoTarea> queryEstadoTareaSQL = await _estadoTareaService.ObtenerTodos();

            List<VMEstadoTarea> lista = queryEstadoTareaSQL
                                      .Select(c => new VMEstadoTarea()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMEstadoTarea modelo)
        {

            EstadoTarea NuevoModelo = new EstadoTarea()
            {
                Nombre = modelo.Nombre
            };
            bool respuesta = await _estadoTareaService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMEstadoTarea modelo)
        {

            EstadoTarea NuevoModelo = new EstadoTarea()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            bool respuesta = await _estadoTareaService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _estadoTareaService.Eliminar(id);

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
