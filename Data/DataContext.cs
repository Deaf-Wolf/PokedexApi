using Microsoft.EntityFrameworkCore;
using PokedexApi.Model;

namespace PokedexApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
