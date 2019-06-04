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
    public class CurrencyController : ApiController
    {
        ProductsContext db = new ProductsContext();
        // GET: api/Currency
        public IEnumerable<Currency> Get()
        {
            return db.Currencies;
        }

        // GET: api/Currency/5
        public Currency Get(int id)
        {
            return (db.Currencies.Find(id));
        }

        // POST: api/Currency
        public void Post([FromBody]Currency currency)
        {
            db.Currencies.Add(currency);
            db.SaveChanges();
        }

        // PUT: api/Currency/5
        public void Put(int id, [FromBody]Currency currency)
        {
            if (id == currency.Id)
            {
                db.Entry(currency).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE: api/Currency/5
        public void Delete(int id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency != null)
            {
                db.Currencies.Remove(currency);
                db.SaveChanges();
            }
        }
    }
}
