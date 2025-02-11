using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin? GetAdminByName(string name)
        {
            return _adminRepository.GetAdminByName(name);
        }
        public List<Admin> GetAdmins()
        {
            return _adminRepository.GetAdmins();
        }
        public int AddAdmin(AdminDto adminDto)
        {
            var newAdmin = new Admin()
            {
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = adminDto.Password,
                Location = "AdminLocation",
                Dni = adminDto.Dni,
                UserRol = "Admin",
            };
            return _adminRepository.AddAdmin(newAdmin);
        }

        public void UpdateAdmin(int id, AdminDto adminDto)
        {
            var newAdmin = new Admin()
            {
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = adminDto.Password,
                Location = "AdminLocation",
                Dni = adminDto.Dni,
            };
            _adminRepository.UpdateAdmin(id, newAdmin);
        }
        public void DeleteAdmin(int id)
        {
            _adminRepository.DeleteAdmin(id);
        }
    }
}
