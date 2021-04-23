using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Helper;
using BOL.DTO;
using BOL.Entity;
using BOL.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempusDigital.Models;


namespace TempusDigital.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepo;

        public ClienteController(IClienteRepository clienteRepo)
        {
            this.clienteRepo = clienteRepo;
        }

        [HttpGet]
        public IActionResult GetAllCliente()
        {
            return Ok(clienteRepo.GetAll());
        }

        [HttpGet("Brief")]
        public IActionResult GetAllClienteBrief([FromQuery]string nome)
        {
            if (String.IsNullOrWhiteSpace(nome))
                return Ok(clienteRepo
                    .GetAll()
                    .ToListClienteBrief());
            
            return Ok(clienteRepo
                .FilterAllByName(nome)
                .ToListClienteBrief());
        }

        [HttpPost]
        public IActionResult AddCliente([FromHeader]ClienteDTO cliente)
        {

            var client = new Cliente(cliente.Nome, cliente.CPF, cliente.DataNascimento, cliente.RendaFamiliar);

            clienteRepo.Add(client);


            return Ok(client);
        }
    }
}
