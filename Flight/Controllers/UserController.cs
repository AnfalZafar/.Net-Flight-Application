using Flight.Data;
using Flight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Globalization;

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

		public IActionResult packages()
		{
            ViewBag.schedule = db.Schedules.Include(z => z.Flight).Include(x => x.Routess).ToList();
			return View();
		}
		[HttpPost]
		public IActionResult add_to_cart()
		{
			if (!string.IsNullOrEmpty(Session_Model.UserId))
			{	
					string from = Request.Form["from"].ToString();
					string to = Request.Form["to"].ToString();
					string price = Request.Form["price"].ToString();
					string f_name = Request.Form["f_name"].ToString();
					string s_id = Request.Form["s_id"].ToString();

					string user_id = Session_Model.UserId;
					string qty = "1";
					int user = Int32.Parse(Session_Model.UserId);
					var user_detail = db.Users.FirstOrDefault(z => z.UsersId == user);
					string user_name = user_detail.UsersName.ToString();
					string user_email = user_detail.UsersEmail.ToString();


					bool cheakitem = false;
				   // this forlop runs according to the count of addlist
				for(var i = 0; i < add_list.List.Count; i++)
				{
					if (add_list.List[i].s_id.Equals(s_id))
					{
                        cheakitem = true;

                        TempData["data"] = JsonConvert.SerializeObject(add_list.List[i]);
                        return RedirectToAction(nameof(view_cart));
                        break;
                    }
					
				}			

					if (cheakitem == false)
					{
                    Add_to_cart cart = new Add_to_cart()
                    {
                        from = from,
                        to = to,
                        flight_name = f_name,
                        qty = qty,
                        user_id = user_id,
                        user_name = user_name,
                        user_email = user_email,
                        price = price,
                        s_id = s_id
                    };
                    add_list.List.Add(cart);
					//to convert into json
					//TempData store data if another data is add than first data is Delete automaticaly
					TempData["data"] = JsonConvert.SerializeObject(cart); 
				     return RedirectToAction(nameof(view_cart));
						
					}
					
			}
			return RedirectToAction(nameof(view_cart));
		}

		public IActionResult view_cart()
		{
            var data = TempData["data"] as string;
            Add_to_cart cart = data != null ? JsonConvert.DeserializeObject<Add_to_cart>(data) : null;
            return View(cart);
        }
		[HttpPost]
		public IActionResult updatacart()
		{
			var id = Request.Form["id"];
			var qty = Request.Form["qty"];
			var price = Request.Form["price"];

			var update = add_list.List.FirstOrDefault(s => s.s_id == id);
			if(update != null)
			{
				update.qty = qty;
			}

			return Content("price==" + price + "qty==" + qty + "id==" + id);

		}
		public IActionResult about() {

			ViewBag.choose = db.Chooses.ToList();
			ViewBag.about = db.Abouts.ToList();
			return View();
		
		}
		
		public IActionResult contacts(string email_error)
		{
			ViewBag.email_error = email_error;

            return View();
		}
		public IActionResult user_contact(Contact b)
		{
			if (!string.IsNullOrEmpty(Session_Model.UserId)) {
				var user_email = b.ContactEmail.ToString();
				if(Session_Model.UserEmail == user_email) {
					db.Contacts.Add(b);
					db.SaveChanges();
			return RedirectToAction(nameof(contacts));
				}
				else
				{
                    return RedirectToAction("contacts", "User", new { email_error = "Your Email is not match" });

                }
            }
			else
			{
				return RedirectToAction("Login", "Home", new { id_error = "Login YOur Self" });
			}
		}

		public IActionResult quote(string messages)
		{
			ViewBag.email_error = messages;
			return View();
		}

		public IActionResult user_feedback(Feedback e)
		{
			if (!string.IsNullOrEmpty(Session_Model.UserId))
			{
				var email = e.FEmail;
				if(Session_Model.UserEmail == email && Session_Model.UserFullName == e.FName) { 
				db.Feedbacks.Add(e);
				db.SaveChanges();
				return RedirectToAction(nameof(quote));
				}
				else
				{
					return RedirectToAction("quote", new { messages = "Your Email OR Name is not correct" });
				}
			}
			else
			{
				return RedirectToAction("Login", "Home");
			}
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
