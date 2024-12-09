using GestionTareasAPI.Models;

namespace GestionTareasAPI.Services
{
    public interface ITareaService
    {
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task<Tarea?> GetByIdAsync(int id);
        Task CreateAsync(Tarea tarea);
        Task UpdateAsync(Tarea tarea);
        Task DeleteAsync(int id);
    }
}
