
using Library.Model;
using Library.Objects;
using Microsoft.EntityFrameworkCore;


namespace Library
{   //Nodig voor migrations.
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Team>().Property(a => a.stamnummer).ValueGeneratedNever();
            modelBuilder.Entity<SpelerTeam>().HasKey(x => new { x.spelerid, x.stamnummer });

            modelBuilder.Entity<Team>()
                .HasMany<Speler>(t => t.spelers)
                .WithOne(s => s.team)
                .HasForeignKey(s => s.teamId);

            modelBuilder.Entity<Speler>()
             .HasOne(a => a.team)
             .WithMany(b => b.spelers)
             .HasForeignKey(s => s.teamId);
             ;



        }
    }
}
