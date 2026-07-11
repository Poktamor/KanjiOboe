using KanjiOboe.Server.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace KanjiOboe.Server
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Deck> Decks { get; set; } = null!;  
        public DbSet<Card> Cards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
