using System.ComponentModel.DataAnnotations;

namespace IAfest.Models
{
    public class Intervencion
    {
        [Key]
        [Required]
        public int ID_Intervencion { get; set; }
        [Required]
        public int ID_Estudiante { get; set; }
        [Required]
        public DateTime FechaIntervencion { get; set; }
        [Required]
        public string TipoIntervencion { get; set; }
        [Required]
        public string ResultadoIntervencion { get; set; }
    }
}
