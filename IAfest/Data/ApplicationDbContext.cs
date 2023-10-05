using IAfest.Models;
using Microsoft.EntityFrameworkCore;

namespace IAfest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Asistencia> RegistrosAsistencia { get; set; }

        public DbSet<ResultadoAcademico> ResultadosAcademicos { get; set; }

        public DbSet<DatosComplementarios> DatosComplementarios { get; set; }

        public DbSet<Alerta> Alertas { get; set; }

        public DbSet<Intervencion> HistorialIntervenciones { get; set; }
    }
}
