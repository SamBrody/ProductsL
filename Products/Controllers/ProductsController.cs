using Microsoft.EntityFrameworkCore;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace Products.Controllers
{
    public class ProductsController : ApiController
    {
        ProductsContext db = new ProductsContext();

        //Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductVM>());

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return db.Products;
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return (db.Products.Find(id));
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                db.Entry(product).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
