using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace platzi_asp_net_core.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Evaluación> Evaluaciones { get; set; }

        public DbSet<Alumno> Alumnos { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Escuela escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Sabaneta";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avenida Siempre Viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            
            
            //Cargar Cursos de la escuela
            List<Curso> cursos = CargarCursos(escuela);
            
            //X cada curso cargar asignaturas
            List<Asignatura> asignaturas = CargarAsignaturas(cursos);
            
            //x cada curso cargar alumnos
            List<Alumno> alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            
        }
        
       
        
        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(), 
                    Nombre = "11-A",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(), 
                    Nombre = "11-B",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "11-C",
                    Jornada = TiposJornada.Tarde,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "11-D",
                    Jornada = TiposJornada.Tarde,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(), 
                    Nombre = "11-E",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
            };

        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            List <Asignatura> listaCompleta = new List<Asignatura>();
            foreach (Curso curso in cursos)
            {
                List<Asignatura> tmpListAsignatura = new List<Asignatura>()
                {
                    new Asignatura
                    {
                        Nombre = "Matemáticas",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id
                    },
                    new Asignatura
                    {
                        Nombre = "Educación Física",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id
                    },
                    new Asignatura
                    {
                        Nombre = "Español",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id
                    },
                    new Asignatura
                    {
                        Nombre = "Ciencias Naturales",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id
                    }
                };
                listaCompleta.AddRange(tmpListAsignatura);
                // curso.Asignaturas = tmpListAsignatura;
            
            }

            return listaCompleta;
        }

        private static List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            Random rnd = new Random();

            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                List<Alumno> tmpList = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmpList);
            }

            return listaAlumnos;
        }
        
        private static List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
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
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id
                }).Take(cantidad).ToList();

            return listaAlumnos;
        }
    }
    
    
}