using Microsoft.EntityFrameworkCore;

namespace Alvin_P2_API.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=DATA\DBParcial2.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Suplidores>().HasData(
            //    new Suplidores { SuplidorId = 1, Nombres = "Juan Jose" }
            //    );
        }
    }
}
