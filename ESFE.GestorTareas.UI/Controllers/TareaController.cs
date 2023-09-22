using Microsoft.AspNetCore.Mvc;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
