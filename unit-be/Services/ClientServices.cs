using System;
using System.Threading.Tasks;
using unit_be.Data.Interfaces;
using unit_be.Helpers;
using unit_be.Models;
using unit_be.Services.Interfaces;

namespace unit_be.Services
{
    public class ClientServices : IClientService
    {
        private readonly IClientData clientData;
        public ClientServices(IClientData clientData)
        {
            this.clientData = clientData;
        }

        public async Task<ServicesResponse> Create(Client client)
        {
            try
            {
                if (await Task.Factory.StartNew(() => clientData.emailExist(client.email)))
                    return new ServicesResponse(System.Net.HttpStatusCode.BadRequest, "Error", "Este email ya está registrado", client);

                var res = await Task.Factory.StartNew(() => clientData.Create(client));
                return new ServicesResponse(System.Net.HttpStatusCode.OK, "Correcto", "", res);

            }
            catch (Exception ex)
            {
                return new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado. Favor comuniquese con el administrador.", ex);
            }

        }

        public async Task<ServicesResponse> Delete(int clientId)
        {
            try
            {
                var res = await Task.Factory.StartNew(() => clientData.Delete(clientId));
                return new ServicesResponse(System.Net.HttpStatusCode.OK, "Correcto", "", res);

            }
            catch (Exception ex)
            {
                return new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado. Favor comuniquese con el administrador.", ex);
            }
        }

        public async Task<ServicesResponse> GetAll()
        {
            try
            {
                var res = await Task.Factory.StartNew(() => clientData.GetAll());
                return new ServicesResponse(System.Net.HttpStatusCode.OK, "Correcto", "", res);

            }
            catch (Exception ex)
            {
                return new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado. Favor comuniquese con el administrador.", ex);
            }
        }

        public async Task<ServicesResponse> GetById(int clientId)
        {
            try
            {
                var res = await Task.Factory.StartNew(() => clientData.GetById(clientId));
                if (res != null)
                    return new ServicesResponse(System.Net.HttpStatusCode.OK, "Correcto", "", res);
                else
                    return new ServicesResponse(System.Net.HttpStatusCode.NotFound, "Cliente no encontrado", "", res);
            }
            catch (Exception ex)
            {
                return new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperados. Favor comuniquese con el administrador.", ex);
            }
        }

        public async Task<ServicesResponse> Update(Client client)
        {
            try
            {
                var res = await Task.Factory.StartNew(() => clientData.Update(client));
                return new ServicesResponse(System.Net.HttpStatusCode.OK, "Correcto", "", res);

            }
            catch (Exception ex)
            {
                return new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado. Favor comuniquese con el administrador.", ex);
            }
        }
    }
}
