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
    public class ReviewController : ControllerBase
    {
        private RestarauntApiContext _db;
        public ReviewController(RestarauntApiContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(int restarauntId)
        {
            var query = _db.Reviews.AsQueryable();
            if(restarauntId != 0)
            {
                query = query.Where(r => r.Id == restarauntId);
            }
            return query.ToList();
        }
    }
}