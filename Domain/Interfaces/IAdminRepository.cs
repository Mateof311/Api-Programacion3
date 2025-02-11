using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminRepository
    {
        public Admin? GetAdminByName(string name);

        public List<Admin> GetAdmins();

        public int AddAdmin(Admin admin);

        public void UpdateAdmin(int id, Admin admin);

        public void DeleteAdmin(int id);
        
    }
}
