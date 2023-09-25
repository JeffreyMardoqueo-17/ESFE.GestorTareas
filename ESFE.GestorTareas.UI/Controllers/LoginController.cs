using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ESFE.GestorTareas.EN;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class LoginController : Controller
    {

        // Método para mostrar la vista de inicio de sesión

        public ActionResult Index()
        {
            return View();
        }
        //metodo para acceder
        public ActionResult Access()
        {
            return View();
        }
    }
}
