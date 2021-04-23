using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TempusDigital.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Clientes()
        {
            return View();

        }

        public IActionResult Form()
        {
            return View();
        }
    }
}
