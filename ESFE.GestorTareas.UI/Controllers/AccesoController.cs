using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class AccesoController : Controller
    {
        //Instancia de servicio
        private readonly IUsuarioService _usuarioService;

        public AccesoController(IUsuarioService usuarioService)
        {
            //a Uservice le asigno la variable UsuarioServce
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //vista registro
        public IActionResult Registro()
        {
            return View();
        }

        //Registro de Usuario
        [HttpPost]
        public async Task<IActionResult> Registro(VMUsuario m)
        {

            if (ModelState.IsValid)
            {
                //Instancia de Usuario
                    var usuarioRegistrado = await _usuarioService.Insertar(new Usuario
                    {
                    //Prioridades de Usuario
                    Nombre = m.Nombre,
                    Correo = m.Correo,
                    Pass = m.Pass,
                    });

                    if (usuarioRegistrado)
                    {
                        return RedirectToAction("Index", "Acceso");
                    }
                    else
                    {
                        // Hubo un error al registrar al usuario
                        ModelState.AddModelError(string.Empty, "Hubo un error al registrar el usuario.");
                    }
                }

            // Si el modelo no es válido o hubo un error, muestra la vista de registro nuevamente
            return View(m);
        }
    }
}

