using IAfest.Data;
using IAfest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAfest.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AsistenciaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var asistencias = _db.RegistrosAsistencia.ToList();
            return View(asistencias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asistencia asistencia)
        {
            try
            {
                // Get the pass 3 records from the student in asistencia
                var asistencias = _db.RegistrosAsistencia.Where(x => x.ID_Estudiante == asistencia.ID_Estudiante).ToList();
                // If the last 3 have been "Tarde" create an alert
                if (asistencias.Count > 2 && asistencias[asistencias.Count - 1].EstadoAsistencia == "Ausente" && asistencias[asistencias.Count - 2].EstadoAsistencia == "Ausente" && asistencias[asistencias.Count - 3].EstadoAsistencia == "Ausente")
                {
                    // Get estudiante
                    var estudiante = _db.Estudiantes.Find(asistencia.ID_Estudiante);
                    var alerta = new Alerta
                    {
                        ID_Estudiante = asistencia.ID_Estudiante,
                        FechaAlerta = DateTime.Now,
                        TipoAlerta = "Asistencia",
                        DescripcionAlerta = "El estudiante " + estudiante.NombreCompleto + " ha llegado tarde 3 veces seguidas",
                        Mostrar = 1
                    };
                    _db.Alertas.Add(alerta);
                    _db.SaveChanges();
                }
                if (ModelState.IsValid)
                {
                    _db.RegistrosAsistencia.Add(asistencia);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Edit(int id)
        {
            var asistencia = _db.RegistrosAsistencia.Find(id);
            if (asistencia == null)
            {
                return NotFound();
            }
            return View(asistencia);
        }

        [HttpPost]
        public IActionResult Edit(Asistencia asistencia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.RegistrosAsistencia.Update(asistencia);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(asistencia);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var asistencia = _db.RegistrosAsistencia.Find(id);
                if (asistencia == null)
                {
                    return NotFound();
                }
                _db.RegistrosAsistencia.Remove(asistencia);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }


    }
}
