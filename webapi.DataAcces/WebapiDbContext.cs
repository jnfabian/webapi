using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.DataAcces
{
    public class WebapiDbContext : DbContext
    {
        public WebapiDbContext(DbContextOptions<WebapiDbContext> options): base(options){}
        public DbSet<ClienteBE> Cliente { get; set; }
    }
}
