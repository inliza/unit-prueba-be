using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using unit_be.Helpers;
using unit_be.Models;
using unit_be.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unit_be.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                ServicesResponse res = await clientService.GetAll();
                if (res.Code == System.Net.HttpStatusCode.OK)
                    return StatusCode(200, res);
                else
                    return res.Code == System.Net.HttpStatusCode.BadRequest ? StatusCode(400, res) : StatusCode(500, res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado, favor intente mas tarde", ex));
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int clientId)
        {
            try
            {
                if (clientId == null || clientId == 0)
                    return BadRequest(new ServicesResponse(System.Net.HttpStatusCode.BadRequest, "Error en validacion", "Parametro invalido", clientId));

                ServicesResponse res = await clientService.GetById(clientId);
                if (res.Code == System.Net.HttpStatusCode.OK)
                    return StatusCode(200, res);
                else
                    return res.Code == System.Net.HttpStatusCode.BadRequest ? StatusCode(400, res) : StatusCode(500, res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado, favor intente mas tarde", ex));
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Client client)
        {
            try
            {
                if (client == null)
                    return BadRequest(new ServicesResponse(System.Net.HttpStatusCode.BadRequest, "Error en validacion", "Objeto invalido", client));

                ServicesResponse res = await clientService.Create(client);
                if (res.Code == System.Net.HttpStatusCode.OK)
                    return StatusCode(200, res);
                else
                    return res.Code == System.Net.HttpStatusCode.BadRequest ? StatusCode(400, res) : StatusCode(500, res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado, favor intente mas tarde", ex));
            }

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Client client)
        {
            try
            {
                if (client == null)
                    return BadRequest(new ServicesResponse(System.Net.HttpStatusCode.BadRequest, "Error en validacion", "Objeto invalido", client));

                ServicesResponse res = await clientService.Update(client);
                if (res.Code == System.Net.HttpStatusCode.OK)
                    return StatusCode(200, res);
                else
                    return res.Code == System.Net.HttpStatusCode.BadRequest ? StatusCode(400, res) : StatusCode(500, res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado, favor intente mas tarde", ex));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int clientId)
        {
            try
            {
                if (clientId == null || clientId == 0)
                    return BadRequest(new ServicesResponse(System.Net.HttpStatusCode.BadRequest, "Error en validacion", "Parametro invalido", clientId));

                ServicesResponse res = await clientService.Delete(clientId);
                if (res.Code == System.Net.HttpStatusCode.OK)
                    return StatusCode(200, res);
                else
                    return res.Code == System.Net.HttpStatusCode.BadRequest ? StatusCode(400, res) : StatusCode(500, res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(System.Net.HttpStatusCode.InternalServerError, "Error", "Ha ocurrido un error inesperado, favor intente mas tarde", ex));
            }
        }


    }

}
