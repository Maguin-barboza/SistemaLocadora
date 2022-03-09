using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Domain.Models;

namespace SistemaLocadora.Server.Context
{
    public class LocadoraContext: DbContext
    {
        public LocadoraContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Filme> filme { get; set; }
        public DbSet<Locacao> locacao { get; set; }
    }
}
