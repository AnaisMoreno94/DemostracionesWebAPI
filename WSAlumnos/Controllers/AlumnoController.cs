using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WSAlumnos.Models;

namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private List<Alumno> Listado() 
        {
            List<Alumno> alumnos = new List<Alumno>() 
            {
                new Alumno() {Apellido = "Perez", Nombre = "Gonzalo", Id = 1 },
                new Alumno() {Apellido = "Ramirez", Nombre = "Ana", Id = 2 },
                new Alumno() {Apellido = "Goznzalez", Nombre = "Maria", Id = 3 }

            };
            return alumnos;
        }

        //GET api/Alumno
        [HttpGet]
        public IEnumerable<Alumno> Get() 
        { 
            return Listado();
        }

        //GET api/Alumno/id

        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById( int id)
        {
            Alumno alumno = (from a in Listado()
                         where a.Id == id
                         select a).SingleOrDefault();
            return alumno;
        }
    }
}
