using IAfest.Data;
using IAfest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAfest.Controllers
{
    public class ComplementarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ComplementarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var complementos = _db.DatosComplementarios.ToList();
            return View(complementos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DatosComplementarios complementario)
        {
            if (ModelState.IsValid)
            {
                _db.Add(complementario);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var complementario = _db.DatosComplementarios.Find(id);
            if (complementario == null)
            {
                return NotFound();
            }
            return View(complementario);
        }

        [HttpPost]
        public IActionResult Edit(DatosComplementarios complementario)
        {
            if (ModelState.IsValid)
            {
                _db.Update(complementario);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var complementario = _db.DatosComplementarios.Find(id);
            if (complementario == null)
            {
                return NotFound();
            }
            _db.Remove(complementario);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
