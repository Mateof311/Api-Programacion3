using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api_Programacion3.Controllers
{
    [Authorize]
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
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin")
            {
                return Ok(_adminService.GetAdmins());
            }
            return Ok("Rol de usuario no calificado");
        }

        [HttpGet("[action]/{name}")]
        public IActionResult GetAdmin(string name)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin")
            {
                return Ok(_adminService.GetAdminByName(name));
            }
            return Ok("Rol de usuario no calificado");
        }

        [HttpPost("[action]")]
        public IActionResult AddAmin([FromBody] AdminDto adminDto) 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin")
            {
                return Ok(_adminService.AddAdmin(adminDto));
            }
            return Ok("Rol de usuario no calificado");
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateAdmin(int id,[FromBody] AdminDto adminDto)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin")
            {
                _adminService.UpdateAdmin(id, adminDto);
            return Ok("Admin actualizado");
            }
            return Ok("Rol de usuario no calificado");
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole == "SysAdmin")
            {
                _adminService.DeleteAdmin(id);
            return Ok("Admin eliminado");
            }
            return Ok("Rol de usuario no calificado");
        }
    }
}
