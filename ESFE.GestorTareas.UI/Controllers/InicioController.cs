using Microsoft.AspNetCore.Mvc;
using ESFE.GestorTareas.UI.Recursos;
using ESFE.GestorTareas.BL.Service;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ESFE.GestorTareas.EN;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class InicioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public InicioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Pass = Utilidades.EncriptarClave(modelo.Pass);

            Usuario usuarioCreado = await _usuarioService.SaveUsuario(modelo);

            if (usuarioCreado.Id>0)

                return RedirectToAction("IniciarSesion","Inicio");

            ViewData["Mensaje"] = "No fue posible crear al usuario";

            return View();
        }

        public async Task<IActionResult> IniciarSesion(string nombre, string correo, string pass)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuario(nombre, correo, Utilidades.EncriptarClave(pass));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "No se encontro ninguna coincidencia";

                return View();
            }

            List<Claim> claims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Name, usuarioEncontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true         
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
