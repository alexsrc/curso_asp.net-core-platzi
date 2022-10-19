using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            Asignatura asignatura = new Asignatura
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = "Programación"
            };

            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {

            List<Asignatura> listAsignatura = new List<Asignatura>()
            {
                new Asignatura
                {
                    Nombre = "Matemáticas",
                    Id = Guid.NewGuid().ToString()
                },
                new Asignatura
                {
                    Nombre = "Educación Física",
                    Id = Guid.NewGuid().ToString()
                },
                new Asignatura
                {
                    Nombre = "Español",
                    Id = Guid.NewGuid().ToString()
                },
                new Asignatura
                {
                    Nombre = "Ciencias Naturales",
                    Id = Guid.NewGuid().ToString()
                }
            };
            
            return View("MultiAsignatura",listAsignatura);
        }
    }
}