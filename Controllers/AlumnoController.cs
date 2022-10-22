using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class AlumnoController : Controller
    {
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{alumnoId?}")]
        public IActionResult Index(string alumnoId)
        {
            
            if (!string.IsNullOrWhiteSpace(alumnoId))
            {
                Alumno alumno = (from asig in _context.Alumnos where asig.Id == alumnoId select asig)
                    .SingleOrDefault();

                if (alumno!=null)
                {
                    return View("Index",alumno);    
                }
                
            }
            IEnumerable<Alumno> listAlumno = _context.Alumnos;
            return View("MultiAlumno", listAlumno);
            
        }

        public IActionResult MultiAlumno()
        {
            IEnumerable<Alumno> listAlumno = _context.Alumnos;

            return View("MultiAlumno", listAlumno);
        }

        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            List<Alumno> listaAlumnos = (from n1 in nombre1
                from n2 in nombre2
                from a1 in apellido1
                select new Alumno
                {
                    Nombre = $"{n1} {n2} {a1}",
                    Id = Guid.NewGuid().ToString()
                }).ToList();

            return listaAlumnos;
        }
        
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}