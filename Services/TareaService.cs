using GestionTareasAPI.Data;
using GestionTareasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTareasAPI.Services
{
    public class TareaService : ITareaService
    {
        private readonly ApplicationDbContext _context;

        public TareaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<Tarea?> GetByIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task CreateAsync(Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarea tarea)
        {
            var existing = await _context.Tareas.FindAsync(tarea.Id);
            if (existing == null)
                throw new KeyNotFoundException("Tarea no encontrada.");

            existing.Titulo = tarea.Titulo;
            existing.Descripcion = tarea.Descripcion;
            existing.FechaVencimiento = tarea.FechaVencimiento;
            existing.Estado = tarea.Estado;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                throw new KeyNotFoundException("Tarea no encontrada.");

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
        }
    }
}
