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
        public User? GetClient(string email, string password);
        public List<Client> GetClients();
        public int AddClient(Client client);
        public void UpdateClient(int id, Client client);
        public void DeleteClient(int id);
    }
}
