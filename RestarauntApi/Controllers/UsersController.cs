using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestarauntApi.Services;
using RestarauntApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using RestarauntApi.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;


namespace MessageBoard.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly RestarauntApiContext _db;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService userService, RestarauntApiContext db, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _db = db;
            _appSettings = appSettings.Value;
        }
        [HttpPost("token")]
        public IActionResult Token()
        {
            //string tokenString = "test";
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //admin:pass
                var usernameAndPass = usernameAndPassenc.Split(":");
                //check in DB username and pass exist

                if (usernameAndPass[0] == "Admin" && usernameAndPass[1] == "pass")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]) };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                         issuer: "http://localhost:4000",
                         audience: "http://localhost:4000",
                         expires: DateTime.Now.AddMinutes(5),
                         claims: claimsdata,
                         signingCredentials: signInCred
                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenString);
                }
                return null;
            }
            return null;
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