using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unit_be.Data.Interfaces;
using unit_be.Models;

namespace unit_be.Data
{
    public class ClientData : IClientData
    {


        public bool Create(Client client)
        {
            ClientRepo.counterId++;
            client.id = ClientRepo.counterId;
            ClientRepo.clients.Add(client);

            return true;
        }

        public bool Delete(int clientId)
        {
            var c = ClientRepo.clients.Find(x => x.id == clientId);
            ClientRepo.clients.Remove(c);
            return true;
        }

        public bool emailExist(string email)
        {
            var client = ClientRepo.clients.Where(x => x.email == email).FirstOrDefault();
            return client != null ? true : false;
        }

        public List<Client> GetAll()
        {
            return ClientRepo.clients.OrderBy(o => o.id).ToList();
        }

        public Client GetById(int clientId)
        {
            return ClientRepo.clients.Find(c => c.id == clientId);
        }

        public bool Update(Client client)
        {
            var c = ClientRepo.clients.Where(x => x.id == client.id).FirstOrDefault();
            ClientRepo.clients.Remove(c);
            ClientRepo.clients.Add(client);
            return true;

        }
    }
}
