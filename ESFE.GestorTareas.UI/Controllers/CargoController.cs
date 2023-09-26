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
        //Constructor de la clase CargoControler
        //Recibe un parametro que se utiliza para inyectar dependencia de esa clase (Cargo)
        private readonly ICargoService _cargoService;
        public CargoController(ICargoService CargoServ)
        {
            //asigno la instancia
            _cargoService = CargoServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        //vista de Cargo
        public IActionResult Cargo()
        {
            return View();
        }

        //Enlistar cargos
        [HttpGet]
        //Es asincronico va
        public async Task<IActionResult> Lista() //Se llama  obtener todos   de _cargoService para obtener una IQueryable<Cargo>.
        {

            IQueryable<Cargo> queryCargoSQL = await _cargoService.ObtenerTodos();

            // Pasa los objetos Cargo en objetos VMCargo y los almacena en una lista
            List<VMCargo> lista = queryCargoSQL
                                      .Select(c => new VMCargo()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList(); //la lista
            //rtorna una respuesta http con un código de estado 200 OK y la lista de objetos VMCargo como resultado.
            return StatusCode(StatusCodes.Status200OK, lista); //esto indica que la solicitud fue exitosa
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMCargo modelo)
        {
            //creamos un hijito de Cargo
            Cargo NuevoModelo = new Cargo()
            {
                Nombre = modelo.Nombre
            };
            // Llama de manera asincrónica al metodo Insertar de _cargoService para insertar el nuevo modlo
            bool respuesta = await _cargoService.Insertar(NuevoModelo);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta }); //La solitud si esta good
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMCargo modelo)
        {
            //hace una instancia del modelo cargo
            Cargo NuevoModelo = new Cargo()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            //Aqui se llama de manera async al metodo Actualizar de _cargoService para actualizar el nuevo modelo.
            bool respuesta = await _cargoService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta }); //solicitud exitosa
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            //LLamo el metodo de eliminar y le paso el parametro id para que se elimine ese 
            bool respuesta = await _cargoService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });//Respuesta exitosa
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
