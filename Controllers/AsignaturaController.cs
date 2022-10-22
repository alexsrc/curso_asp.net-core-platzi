using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {
        // public IActionResult Index()
        // {
        //     Asignatura asignatura = _context.Asignaturas.FirstOrDefault();
        //
        //     return View(asignatura);
        // }

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId?}")]
        public IActionResult Index(string asignaturaId)
        {
            
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                Asignatura asignatura = (from asig in _context.Asignaturas where asig.Id == asignaturaId select asig)
                    .SingleOrDefault();

                if (asignatura!=null)
                {
                    return View("Index",asignatura);    
                }
                
            }
            IEnumerable<Asignatura> listAsignatura = _context.Asignaturas;
            return View("MultiAsignatura", listAsignatura);
            
        }

        public IActionResult MultiAsignatura()
        {
            IEnumerable<Asignatura> listAsignatura = _context.Asignaturas;

            return View("MultiAsignatura", listAsignatura);
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}