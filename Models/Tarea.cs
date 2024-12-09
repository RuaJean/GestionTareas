using System.ComponentModel.DataAnnotations;

namespace GestionTareasAPI.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public EstadoTarea Estado { get; set; }
    }

    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        Completada
    }
}
