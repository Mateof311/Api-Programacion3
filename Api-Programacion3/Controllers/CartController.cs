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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("[action]")]
        public IActionResult GetCartById(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin" || userRole == "Client")
            {
                return Ok(_cartService.GetCartById(id));
            }
            return Ok("Rol de usuario no calificado");
            
        }
        [HttpGet("[action]")]
        public IActionResult GetCartByClientId(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin" || userRole == "Admin")
            {
                return Ok(_cartService.GetCartByClientId(id));
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpGet("[action]")]
        public IActionResult GetCarts()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Admin")
            {
                return Ok(_cartService.GetCarts());
            }
            return Ok("Rol de usuario no calificado");
            
        }
        [HttpPost("[action]")]
        public IActionResult AddCart(CartDto cartDto)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                return Ok(_cartService.AddCart(cartDto));
            }
            return Ok("Rol de usuario no calificado");
            
        }
        [HttpPost("{cartId}/add-item/{itemId}")]
        public IActionResult AddItemToCart(int cartId, int itemId)
        {
            try
            {
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                if (userRole == "Client")
                {
                    _cartService.AddItemToCart(cartId, itemId);
                return Ok("Item agregado al carrito");
                }
                return Ok("Rol de usuario no calificado");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("[action]")]
        public IActionResult UpdateCart(int id, bool delivery)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                _cartService.UpdateCart(id, delivery);
            return Ok("Carrito actualizado");
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteCart(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client")
            {
                _cartService.DeleteCart(id);
                return Ok("Cariito eliminado");
            }
            return Ok("Rol de usuario no calificado");
            
        }
    }
}
