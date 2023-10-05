using IAfest.Data;
using IAfest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAfest.Controllers
{
    public class AlertaController : Controller
    {
        
        



    private readonly ApplicationDbContext _db;

        public AlertaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var alertas = _db.Alertas.ToList();
            return View(alertas);
        }

        public IActionResult Ignorar(int id)
        {
            try
            {
                var alerta = _db.Alertas.Find(id);
                if (alerta == null)
                {
                    return NotFound();
                }
                alerta.Mostrar = 0;
                _db.Update(alerta);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Create()
        {
            try
            {
                //Obtener todos los Resultados Academicos
                var resultados = _db.ResultadosAcademicos.ToList();
                //Obtener todos los Estudiantes
                var estudiantes = _db.Estudiantes.ToList();
                //Recorrer todos los estudiantes
                foreach (var estudiante in estudiantes)
                {
                    //Recorrer todos los resultados academicos por estudiantes con LINQ
                    var resultadosEstudiante = resultados.Where(r => r.ID_Estudiante == estudiante.ID_Estudiante).ToList();
                    // Contar las calificaciones Menores a 70
                    var calificacionesMenores = resultadosEstudiante.Where(r => r.Calificacion < 70).Count();
                    // Si las calificaciones menores a 70 son mas del 50% del total, Crear una Alerta
                    if (calificacionesMenores > (resultadosEstudiante.Count / 2))
                    {
                        // Crear Alerta
                        var alerta = new Alerta
                        {
                            ID_Estudiante = estudiante.ID_Estudiante,
                            FechaAlerta = DateTime.Now,
                            TipoAlerta = "Calificacion",
                            DescripcionAlerta = "El estudiante " + estudiante.NombreCompleto + " tiene mas del 50% de sus calificaciones menores a 70",
                            Mostrar = 1
                        };
                        //Review if current Alerta already exists
                        var alertaExistente = _db.Alertas.Where(a => a.ID_Estudiante == alerta.ID_Estudiante && a.TipoAlerta == alerta.TipoAlerta && a.DescripcionAlerta == alerta.DescripcionAlerta).FirstOrDefault();
                        if (alertaExistente == null)
                        {
                            // If Alerta doesn't exist, create a new one
                            _db.Alertas.Add(alerta);
                            _db.SaveChanges();
                        }
                    }

                }
                // Recorrer todos los estudiantes en busca de los que tengan un % de Asistencia menor a 0.60
                foreach (var resultado in resultados)
                {
                    var asistencia = resultado.AsistenciaPorcentaje;
                    decimal AsistenciaPermitida = 60.00m;
                    if (asistencia < AsistenciaPermitida)
                    {
                        // Get estudiante
                        var estudiante = _db.Estudiantes.Find(resultado.ID_Estudiante);
                        // Si el estudiante tiene un % de Asistencia menor a 0.60, crear un nuevo Alerta
                        var alerta = new Alerta
                        {
                            ID_Estudiante = resultado.ID_Estudiante,
                            FechaAlerta = DateTime.Now,
                            TipoAlerta = "Asistencia",
                            DescripcionAlerta = "El estudiante " + estudiante.NombreCompleto + " tiene un % de Asistencia menor a 0.60",
                            Mostrar = 1
                        };
                        //Review if current Alerta already exists
                        var alertaExistente = _db.Alertas.Where(a => a.ID_Estudiante == alerta.ID_Estudiante && a.TipoAlerta == alerta.TipoAlerta && a.DescripcionAlerta == alerta.DescripcionAlerta).FirstOrDefault();
                        if (alertaExistente == null)
                        {
                            // If Alerta doesn't exist, create a new one
                            _db.Alertas.Add(alerta);
                            _db.SaveChanges();
                        }
                    }
                    if (resultado.Calificacion < 50)
                    {
                        // Create Alerta
                        var estudiante = _db.Estudiantes.Find(resultado.ID_Estudiante);
                        var alerta = new Alerta
                        {
                            ID_Estudiante = resultado.ID_Estudiante,
                            FechaAlerta = DateTime.Now,
                            TipoAlerta = "Calificacion",
                            DescripcionAlerta = "El estudiante " + estudiante.NombreCompleto + " tiene una calificacion menor a 50 en la materia de " + resultado.Materia,
                            Mostrar = 1
                        };
                        //Review if current Alerta already exists
                        var alertaExistente = _db.Alertas.Where(a => a.ID_Estudiante == alerta.ID_Estudiante && a.TipoAlerta == alerta.TipoAlerta && a.DescripcionAlerta == alerta.DescripcionAlerta).FirstOrDefault();
                        if (alertaExistente == null)
                        {
                            // If Alerta doesn't exist, create a new one
                            _db.Alertas.Add(alerta);
                            _db.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Intervencion(int id)
        {
            try
            {
                // Get alerta by id
                var alerta = _db.Alertas.Find(id);
                // Modificar alerta
                alerta.Mostrar = 0;
                // Guardar cambios
                _db.Update(alerta);
                _db.SaveChanges();
                //Redireccionar a la vista Create del controlador Intervencion
                return RedirectToAction("Create", "Intervencion");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", "Intervencion");
            }

            
        }
    }
}
