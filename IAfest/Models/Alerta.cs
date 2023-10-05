using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAfest.Models
{
    public class Alerta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Alerta { get; set; }
        [Required]
        public int ID_Estudiante { get; set; }
        [Required]
        public DateTime FechaAlerta { get; set; }
        [Required]
        public string TipoAlerta { get; set; }
        [Required]
        public string DescripcionAlerta { get; set; }
        [Required]
        public int Mostrar { get; set; }
    }
}
