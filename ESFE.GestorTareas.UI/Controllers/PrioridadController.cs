using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using ESFE.GestorTareas.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class PrioridadController : Controller
    {
        private readonly IPrioridadService _prioridadService;

        public PrioridadController(IPrioridadService PrioServ)
        {
            _prioridadService = PrioServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prioridad()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<Prioridad> queryPrioridadSQL = await _prioridadService.ObtenerTodos();

            List<VMPrioridad> lista = queryPrioridadSQL
                                      .Select(c => new VMPrioridad()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMPrioridad modelo)
        {

            Prioridad NuevoModelo = new Prioridad()
            {
                Nombre = modelo.Nombre
            };
            bool respuesta = await _prioridadService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMPrioridad modelo)
        {

            Prioridad NuevoModelo = new Prioridad()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            bool respuesta = await _prioridadService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _prioridadService.Eliminar(id);

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
