using RestarauntApi.Models;
using RestarauntApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RestarauntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestarauntController : ControllerBase
    {
        private RestarauntApiContext _db;
        public RestarauntController(RestarauntApiContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaraunt>> Get(string restname, string location)
        {
            var query = _db.Restraunts.Include(r => r.Reviews).AsQueryable();
            if(restname != null)
            {
                query = query.Where(r => r.Name == restname);
            }
            if(location != null)
            {
                query = query.Where(r => r.Location == location);
            }
            return query.ToList();
        }
        [HttpPost]
        public void Post([FromBody] Restaraunt newRestaraunt)
        {
            _db.Restraunts.Add(newRestaraunt);
            _db.SaveChanges();
        }
        // get restaraunt by specific id
        [HttpGet("{restarauntID}")]
        public ActionResult<Restaraunt> Get(int restarauntID)
        {
            return _db.Restraunts.FirstOrDefault(r => r.Id == restarauntID);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Restaraunt updatedRestaraunt)
        {
            updatedRestaraunt.Id = id;
            _db.Entry(updatedRestaraunt).State = EntityState.Modified;
            _db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Restaraunt restarauntToDelete = _db.Restraunts.FirstOrDefault(r => r.Id == id);
            _db.Restraunts.Remove(restarauntToDelete);
            _db.SaveChanges();
        }
    }
}