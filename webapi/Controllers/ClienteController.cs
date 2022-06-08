using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.DataAcces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private ICliente service;
        public ClienteController(ICliente service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ClienteBE> ListarClientes()
        {
            List<ClienteBE> clientes =  service.ListarClientes().ToList();
            return clientes;
        }

        [HttpPost]
        public ActionResult CrearCliente(ClienteBE cliente)
        {
            int rtn = service.CrearCliente(cliente);
            if (rtn > 0)
                return Ok("se registro correctamente");
            else
                return BadRequest("El cliente ya existe");
        }
        [HttpPut]
        public ActionResult ActualizarCliente(ClienteBE cliente)
        {
            int rtn = service.ActualizarCliente(cliente);
            if (rtn > 0)
                return Ok("se actualizo correctamente");
            else
                return BadRequest("El cliente no existe");

        }
        [HttpDelete]
        public ActionResult EliminarCliente(ClienteBE cliente)
        {
            int rtn = service.EliminarCliente(cliente.CodCliente);
            if (rtn > 0)
                return Ok("se Elimino correctamente");
            else
                return BadRequest("El cliente no existe");
        }
    }
}
