using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Programacion3.Controllers
{
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
            return Ok(_cartService.GetCartById(id));
        }
        [HttpGet("[action]")]
        public IActionResult GetCartByClientId(int id)
        {
            return Ok(_cartService.GetCartByClientId(id));
        }
        [HttpGet("[action]")]
        public IActionResult GetCarts()
        {
            return Ok(_cartService.GetCarts());
        }
        [HttpPost("[action]")]
        public IActionResult AddCart(CartDto cartDto)
        {
            return Ok(_cartService.AddCart(cartDto));
        }
        [HttpPut("[action]")]
        public IActionResult UpdateCart(int id, bool delivery)
        {
            _cartService.UpdateCart(id, delivery);
            return Ok();
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteCart(int id)
        {
            _cartService.DeleteCart(id);
            return Ok();
        }
    }
}
