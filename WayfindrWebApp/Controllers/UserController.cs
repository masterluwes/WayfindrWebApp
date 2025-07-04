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

        public IActionResult Profile(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            if (ModelState.IsValid)
            {
                user.LastModified = DateTime.Now;
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Profile", new { id = user.UserId });
            }

            return View("Profile", user);
        }
    }
}
