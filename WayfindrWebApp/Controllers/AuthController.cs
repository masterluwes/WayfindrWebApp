using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using WayfindrWebApp.Models;
using WayfindrWebApp.Data;

namespace WayfindrWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register(User user, string ConfirmPassword)
        {
            if (user.PasswordHash != ConfirmPassword)
            {
                ModelState.AddModelError("PasswordHash", "Passwords do not match.");
                return View(user);
            }

            // Save user to database
            _context.Users.Add(user);
            _context.SaveChanges();

            // Store session
            HttpContext.Session.SetInt32("UserId", user.UserId);

            return RedirectToAction("Profile", "User");
        }
    }
}
