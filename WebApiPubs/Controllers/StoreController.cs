using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiPubs.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly pubsContext context;

        public StoreController(pubsContext context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Store>> Get()
        {
            return context.Stores.ToList();
        }

        //GetByID
        [HttpGet("{id}")]
        public ActionResult<Store> GetById(string id)
        {
            Store store = (from s in context.Stores
                                   where s.StorId == id
                                   select s).SingleOrDefault();
            return store;
        }

        //GETByName
        [HttpGet("name/{name}")]
        public ActionResult<Store> GetByName(string name) 
        {
            Store store = (from s in context.Stores
                           where s.StorName == name
                           select s).SingleOrDefault();
            return store;
        }

        //GETByZip
        [HttpGet("zip/{zip}")]
        public ActionResult<IEnumerable<Store>> GetByZip(string zip)
        {
            var stores = (from s in context.Stores
                          where s.Zip == zip
                          select s).ToList();
            return stores;

        }

        //GetByCity
        [HttpGet("city/{city}")]
        public ActionResult<IEnumerable<Store>> GetByCity(string city)
        {
            var stores = (from s in context.Stores
                          where s.City == city
                          select s).ToList();

            return stores;

        }

        //GetByCityState
        [HttpGet("citystate/{city}/{state}")]
        public ActionResult<IEnumerable<Store>> GetByCityState(string city ,string state) 
        {
            List<Store> stores = (from s in context.Stores
                           where s.City == city && s.State == state
                           select s).ToList();
            
            return stores;

        }


        //PUT
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Store store)
        {
            if (id != store.StorId)
            {
                return BadRequest();
            }
            context.Entry(store).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Stores.Add(store);
            context.SaveChanges();

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Store> Delete(string id)
        {
            var store = (from s in context.Stores
                             where s.StorId == id
                             select s).SingleOrDefault();

            if (store == null)
            {
                return NotFound();
            }
            context.Stores.Remove(store);
            context.SaveChanges();

            return store;
        }
    }
}
