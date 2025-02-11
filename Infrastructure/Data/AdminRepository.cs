using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AdminRepository : IAdminRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public AdminRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Admin? GetAdminByName(string name)
        {
            return _dbContext.Admins.FirstOrDefault(u => u.Name == name);
        }

        public List<Admin> GetAdmins()
        {
            return _dbContext.Admins.ToList();
        }

        public int AddAdmin(Admin admin)
        {
            _dbContext.Admins.Add(admin);

            _dbContext.SaveChanges();

            return admin.Id;
        }

        public void UpdateAdmin(int id, Admin admin)
        {
            var existingAdmin = _dbContext.Admins.FirstOrDefault(u => u.Id == id);

            if (existingAdmin != null)
            {
                existingAdmin.Name = admin.Name;
                existingAdmin.Email = admin.Email;
                existingAdmin.Password = admin.Password;
                existingAdmin.Dni = admin.Dni;
                existingAdmin.Location = admin.Location;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteAdmin(int id)
        {
            var admin = _dbContext.Admins.FirstOrDefault(x => x.Id == id);

            if (admin != null)
            {
                _dbContext.Admins.Remove(admin);
                _dbContext.SaveChanges();
            }
        }
    }
}
