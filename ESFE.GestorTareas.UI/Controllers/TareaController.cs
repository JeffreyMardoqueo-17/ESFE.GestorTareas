using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using Microsoft.AspNetCore.Mvc;

namespace ESFE.GestorTareas.UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TareaController : Controller
    {
        //hacemos de una variable privada para almacenar una hijito de ITareaService.
        private readonly ITareaService _tareaServise;
        //Este es el constructir del controlador que toma una instancia de ITareaService como parámetro.
        public TareaController(ITareaService TareaService)
        {
            // Aqui asigno la instancia de ITareaService pasada como parámetro a la variable privada _tareaService.
            _tareaServise = TareaService;
        }

        public IActionResult ViewTarea()
        {
            return View();
        }

        //Insertar tarea
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            // Se realiza una consulta para obtener todas las tareas utilizando _tareaServise
            IQueryable<Tarea> queryTareaSQL = await _tareaServise.ObtenerTodos();
            // Se pasa la lista de tareas a la lista de VMTarea, como que si a los hijitos le das pacha, le das su 
            //pacha correspondiente
            List<VMTarea> lista = queryTareaSQL
                                      .Select(c => new VMTarea()
                                      {
                                          Id = c.Id,
                                          Nombre = c.Nombre
                                      }).ToList();
            //devuelve una respuesta HTTP 200 (OK) con la lista de tareas en formato JSON
            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }
}
