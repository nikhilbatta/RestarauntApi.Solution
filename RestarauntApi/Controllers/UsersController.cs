using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestarauntApi.Services;
using RestarauntApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly RestarauntApiContext _db;

        public UsersController(IUserService userService, RestarauntApiContext db)
        {
            _userService = userService;
            _db = db;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            // foreach(Review review in _db.Users)
            // {
            //     Console.WriteLine(review.Body);
            // }
            var users = _db.Users.Include(u => u.UserReviews).AsQueryable();
            // var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            Console.WriteLine(userParam.Username);
            Console.WriteLine(userParam.Password);
            var user = _userService.Authenticate(userParam.Username, userParam.Password);
            System.Console.WriteLine();

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

    }
}