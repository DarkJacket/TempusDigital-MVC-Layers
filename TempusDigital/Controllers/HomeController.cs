using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL.DTO;
using BOL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TempusDigital.Controllers
{
    public class HomeController : Controller
    {


        public HomeController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        private readonly IClienteService _clienteService;

        public IActionResult Index()
        {
            return View(_clienteService.GetIndexDTO());

        }

        public IActionResult Clientes([FromQuery]string filter)
        {
            return View(_clienteService.GetClienteBriefWhereNameIsEqualOrReturnAll(filter).ToList());

        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form([FromForm]ClienteDTO cliente)
        {

            if (ModelState.IsValid)
            {
                _clienteService.AddCliente(cliente);
                return Redirect("Index");
            }

            return View(cliente);

        }
    }
}
