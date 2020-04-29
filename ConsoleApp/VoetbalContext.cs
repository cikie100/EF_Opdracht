


using Microsoft.EntityFrameworkCore;
using Model.Objects;

namespace LeagueApp
{
    public class VoetbalContext : DbContext
    {
       public DbSet<Speler> spelers { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<Transfer> transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=EFvoetbalDB;Integrated Security=True");
            //  optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=voetbalDB;Integrated Security=True");

        }
    }
}
