using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            // Escuela escuela = new Escuela();
            // escuela.AñoDeCreación = 2005;
            // escuela.UniqueId = Guid.NewGuid().ToString();
            // escuela.Nombre = "Platzi School";
            // escuela.Ciudad = "Sabaneta";
            // escuela.Pais = "Colombia";
            // escuela.Dirección = "Avenida Siempre Viva";
            // escuela.TipoEscuela = TiposEscuela.Secundaria;

            Escuela escuela = _context.Escuelas.FirstOrDefault();
            ViewBag.CosaDinamica = "La monja";

            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}