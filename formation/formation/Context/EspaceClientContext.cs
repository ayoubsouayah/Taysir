using formation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace formation.Context
{
    public class EspaceClientContext:DbContext
    {
        public EspaceClientContext(DbContextOptions<EspaceClientContext>options)
            :base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
    }
}
