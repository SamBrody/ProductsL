using Microsoft.EntityFrameworkCore;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Web.Mvc;
using Products;

namespace Products.Controllers
{
    public class ProductsController : ApiController
    {
        ProductsContext db = new ProductsContext();  

        // GET: api/Products
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<ICollection<ProductRM>>(db.Products));          
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            var product=db.Products.Find(id);
            
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var productVM = Mapper.Map<ProductRM>(product);
                return Ok(productVM); 
            }            
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (product == null)
                return BadRequest();
            else
            {
                db.Products.Add(product);
                if (product.Id <= 0) return BadRequest("Введеный Id меньше или равен 0!");                
                db.SaveChanges();
                return Ok(Mapper.Map<ProductRM>(product));
            }                        
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                db.Entry(product).State = EntityState.Modified;
                if (product.Id <= 0) return BadRequest("Введеный Id меньше или равен 0!");
                db.SaveChanges();
                return Ok(Mapper.Map<ProductRM>(product));
            }
            return NotFound();
        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return Ok(Mapper.Map<ProductRM>(product));
            }
            return NotFound();
        }
    }

}
