using Microsoft.AspNetCore.Mvc;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Empleado()
        {
            return View();
        }
    }
}
