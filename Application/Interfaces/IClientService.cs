using Domain.Entities;
using Application.Models.Dtos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public Client? GetClientById(int id);
        public Client? GetClient(string email, string password);
        public List<Client> GetClients();
        public int AddClient(ClientDto clientDto);
        public void UpdateClient(int id, ClientDto clientDto);
        public void DeleteClient(int id);

    }
}
