using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        public Admin? GetAdminByName(string name);

        public List<Admin> GetAdmins();

        public int AddAdmin(AdminDto adminDto);

        public void UpdateAdmin(int id, AdminDto adminDto);

        public void DeleteAdmin(int id);
        
    }
}
