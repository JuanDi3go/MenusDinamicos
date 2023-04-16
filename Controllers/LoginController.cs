using MenusDinamicos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MenusDinamicos.Controllers
{
    public class LoginController : Controller
    {

        private readonly JquerytablebasicContext _context;

        public LoginController(JquerytablebasicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Menu> menuLista = _context.Menus.Include(m => m.InverseIdMenuPadreNavigation).Where(m => m.IdMenuPadre == null).ToList() ;

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
            };

            HttpContext.Session.SetString("menu", JsonSerializer.Serialize(menuLista, options));

            return View();
        }

        [HttpPost]
        public IActionResult Index(string user)
        {
            return View();
        }
    }
}
