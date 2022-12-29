using GamesAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Game { get; set; } 

    }
}
