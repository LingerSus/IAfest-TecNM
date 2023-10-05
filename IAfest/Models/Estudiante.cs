using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IAfest.Models
{
    public class Estudiante
    {
        [Key]
        [Required]
        public int ID_Estudiante { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string NivelEscolar { get; set; }
        [Required]
        public string Domicilio { get; set; }
        [Required]
        public Int64 NumeroTelefono { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string InformacionSocioeconomica { get; set; }
    }
}
