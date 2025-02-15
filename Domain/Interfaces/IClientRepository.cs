using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        public Client? GetClientById(int id);
        public Client? GetClient(string email, string password);
        public List<Client> GetClients();
        public int AddClient(Client client);
        public void AddCartToClient(int id, Cart cart);
        public void UpdateClient(int id, Client client);
        public void DeleteClient(int id);
    }
}
