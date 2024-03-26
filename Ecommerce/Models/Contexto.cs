using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        { 

        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente{ get; set; }

        public DbSet<Venda> Venda { get; set; }
    }
}
