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
        /// <summary>
        /// //Constructor de la clase EstadoTareaControler
        //Recibe un parametro que se utiliza para inyectar dependencia de esa clase (Estado)
        /// </summary>
        private readonly IEstadoTareaService _estadoTareaService;

        public EstadoTareaController(IEstadoTareaService EstadoServ)
        {
            //asigno la instancia
            _estadoTareaService = EstadoServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        //vista de EstadoTarea
        public IActionResult EstadoTarea()
        {
            return View();
        }

        //Lista DE Estados Tarea
        [HttpGet]
        public async Task<IActionResult> Lista() 
        {

            IQueryable<EstadoTarea> queryEstadoTareaSQL = await _estadoTareaService.ObtenerTodos(); //obtenemos todos los que ya estan regitrados
            // Pasa los objetos Cargo en objetos VMEstadoTarea y los almacena en una lista
            List<VMEstadoTarea> lista = queryEstadoTareaSQL
                                      .Select(c => new VMEstadoTarea()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista); //exito
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMEstadoTarea modelo)
        {
            //hacemos un hijito de Estado Tarea
            EstadoTarea NuevoModelo = new EstadoTarea()
            {
                Nombre = modelo.Nombre
            };
            //Paso el Nuevomodelo
            bool respuesta = await _estadoTareaService.Insertar(NuevoModelo);
            //Exito
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMEstadoTarea modelo)
        {
            //Estado de tarea, un hijito paso 
            EstadoTarea NuevoModelo = new EstadoTarea()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre
            };
            //paso el hijo a vestirlo
            bool respuesta = await _estadoTareaService.Actualizar(NuevoModelo);
            //Se vistio bien, todo goood => Exito
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            //paso el parametro Id para eliminar
            bool respuesta = await _estadoTareaService.Eliminar(id);
            //Exitoooooooooooooo
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
s