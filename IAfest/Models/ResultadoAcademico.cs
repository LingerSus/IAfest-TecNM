using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAfest.Models
{
    public class ResultadoAcademico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Registro { get; set; }
        [Required]
        public int ID_Estudiante { get; set; }
        [Required]
        public string Materia { get; set; }
        [Required]
        public int Calificacion { get; set; }
        [Required]
        public decimal AsistenciaPorcentaje { get; set; }
    }
}
