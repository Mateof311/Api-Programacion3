using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_adminService.GetAdmins());
        }

        [HttpGet("[action]")]
        public IActionResult GetAdmin(string name)
        {
            return Ok(_adminService.GetAdminByName(name));
        }

        [HttpPost("[action]")]
        public IActionResult AddAmin([FromBody] AdminDto adminDto) 
        {
            return Ok(_adminService.AddAdmin(adminDto));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateAdmin(int id,[FromBody] AdminDto adminDto)
        {
            _adminService.UpdateAdmin(id, adminDto);
            return Ok("Admin actualizado");
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteAdmin(int id)
        { 
            _adminService.DeleteAdmin(id);
            return Ok("Admin eliminado");
        }
    }
}
