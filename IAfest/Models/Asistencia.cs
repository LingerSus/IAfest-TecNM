using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAfest.Models
{
    public class Asistencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Registro { get; set; }
        [Required]
        public int ID_Estudiante { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public string EstadoAsistencia { get; set; }
    }
}
