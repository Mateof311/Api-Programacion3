using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUserByName(string name)
        {
            return _dbContext.Users.Where(x => x.Name == name).ToList();
        }
        public User? GetUserByEmail(string email)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Email == email);
        }

    }
}
