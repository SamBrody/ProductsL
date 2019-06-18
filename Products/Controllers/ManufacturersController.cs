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
using Products.Models.PostRM;

namespace Products.Controllers
{
    public class ManufacturersController : ApiController
    {
        ProductsContext db = new ProductsContext();

        // GET: api/Manufacturers
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<ICollection<ManufacturerRM>>(db.Manufacturers));
        }

        // GET: api/Manufacturers/5
        public IHttpActionResult Get(int id)
        {
            var manufacturer = db.Manufacturers.Find(id);

            if (manufacturer == null)
            {
                return NotFound();
            }
            else
            {
                var manufacturerVM = Mapper.Map<ManufacturerRM>(manufacturer);
                return Ok(manufacturerVM);
            }
        }

        // POST: api/Manufacturers
        public IHttpActionResult Post([FromBody]ManufacturerPostRM manufacturer)
        {
            var entity = Mapper.Map<Manufacturer>(manufacturer);
            db.Add(entity);
            db.SaveChanges();
            return Ok(Mapper.Map<ManufacturerRM>(entity));
        }

        // PUT: api/Manufacturers/5
        public IHttpActionResult Put(int id, [FromBody]ManufacturerPostRM manufacturer)
        {
            if (id <= 0 || manufacturer == null) return BadRequest("Bad transaction");
            {
                var entity = Mapper.Map<Manufacturer>(manufacturer);
                entity.Id = id;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(Mapper.Map<ManufacturerRM>(entity));
            }
        }

        // DELETE: api/Manufacturers/5
        public IHttpActionResult Delete(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer != null)
            {
                db.Manufacturers.Remove(manufacturer);
                db.SaveChanges();
                return Ok(Mapper.Map<ManufacturerRM>(manufacturer));
            }
            return NotFound();
        }
    }
}
