using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class CursoController : Controller
    {
        [Route("Curso/Index")]
        [Route("Curso/{cursoId?}")]
        [Route("Curso/Index/{cursoId?}")]
        public IActionResult Index(string cursoId)
        {
            
            if (!string.IsNullOrWhiteSpace(cursoId))
            {
                Curso curso = (from cur in _context.Cursos where cur.Id == cursoId select cur)
                    .SingleOrDefault();

                if (curso!=null)
                {
                    return View("Index",curso);    
                }
                
            }
            IEnumerable<Curso> listCurso = _context.Cursos;
            return View("MultiCurso", listCurso);
            
        }

        public IActionResult MultiCurso()
        {
            IEnumerable<Curso> listCurso = _context.Cursos;

            return View("MultiCurso", listCurso);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View(curso);
            }
            Escuela escuela = _context.Escuelas.FirstOrDefault();
            
            curso.Id = Guid.NewGuid().ToString();
            curso.EscuelaId = escuela.Id;
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return View("index",curso);
        }
        
        public IActionResult Edit(Curso curso)
        {
            return View("Edit",curso);
        }
        
        [HttpPost]
        public IActionResult Update(Curso curso,string CursoId)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit",curso);
            }
            Escuela escuela = _context.Escuelas.FirstOrDefault();
            
            
            
            curso.EscuelaId = escuela.Id;
            _context.Cursos.Update(curso);
            _context.SaveChanges();
            return MultiCurso();
        }

        public IActionResult Delete(Curso curso)
        {
            
            _context.Cursos.Remove(curso);
            _context.SaveChanges();
            return MultiCurso();
        }
        
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}