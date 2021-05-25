using Microsoft.EntityFrameworkCore;
using testeef.Models;

namespace testeef.Data
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        {
        }
        
        public DbSet<Produto> Produtos    { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}