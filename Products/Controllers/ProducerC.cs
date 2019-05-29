using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Products.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Products.Controllers
{
    public class ProducerC : ApiController
    {
        ProductsContext db = new ProductsContext();
        
        public IEnumerable<Producer> Get()
        {
            //return new string[] { "value1", "value2" };
            return db.Producer_;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
