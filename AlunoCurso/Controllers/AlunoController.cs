using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlunoCurso.Context;

namespace AlunoCurso.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Contexto _contexto = new Contexto();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = _contexto.Alunos.Include(a => a.Curso);
            return View(alunos.ToList());
        }
    }
}