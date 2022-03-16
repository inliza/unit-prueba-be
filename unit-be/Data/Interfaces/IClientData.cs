using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using unit_be.Models;

namespace unit_be.Data.Interfaces
{
    public interface IClientData
    {
        bool Create(Client client);
        bool Update(Client client);
        bool Delete(int clientId);
        List<Client> GetAll();
        Client GetById(int clientId);
        bool emailExist(string email);
    }
}
