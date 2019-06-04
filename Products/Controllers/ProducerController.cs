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
    public class ProducerController : ApiController
    {
        ProductsContext db = new ProductsContext();
        // GET: api/Producer
        public IEnumerable<Producer> Get()
        {
            return db.Producers;
        }

        // GET: api/Producer/5
        public Producer Get(int id)
        {
            return (db.Producers.Find(id));
        }

        // POST: api/Producer
        public void Post([FromBody]Producer producer)
        {
            db.Producers.Add(producer);
            db.SaveChanges();
        }

        // PUT: api/Producer/5
        public void Put(int id, [FromBody]Producer producer)
        {
            if (id == producer.Id)
            {
               db.Entry(producer).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE: api/Producer/5
        public void Delete(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer != null)
            {
                db.Producers.Remove(producer);
                db.SaveChanges();
            }
        }
    }
}
