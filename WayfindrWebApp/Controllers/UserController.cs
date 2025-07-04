using Microsoft.AspNetCore.Mvc;
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

        // ✅ PLACE THIS METHOD HERE (GET: /User/Profile/{id})
        public IActionResult Profile(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();

            return View(user); // will load Views/User/Profile.cshtml with the user data
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
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

                return RedirectToAction("Profile", new { id = user.UserId });
            }

            return View("Profile", user);
        }
    }
}
