using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace webapi.DataAcces
{
    public class ClienteDA : ICliente
    {
        private readonly WebapiDbContext db;
        public ClienteDA(WebapiDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ClienteBE> ListarClientes()
        {
            List<ClienteBE> clientes = null;
            try
            {
                clientes = db.Cliente.FromSqlRaw("spListarCliente").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return clientes;
        }

        public int ActualizarCliente(ClienteBE cliente)
        {
            int rtn = -1;
            try
            {
                var parametros = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@CodCliente",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.CodCliente
                        },
                        new SqlParameter() {
                            ParameterName = "@NombreCompleto",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.NombreCompleto
                        },
                        new SqlParameter() {
                            ParameterName = "@NombreCorto",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.NombreCorto
                        },
                        new SqlParameter() {
                            ParameterName = "@Abreviatura",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.Abreviatura
                        },
                        new SqlParameter() {
                            ParameterName = "@Ruc",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.Ruc
                        },
                        new SqlParameter() {
                            ParameterName = "@Estado",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Value = cliente.Estado
                        },
                        new SqlParameter() {
                            ParameterName = "@GrupoFacturacion",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.GrupoFacturacion
                        }
                        ,
                        new SqlParameter() {
                            ParameterName = "@InactivoDesde",
                            SqlDbType =  System.Data.SqlDbType.DateTime,
                            Value = cliente.InactivoDesde
                        }
                        ,
                        new SqlParameter() {
                            ParameterName = "@CodigoSAP",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.CodigoSAP
                        }
                };
                rtn = db.Database.ExecuteSqlRaw("spActualizarCliente @CodCliente,@NombreCompleto,@NombreCorto,@Abreviatura,@Ruc,@Estado,@GrupoFacturacion,@InactivoDesde,@CodigoSAP", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtn;
        }

        public int CrearCliente(ClienteBE cliente)
        {
            int rtn = -1;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter> {
                        new SqlParameter() {
                            ParameterName = "@CodCliente",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.CodCliente
                        },
                        new SqlParameter() {
                            ParameterName = "@NombreCompleto",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.NombreCompleto
                        },
                        new SqlParameter() {
                            ParameterName = "@NombreCorto",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.NombreCorto
                        },
                        new SqlParameter() {
                            ParameterName = "@Abreviatura",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.Abreviatura
                        },
                        new SqlParameter() {
                            ParameterName = "@Ruc",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = cliente.Ruc
                        },
                        new SqlParameter() {
                            ParameterName = "@Estado",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Value = cliente.Estado
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@GrupoFacturacion",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Value = cliente.GrupoFacturacion
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@InactivoDesde",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Value = cliente.InactivoDesde
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@CodigoSAP",
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Value = cliente.CodigoSAP
                        }
                };
                rtn = db.Database.ExecuteSqlRaw("spCrearCliente @CodCliente,@NombreCompleto,@NombreCorto,@Abreviatura,@Ruc,@Estado,@GrupoFacturacion,@InactivoDesde,@CodigoSAP", parametros.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtn;
        }

        public int EliminarCliente(string codcliente)
        {
            int rtn = -1;
            try
            {
                var parametros = new SqlParameter[]{
                    new SqlParameter
                    {
                         ParameterName = "@CodCliente",
                        SqlDbType =  System.Data.SqlDbType.VarChar,
                        Value = codcliente
                    }
                };
                rtn = db.Database.ExecuteSqlRaw("spEliminarCliente @CodCliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtn;
        }
    }
}
