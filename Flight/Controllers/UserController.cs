using Flight.Data;
using Flight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
		public IActionResult Index(string message)
        {
			ViewBag.message = message;
            return View();
        }

        public IActionResult Sign_up()
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
            ViewBag.schedule = db.Schedules.Include(z => z.Flight).Include(x => x.Routess).ToList();
			return View();
		}

		public IActionResult about() {

			ViewBag.choose = db.Chooses.ToList();
			ViewBag.about = db.Abouts.ToList();
			return View();
		
		}
		
		public IActionResult contacts()
		{
			return View();
		}

		public IActionResult show_resutl_flight(Routess b)
		{
			var data = db.Routesses.FirstOrDefault(s => s.RFrom == b.RFrom && s.RTo == b.RTo);
			if(data == null)
			{
				return RedirectToAction("Index" , new { message = "Flight is not Match" });
			}
			else
			{
                var she = db.Schedules.Include(s => s.Routess).Include(f => f.Flight).Where(s => s.RoutessId == data.RId).ToList();
                return View(she);

            }
			
			//if(data != null) { 

			
			//}
			//else
			//{
			//	return Content("Error");
			//}
			return View();
		}

		public IActionResult show_special_sets(int? id)
		{
			var getdata = db.Schedules.FirstOrDefault(s => s.SheduleId == id);
			var fetchdata = db.SpecialSets.Include(t => t.Routess).Include(f => f.Flight).Where(t => t.RoutessId == getdata.RoutessId).ToList();
			return View(fetchdata);
		}

		public IActionResult full_special_sets()
		{
			var special = db.SpecialSets.Include(s => s.Routess).Include(f => f.Flight).ToList();
			return View(special);
		}
        public ActionResult GetCategories()
        {
            var Categories = db.Routesses.ToList();
            return PartialView("user_layout", Categories);
        }

    }
}
