using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.Models;
using Products.Models.PostRM;
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

        // GET: api/Currencies
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<ICollection<CurrencyRM>>(db.Currencies));
        }

        // GET: api/Currencies/5
        public IHttpActionResult Get(int id)
        {
            var currency = db.Currencies.Find(id);

            if (currency == null)
            {
                return NotFound();
            }
            else
            {
                var currencyVM = Mapper.Map<CurrencyRM>(currency);
                return Ok(currencyVM);
            }
        }

        // POST: api/Currencies
        public IHttpActionResult Post([FromBody]CurrencyPostRM currency)
        {
            var currencyVM = Mapper.Map<Currency>(currency);
            return Ok(Mapper.Map<CurrencyRM>(currencyVM));
        }

        // PUT: api/Currencies/5
        public IHttpActionResult Put(int id, [FromBody]Currency currency)
        {
            if (id == currency.Id)
            {                
                db.Entry(currency).State = EntityState.Modified;
                if (currency.Id <= 0) return BadRequest("Введеный Id меньше или равен 0!");
                db.SaveChanges();
                return Ok(Mapper.Map<CurrencyRM>(currency));
            }
            return NotFound();
        }

        // DELETE: api/Currencies/5
        public IHttpActionResult Delete(int id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency != null)
            {
                db.Currencies.Remove(currency);
                db.SaveChanges();
                return Ok(Mapper.Map<CurrencyRM>(currency));
            }
            return NotFound();
        }
    }
}
