using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DBLibrosContext context;

        public LibroController( DBLibrosContext context ) 
        {
            this.context = context;
        }

        //GET Traer todos los libros
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }

        //GET Trear uno por ID
        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            Libro libro
                = (from a in context.Libros
                           where a.Id == id
                           select a).SingleOrDefault();
            return libro;
        }

        //GET Traer todos los libros por Autor ID
        [HttpGet("libros_autor/{id}")]
        public ActionResult<List<Libro>> GetByAutor(int id)
        {
            var libros = (from l in context.Libros
                         where l.AutorId == id
                         select l).ToList();

            return libros;
        }


        //POST Insertar Libros retornar ok
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        //PUT Modificar Libro pasdo id y modelo retornar un NoContent()
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }
            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }

        //DELETE Eliminar libro, retornar libro eliminado

        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from a in context.Libros
                         where a.Id == id
                         select a).SingleOrDefault();
            if (libro == null)
            {
                return NotFound();
            }
            context.Libros.Remove(libro);
            context.SaveChanges();

            return libro;
        }



    }
}
