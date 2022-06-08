using System;
using System.Collections.Generic;
using System.Text;
using webapi.Models;

namespace webapi.DataAcces
{
    public interface ICliente
    {
        IEnumerable<ClienteBE> ListarClientes();
        int CrearCliente(ClienteBE cliente);
        int ActualizarCliente(ClienteBE cliente);
        int EliminarCliente(string codcliente);
    }
}
