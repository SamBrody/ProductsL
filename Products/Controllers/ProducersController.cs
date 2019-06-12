using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Products.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Products.Controllers
{
    public class ProducersController : ApiController
    {
        ProductsContext db = new ProductsContext();

        // GET: api/Producers
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<ICollection<ProducerRM>>(db.Producers));
        }

        // GET: api/Producers/5
        public IHttpActionResult Get(int id)
        {
            var producer = db.Producers.Find(id);

            if (producer == null)
            {
                return NotFound();
            }
            else
            {
                var producerVM = Mapper.Map<ProducerRM>(producer);
                return Ok(producerVM);
            }
        }

        // POST: api/Producers
        public IHttpActionResult Post([FromBody]Producer producer)
        {
            if (producer == null)
                return BadRequest();
            else
            {                
                db.Producers.Add(producer);
                if (producer.Id <= 0) return BadRequest("Введеный Id меньше или равен 0!");
                db.SaveChanges();
                return Ok(Mapper.Map<ProducerRM>(producer));
            }
        }

        // PUT: api/Producers/5
        public IHttpActionResult Put(int id, [FromBody]Producer producer)
        {
            if (id == producer.Id)
            {                
                db.Entry(producer).State = EntityState.Modified;
                if (producer.Id <= 0) return BadRequest("Введеный Id меньше или равен 0!");
                db.SaveChanges();
                return Ok(Mapper.Map<ProducerRM>(producer));
            }
            return NotFound();
        }

        // DELETE: api/Producers/5
        public IHttpActionResult Delete(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer != null)
            {
                db.Producers.Remove(producer);
                db.SaveChanges();
                return Ok(Mapper.Map<ProducerRM>(producer));
            }
            return NotFound();
        }
    }
}
