using Api_Full06.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Full06.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> opts) : base(opts)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Componente> Componentes { get; set; }
    }
}