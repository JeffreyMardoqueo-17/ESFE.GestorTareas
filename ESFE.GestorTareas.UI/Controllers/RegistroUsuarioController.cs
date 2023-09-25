using Microsoft.AspNetCore.Mvc;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class RegistroUsuarioController : Controller
    {
        public IActionResult ViewRegistroUsuario()
        {
            return View("RegistroUsuario/Registro");
        }
    }
}
