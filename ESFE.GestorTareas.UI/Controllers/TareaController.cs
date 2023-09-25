using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using ESFE.GestorTareas.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class TareaController : Controller
    {
        private readonly ITareaService _TareaService;

        public TareaController(ITareaService TareaService)
        {
            _TareaService = TareaService;
        }
        //vista
        public IActionResult Tarea()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<Tarea> queryCategoriumSQL = await _TareaService.ObtenerTodos();

            List<VMTarea> lista = queryCategoriumSQL
                                      .Select(j => new VMTarea()
                                      {
                                          Id = (byte)j.Id,
                                          Nombre = j.Nombre,
                                          Descripcion = j.Descripcion,
                                          FechaVencimiento = j.FechaVencimiento,
                                          IdCategoria = j.IdCategoria,
                                          IdPrioridad = j.IdPrioridad,
                                          IdEstadoTarea = j.IdEstadoTarea,
                                          AsignacionTareas = j.AsignacionTareas,
                                          IdCategoriumNavigation = j.IdCategoriumNavigation,
                                          IdEstadoTareaNavigation = j.IdEstadoTareaNavigation,
                                          IdPrioridadNavigation = j.IdPrioridadNavigation
                                      }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMTarea m)
        {

            Tarea NuevoModelo = new Tarea()
            {
                Nombre = m.Nombre,
                Descripcion = m.Descripcion,
                FechaVencimiento = m.FechaVencimiento,
                IdCategoria = m.IdCategoria,
                IdPrioridad = m.IdPrioridad,
                IdEstadoTarea = m.IdEstadoTarea,
                AsignacionTareas = m.AsignacionTareas,
                IdCategoriumNavigation = m.IdCategoriumNavigation,
                IdEstadoTareaNavigation = m.IdEstadoTareaNavigation,
                IdPrioridadNavigation = m.IdPrioridadNavigation
            };
            bool respuesta = await _TareaService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMTarea m)
        {

            Tarea NuevoModelo = new Tarea()
            {
                Nombre = m.Nombre,
                Descripcion = m.Descripcion,
                FechaVencimiento = m.FechaVencimiento,
                IdCategoria = m.IdCategoria,
                IdPrioridad = m.IdPrioridad,
                IdEstadoTarea = m.IdEstadoTarea,
                AsignacionTareas = m.AsignacionTareas,
                IdCategoriumNavigation = m.IdCategoriumNavigation,
                IdEstadoTareaNavigation = m.IdEstadoTareaNavigation,
                IdPrioridadNavigation = m.IdPrioridadNavigation
            };
            bool respuesta = await _TareaService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _TareaService.Eliminar(id);

            // Esta es una acción de controlador que devuelve una respuesta HTTP con un estado 200 (OK).
            // La respuesta contiene un objeto JSON en el cuerpo.
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        /// <summary>
        /// Este atributo indica cómo debe gestionarse el almacenamiento en caché de la respuesta HTTP.
        // En este caso, Duration = 0 significa que no se almacena en caché la respuesta,
        // Location = ResponseCacheLocation.None especifica que no se debe almacenar en ningún lugar específico,
        // y NoStore = true indica que no se debe almacenar en caché.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Aqui se devuelve una vista llamada "errorr" junto con un objeto ErrorViewModel.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Esto se hace para rastrear y registrar el error.
    }
}
