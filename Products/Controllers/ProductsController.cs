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
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/Products
        public IHttpActionResult Get()
        {
            return Ok(_mapper.Map<ProductVM>(db.Products));
            //return db.Products.Include(prod=>prod.Producer).Include(cur => cur.Currency);
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            var product=db.Products.Find(id);
            var productVM = _mapper.Map<ProductVM>(product);
            if (productVM == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(productVM); 
            }            
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {           
            db.Products.Add(product);
            db.SaveChanges();
        }

        // PUT: api/Products/5
        public HttpResponseMessage Put(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // DELETE: api/Products/5
        public HttpResponseMessage Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }

}
