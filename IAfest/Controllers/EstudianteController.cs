using IAfest.Data;
using IAfest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAfest.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EstudianteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var estudiantes = _db.Estudiantes.ToList();
            return View(estudiantes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _db.Estudiantes.Add(estudiante);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var estudiante = _db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _db.Estudiantes.Update(estudiante);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        public IActionResult Delete(int id)
        {
            var estudiante = _db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            // For every row in Asistencia table with the ID_Estudiante of the student to be deleted, delete the row
            var asistencias = _db.RegistrosAsistencia.Where(a => a.ID_Estudiante == estudiante.ID_Estudiante);
            foreach (var asistencia in asistencias)
            {
                _db.RegistrosAsistencia.Remove(asistencia);
            }
            _db.SaveChanges();
            // For every row in Alerta table with the ID_Estudiante of the student to be deleted, delete the row
            var alertas = _db.Alertas.Where(a => a.ID_Estudiante == estudiante.ID_Estudiante);
            foreach (var alertaa in alertas)
            {
                _db.Alertas.Remove(alertaa);
            }
            _db.SaveChanges();
            // For every row in Calificacion table with the ID_Estudiante of the student to be deleted, delete the row
            var calificaciones = _db.ResultadosAcademicos.Where(a => a.ID_Estudiante == estudiante.ID_Estudiante);
            foreach (var calificacion in calificaciones)
            {
                _db.ResultadosAcademicos.Remove(calificacion);
            }
            _db.SaveChanges();
            // For every row in Comportamiento table with the ID_Estudiante of the student to be deleted, delete the row
            var comportamientos = _db.DatosComplementarios.Where(a => a.ID_Estudiante == estudiante.ID_Estudiante);
            foreach (var datos in comportamientos)
            {
                _db.DatosComplementarios.Remove(datos);
            }
            _db.SaveChanges();
            // For every row in Intervenciones table with the ID_Estudiante of the student to be deleted, delete the row
            var intervenciones = _db.HistorialIntervenciones.Where(a => a.ID_Estudiante == estudiante.ID_Estudiante);
            foreach (var intervencion in intervenciones)
            {
                _db.HistorialIntervenciones.Remove(intervencion);
            }
            _db.SaveChanges();
            //Create new model Alerta
            var alerta = new Alerta
            {
                ID_Estudiante = estudiante.ID_Estudiante,
                FechaAlerta = DateTime.Now,
                TipoAlerta = "Académica",
                DescripcionAlerta = "El estudiante " + estudiante.NombreCompleto + " ha sido eliminado del sistema",
                Mostrar = 1
            };
            _db.Alertas.Add(alerta);
            _db.SaveChanges();

            _db.Estudiantes.Remove(estudiante);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
