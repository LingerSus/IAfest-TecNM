using IAfest.Data;
using IAfest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAfest.Controllers
{
    public class IntervencionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IntervencionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var listaIntervenciones = _db.HistorialIntervenciones.ToList();
            return View(listaIntervenciones);
        }

        public IActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Intervencion objIntervencion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.HistorialIntervenciones.Add(objIntervencion);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(objIntervencion);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var objIntervencion = _db.HistorialIntervenciones.Find(id);
                if (objIntervencion == null)
                {
                    return NotFound();
                }
                return View(objIntervencion);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Intervencion objIntervencion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.HistorialIntervenciones.Update(objIntervencion);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(objIntervencion);
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
                var resultado = _db.HistorialIntervenciones.Find(id);
                if (resultado == null)
                {
                    return NotFound();
                }
                _db.HistorialIntervenciones.Remove(resultado);
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
