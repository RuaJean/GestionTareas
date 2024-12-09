using Microsoft.EntityFrameworkCore;
using GestionTareasAPI.Models;

namespace GestionTareasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>()
                .Property(t => t.Estado)
                .HasConversion(
                    v => v.ToString(), 
                    v => (EstadoTarea)Enum.Parse(typeof(EstadoTarea), v) 
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
