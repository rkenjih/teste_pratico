using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace EISOL_TestePratico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.ViewBag.Message = "Bem-vido ao teste prático EISOL com ASP.NET MVC";
            return View();
        }

        public IActionResult CadastrarPessoa()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
