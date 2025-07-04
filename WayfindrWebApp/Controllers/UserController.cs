using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WayfindrWebApp.Data;
using WayfindrWebApp.Models;

namespace WayfindrWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /profile
        public IActionResult Profile()
        {
            // 🔑 Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth"); // or wherever your login is

            var user = _context.Users.FirstOrDefault(u => u.UserId == userId.Value);
            if (user == null)
                return NotFound();

            return View("~/Views/Home/Profile.cshtml", user); // loads Views/User/Profile.cshtml
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth");

            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.UserId == userId.Value);
                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;
                    existingUser.Gender = user.Gender;
                    existingUser.ContactNumber = user.ContactNumber;
                    existingUser.Username = user.Username;
                    existingUser.LastModified = DateTime.Now;

                    if (!string.IsNullOrEmpty(user.PasswordHash))
                    {
                        existingUser.PasswordHash = user.PasswordHash;
                    }

                    _context.SaveChanges();
                    TempData["Message"] = "Profile updated successfully!";
                }

                return RedirectToAction("Profile");
            }

            return View("Profile", user);
        }
    }
}
