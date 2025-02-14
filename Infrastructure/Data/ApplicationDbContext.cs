using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly bool isTestingEnvironment;
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnvironment = false) : base(options)
        {
            this.isTestingEnvironment = isTestingEnvironment;
        }
    
    }

   
}
