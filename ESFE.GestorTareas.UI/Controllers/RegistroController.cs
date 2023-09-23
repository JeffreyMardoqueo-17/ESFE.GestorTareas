using ESFE.GestorTareas.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace ESFE.GestorTareas.UI.Controllers
{
    public class RegistroController : Controller
    {
        //Inicio de procesos 
        //private readonly IUsuarioService _categoriaService;

        //public RegistroController(ICategoriaService CateServ)
        //{
        //    //_categoriaService = CateServ;
        //}

        public IActionResult ViewUsuario()
        {
            return View();
        }
    }
}
