using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Models
{
    public class ClienteBE
    {
        [Key]
        public string CodCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreCorto { get; set; }
        public string Abreviatura { get; set; }
        public string Ruc { get; set; }
        public char Estado { get; set; }
        public string GrupoFacturacion { get; set; }
        public DateTime? InactivoDesde{ get; set; }
        public string CodigoSAP { get; set; }
    }
}
