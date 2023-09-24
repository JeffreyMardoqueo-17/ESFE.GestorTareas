using Microsoft.AspNetCore.Mvc;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult ViewTarea()
        {
            return View();
        }
    }
}
