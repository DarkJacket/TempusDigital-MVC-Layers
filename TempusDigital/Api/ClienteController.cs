using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BOL.DTO;
using BOL.Interfaces.Services;



namespace TempusDigital.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetAllCliente()
        {
            return Ok(_clienteService.GetAllCliente());
        }

        [HttpGet("Brief")]
        public IActionResult GetAllClienteBrief([FromQuery]string nome)
        {
            return Ok(_clienteService.GetClienteBriefWhereNameIsEqualOrReturnAll(nome));
        }

        [HttpPost]
        public IActionResult AddCliente([FromHeader]ClienteDTO cliente)
        {
            _clienteService.AddCliente(cliente);

            return Ok();
        }
    }
}
