
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlunoCurso.Context;
using AlunoCurso.Models;

namespace AlunoCurso.Controllers
{
    public class CursoController : Controller
    {
        private readonly Contexto _contexto = new Contexto();

        // GET: Curso
        public ActionResult Index()
        {
            var cursos = _contexto.Cursos.ToList();
            return View(cursos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cursos.Add(cursoModel);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(cursoModel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CursoModel cursoModel = _contexto.Cursos.Find(id);

            if (cursoModel == null)
            {
                return HttpNotFound();
            }

            return View(cursoModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CursoModel cursoModel = _contexto.Cursos.Find(id);

            if (cursoModel == null)
            {
                return HttpNotFound();
            }

            return View(cursoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(cursoModel).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(cursoModel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CursoModel cursoModel = _contexto.Cursos.Find(id);

            if(cursoModel == null)
            {
                return HttpNotFound();
            }

            return View(cursoModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoModel cursoModel = _contexto.Cursos.Find(id);
            _contexto.Cursos.Remove(cursoModel);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}