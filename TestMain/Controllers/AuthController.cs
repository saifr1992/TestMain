using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMain.DatabaseContext;
using TestMain.Entities;
using TestMain.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMain.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly MyDatabaseContext _databaseContext;

        public AuthController(MyDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet("Signup", Name = "Auth-Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost("Signup", Name = "Auth-Signup")]
        public async Task<IActionResult> Signup(SignupRequest request)
        {
            bool hasEmail = await _databaseContext.Users.AnyAsync(s => s.Email.Equals(request.Email));
            if (hasEmail)
            {
                Console.WriteLine("Email already exist.");
                return View();
            }

            UserEntity user = new UserEntity
            {
                CreatedOn = DateTime.UtcNow,
                Email =request.Email,
                FullName = request.FullName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber
            };
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return RedirectToRoute("Home-Index");
        }
    }
}

