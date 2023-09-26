using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using ESFE.GestorTareas.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService CargoServ)
        {
            _cargoService = CargoServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cargo()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<Cargo> queryCargoSQL = await _cargoService.ObtenerTodos();

            List<VMCargo> lista = queryCargoSQL
                                      .Select(c => new VMCargo()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMCargo modelo)
        {

            Cargo NuevoModelo = new Cargo()
            {
                Nombre = modelo.Nombre
            };
            bool respuesta = await _cargoService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMCargo modelo)
        {

            Cargo NuevoModelo = new Cargo()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            bool respuesta = await _cargoService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _cargoService.Eliminar(id);

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
