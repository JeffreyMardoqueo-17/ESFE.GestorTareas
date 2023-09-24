using ESFE.GestorTareas.BL.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

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
        private readonly IRegisteredServices _registroService;

        public RegistroController(IRegisteredServices regSer)
        {
            _registroService = regSer;
        }

        public IActionResult ViewUsuario()
        {
            return View();
        }
    }
}
