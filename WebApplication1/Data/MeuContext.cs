using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MeuContext : DbContext
    {
        public MeuContext (DbContextOptions<MeuContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.UsuarioModel> UsuarioModel { get; set; }
    }
}
