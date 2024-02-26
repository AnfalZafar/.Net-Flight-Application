using Flight.Data;
using Flight.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Controllers

{
    public class UserController : Controller
    {
		private readonly ILogger<UserController> _logger;
		private readonly flightContext db;

		public UserController(flightContext a)
		{
			this.db = a;
		}
		public IActionResult Index()
        {
            return View();
        }

		public IActionResult signup_pro(User b)
		{
			b.RoleId = 1;
			db.Add(b);
			db.SaveChanges();
			return RedirectToAction("Login" , "Home");
		}

		public IActionResult packages()
		{
			return View();
		}

		public IActionResult rutes() { 
		
			return View();
		
		}

		public IActionResult contacts()
		{
			return View();
		}

	}
}
