using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.DAL.DataContext;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        //login
        public ActionResult Login()
        {
            return View();
        }
        // Registrar
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario usuarioG)
        {
            return View();
        }

    }
}
