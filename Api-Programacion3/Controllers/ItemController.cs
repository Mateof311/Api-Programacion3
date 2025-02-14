using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("[action]")]
        public IActionResult GetItemById(int id)
        {
            return Ok(_itemService.GetItemById(id));
        }
        [HttpGet("[action]")]
        public IActionResult GetAllItems()
        {
            return Ok(_itemService.GetItems());
        }
        [HttpPost("[action]")]
        public IActionResult AddItem(ItemDto itemDto)
        {
            return Ok(_itemService.AddItem(itemDto));
        }
        [HttpPut("[action]")]
        public IActionResult UpdateItem(int id, int quantity)
        {
            _itemService.UpdateItem(id, quantity);
            return Ok();

        }
        [HttpDelete("[action]")]
        public IActionResult DeleteItem(int id)
        {
            _itemService.DeleteItem(id);
            return Ok();
        }

    }
}
