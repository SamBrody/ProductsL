using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Products.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Products.Controllers
{
    public class ProducersController : ApiController
    {
        ProductsContext db = new ProductsContext();
        // GET: api/Producer
        public IEnumerable<Producer> Get()
        {
            return db.Producers;
        }

        // GET: api/Producer/5
        public IHttpActionResult Get(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return NotFound();
            }
            return Ok(producer);
        }

        // POST: api/Producer
        public void Post([FromBody]Producer producer)
        {
            db.Producers.Add(producer);
            db.SaveChanges();
        }

        // PUT: api/Producer/5
        public HttpResponseMessage Put(int id, [FromBody]Producer producer)
        {
            if (id == producer.Id)
            {
               db.Entry(producer).State = EntityState.Modified;            
               db.SaveChanges();
               return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // DELETE: api/Producer/5
        public HttpResponseMessage Delete(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer != null)
            {
                db.Producers.Remove(producer);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
