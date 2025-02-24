using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api_Programacion3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetItemById(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                return Ok(_itemService.GetItemById(id));
            }
            return Ok("Rol de usuario no calificado"); 
        }
        [HttpGet("[action]")]
        public IActionResult GetAllItems()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Admin")
            {
                 return Ok(_itemService.GetItems());
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpPost("[action]")]
        public IActionResult AddItem(ItemDto itemDto)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                return Ok(_itemService.AddItem(itemDto));
            }
            return Ok("Rol de usuario no calificado");

           
        }     
        [HttpPut("[action]/{id}")]
        public IActionResult UpdateItem(int id, int quantity)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                _itemService.UpdateItem(id, quantity);
                return Ok("Item actualizado");
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                _itemService.DeleteItem(id);
                return Ok("Item eliminado");
            }
            return Ok("Rol de usuario no calificado");
        }

    }
}
