using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
           return Ok( _productService.GetProductById(id));
        }

        [HttpPost("[action]")]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            return Ok(_productService.AddProduct(productDto));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateProduct(int id,[FromBody] ProductDto productDto)
        {
            _productService.UpdateProduct(id, productDto);
            return Ok("Producto actualizado");
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeletePoduct(id);
            return Ok("Producto eliminado");
        }
    }
}
