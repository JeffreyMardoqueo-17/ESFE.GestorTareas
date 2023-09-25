using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AccesoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(VMUsuario modelo)
        {

            if (ModelState.IsValid)
            {
                var usuarioRegistrado = await _usuarioService.Insertar(new Usuario
                {
                    Nombre = modelo.Nombre,
                    Correo = modelo.Correo,
                    Pass = modelo.Pass,
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
            return View(modelo);
        }
    }
}
