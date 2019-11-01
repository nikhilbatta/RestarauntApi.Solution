using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestarauntApi.Services;
using RestarauntApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody]User user)
        {
            Console.WriteLine(user.Username);
            _userService.Create(user);
            return Ok(user);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
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