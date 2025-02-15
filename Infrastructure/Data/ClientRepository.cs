using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Client? GetClientById(int id)
        {
            return _dbContext.Clients.FirstOrDefault(u => u.Id == id);
        }
        public Client? GetClient(string email, string password)
        {
            return _dbContext.Clients.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
        

        public List<Client> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public int AddClient(Client client)
        {
            _dbContext.Clients.Add(client);

            _dbContext.SaveChanges();

            return client.Id;
        }
        public void AddCartToClient (int id, Cart cart)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(u => u.Id == id);
            if (existingClient != null) 
            { 
                existingClient.CartId = cart.Id;
                _dbContext.SaveChanges();
            }
            
        }

        public void UpdateClient(int id, Client client)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(u => u.Id == id);

            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.Email = client.Email;
                existingClient.Password = client.Password;
                existingClient.Dni = client.Dni;
                existingClient.Location = client.Location;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteClient(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(x => x.Id == id);

            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
        }
    }
}
