﻿using IAfest.Data;
using IAfest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAfest.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ResultadoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var resultados = _db.ResultadosAcademicos.ToList();
            return View(resultados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ResultadoAcademico resultado)
        {
            if (ModelState.IsValid)
            {
                _db.ResultadosAcademicos.Add(resultado);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var resultado = _db.ResultadosAcademicos.Find(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }

        [HttpPost]
        public IActionResult Edit(ResultadoAcademico resultado)
        {
            if (ModelState.IsValid)
            {
                _db.ResultadosAcademicos.Update(resultado);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultado);
        }

        public IActionResult Delete(int id)
        {
            var resultado = _db.ResultadosAcademicos.Find(id);
            if (resultado == null)
            {
                return NotFound();
            }
            _db.ResultadosAcademicos.Remove(resultado);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
