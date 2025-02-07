using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_clientService.GetClients());
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(_clientService.GetClientById(id));
        }
        [HttpGet("[action]")]
        public IActionResult GetClient(string email, string password)
        {
            return Ok(_clientService.GetClient( email,password));
        }
        [HttpPost("[action]")]
        public IActionResult AddClient([FromBody] ClientDto clientDto)
        {
            return Ok(_clientService.AddClient(clientDto));
        }
        [HttpPut("[action]")]
        public IActionResult UpdateClient(int id, [FromBody] ClientDto clientDto)
        {
            _clientService.UpdateClient(id, clientDto);
            return Ok();
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
