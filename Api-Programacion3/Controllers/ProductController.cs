using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api_Programacion3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById(int id)
        {

            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Client" || userRole == "Admin")
            {
                return Ok( _productService.GetProductById(id));
            }
            return Ok("Rol de usuario no calificado");
            
        }

        [HttpPost("[action]")]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Admin")
            {
                return Ok(_productService.AddProduct(productDto));
            }
            return Ok("Rol de usuario no calificado");
            
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateProduct(int id,[FromBody] ProductDto productDto)
        {

            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Admin")
            {
                _productService.UpdateProduct(id, productDto);
                return Ok("Producto actualizado");
            }
            return Ok("Rol de usuario no calificado");
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "Admin")
            {
                _productService.DeletePoduct(id);
                return Ok("Producto eliminado");
            }
            return Ok("Rol de usuario no calificado");
            
        }
    }
}
