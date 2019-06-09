using Microsoft.EntityFrameworkCore;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Products.Controllers
{
    public class CurrenciesController : ApiController
    {
        ProductsContext db = new ProductsContext();
        // GET: api/Currency
        public IEnumerable<Currency> Get() 
        {
            return db.Currencies;
        }

        // GET: api/Currency/5
        public IHttpActionResult Get(int id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency==null)
            {
                return NotFound();
            }
            return Ok(currency);
        }

        // POST: api/Currency
        public void Post([FromBody]Currency currency)
        {            
            db.Currencies.Add(currency);
            db.SaveChanges();
        }

        // PUT: api/Currency/5
        public HttpResponseMessage Put(int id, [FromBody]Currency currency)
        {
            if (id == currency.Id)
            {
                db.Entry(currency).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // DELETE: api/Currency/5
        public HttpResponseMessage Delete(int id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency != null)
            {
                db.Currencies.Remove(currency);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
