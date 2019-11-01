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
        public ActionResult<IEnumerable<Restaraunt>> Get()
        {
            return _db.Restraunts.ToList();
        }
        [HttpPost]
        public void Post([FromBody] Restaraunt newRestaraunt)
        {
            _db.Restraunts.Add(newRestaraunt);
            _db.SaveChanges();
        }
    }
}