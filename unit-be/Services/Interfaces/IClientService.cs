using System;
using System.Threading.Tasks;
using unit_be.Helpers;
using unit_be.Models;

namespace unit_be.Services.Interfaces
{
    public interface IClientService
    {
        Task<ServicesResponse> Create(Client client);
        Task<ServicesResponse> Update(Client client);
        Task<ServicesResponse> Delete(int clientId);
        Task<ServicesResponse> GetAll();
        Task<ServicesResponse> GetById(int clientId);
    }
}
