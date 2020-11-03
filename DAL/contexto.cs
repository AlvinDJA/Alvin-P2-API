using Alvin_P2_API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Alvin_P2_API.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<TiposTareas> TiposTareas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=DATA\DBParcial2.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TiposTareas>().HasData(
                new TiposTareas { TareaId = 1, Descripcion = "Analisis de Sistemas" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TiposTareas>().HasData(
                new TiposTareas { TareaId = 2, Descripcion = "Diseño de Sistemas" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TiposTareas>().HasData(
                new TiposTareas { TareaId = 3, Descripcion = "Programación Aplicada" }
                );
        }
    }
}
