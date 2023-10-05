using System.ComponentModel.DataAnnotations;

namespace IAfest.Models
{
    public class DatosComplementarios
    {
        [Key]
        [Required]
        public int ID_Estudiante { get; set; }
        [Required]
        public string Comportamiento { get; set; }
        [Required]
        public string ParticipacionActividadesExt { get; set; }
        [Required]
        public string ApoyoFamiliar { get; set; }
        [Required]
        public string InformacionMedica { get; set; }
    }
}
