using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService :IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService (IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client? GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
        }

        public Client? GetClient(string email, string password)
        {
            return _clientRepository.GetClient(email, password);
        }

        public List<Client> GetClients()
        {
            return _clientRepository.GetClients();
        }
        public int AddClient(ClientDto clientDto)
        {
            var newClient = new Client()
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                Password = clientDto.Password,
                Location = clientDto.Location,
                Dni = clientDto.Dni,
                UserRol = "Client",
                Cart = new Cart(),
            };
            return _clientRepository.AddClient(newClient);
        }

        public void UpdateClient(int id, ClientDto clientDto)
        {
            var newClient = new Client()
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                Password = clientDto.Password,
                Location = clientDto.Location,
                Dni = clientDto.Dni,
            };
            _clientRepository.UpdateClient(id, newClient);
        }
        public void DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
        }

    }
}
