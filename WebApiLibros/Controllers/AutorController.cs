using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //inyeccion de dependencia ---- Inicia
        //propiedad
        private readonly DBLibrosContext context;

        //constructor
        public AutorController(DBLibrosContext context) 
        {
            this.context = context;
        }
        //inyeccion de dependencia ---- Fin

        //GetALl GET api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();
        }


        //GetById GET api/autor/id

        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id) 
        {
            Autor autor = (from a in context.Autores
                           where a.Id == id
                           select a).SingleOrDefault();
            return autor;
        }

        //GET api/autor/edad
        [HttpGet("listado/{edad}")]
        public ActionResult<IEnumerable<Autor>> Get(int edad) 
        {
            List<Autor> autores = (from a in context.Autores
                                     where a.Edad == edad
                                     select a).ToList();
            return autores;

        }

        //Post api/autor
        [HttpPost]
        public ActionResult Post(Autor autor) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);    
            }
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE api/autor/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor) 
        {
            if (id != autor.Id) 
            {
                return BadRequest();
            }
            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        //DELETE api/autor/id
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id) 
        {
            var autor = (from a in context.Autores
                         where a.Id == id
                         select a).SingleOrDefault();
            if (autor == null) 
            {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();

            return autor;
        }
    

        
    }
}
