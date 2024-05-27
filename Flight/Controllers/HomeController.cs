using Flight.Data;
using Flight.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Claims;

namespace Flight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly flightContext db;
        

        public HomeController(flightContext a)
        {
            this.db = a;
        }

        public IActionResult Sign_up()
        {
            return View();
        }

        public IActionResult signup_pro(User b)
        {
            b.RoleId = 2;
            db.Add(b);
            db.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Log(User a)
        {
            var data = db.Users.FirstOrDefault( x => x.UsersEmail == a.UsersEmail && x.UsersPassword == a.UsersPassword );
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if(data != null)
            {

                if(data.RoleId == 2)
                {
                    identity = new ClaimsIdentity(new[] {

                    new Claim(ClaimTypes.Email , a.UsersEmail),
                    new Claim(ClaimTypes.Role , "Admin")

                    }, CookieAuthenticationDefaults .AuthenticationScheme ) ;
                    isAuthenticate = true;
                };

                if(data.RoleId == 1)
                {
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Email , a.UsersEmail),
                        new Claim(ClaimTypes.Role , "User")
                    }, CookieAuthenticationDefaults.AuthenticationScheme
                    );
                    isAuthenticate = true;

                }

                if (isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if(data.RoleId == 2)
                    {
						return RedirectToAction("Index" , "Home");

					}
                    else if(data.RoleId == 1)
                    {
                        return RedirectToAction("Index", "User");
                    }



				}


            }

            ViewBag.dataa = "Invalid Name or Password";
            return View("Login");
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult insert_role()
        {
            return View();
        }
        public IActionResult insert_rolepro(Role a)
        {
            db.Add(a);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_role));
        }
        public IActionResult view()
        {
            var data = db.Roles.ToList();
            return View(data);
        }
        public IActionResult role_delete(int? Id) {
            var delete = db.Roles.FirstOrDefault(x => x.RoleId == Id);
            db.Remove(delete);
            db.SaveChanges();
            return RedirectToAction(nameof(view));
        }


        public IActionResult insert_users()
        {
            return View();
        }
        public IActionResult insert_userspro(User data)
        {
            data.RoleId = 2;
            db.Add(data);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_users));
        }

        public IActionResult show_users(User a)
        {

            var data = db.Users.Include(z => z.Role).ToList();
            ViewBag.opra = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(data);
        }
        public IActionResult users_delete(int? id)
        {
            var data = db.Users.FirstOrDefault(x => x.UsersId == id);
            db.Remove(data);
            db.SaveChanges();
            return RedirectToAction(nameof(show_users)); 
        }

        public IActionResult insert_flight()
        {
            return View();
        }
        public IActionResult insert_flightpro(Flightss e)
        {
            db.Add(e);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_flight));
        }
        public IActionResult show_flight()
        {
            var data = db.Flightsses.ToList();
            return View(data);
        }
        public IActionResult flight_delete(int? id)
        {
            var data = db.Flightsses.FirstOrDefault(x => x.FId == id);
            db.Remove(data);
            db.SaveChanges();
            return RedirectToAction(nameof(show_flight));
        }
        public IActionResult flight_update(int? id)
        {
            var update = db.Flightsses.Find(id);
            return View(update);
        }
        public IActionResult update_flightpro(Flightss e)
        {
            db.Update(e);
            db.SaveChanges();
            return RedirectToAction(nameof(show_flight));

        }

        public IActionResult insert_Routes()
        {
            return View();
        }
        public IActionResult insert_routepro(Routess e)
        {
            db.Add(e);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_Routes));
        }
        public IActionResult show_Routes()
        {
            var data = db.Routesses.ToList();
            return View(data);
        }
        public IActionResult routes_delete(int? Id)
        {
            var data = db.Routesses.FirstOrDefault(x => x.RId == Id);
            db.Remove(data);
            db.SaveChanges();
            return RedirectToAction(nameof(show_Routes));
        }
        public IActionResult insert_shadules()
        {
            ViewBag.Flight = new SelectList(db.Flightsses, "FId", "FName" );
            ViewBag.Route = new SelectList(db.Routesses, "RId", "RFrom" , "RTo");
            ViewBag.sho = db.Schedules.ToList();
            return View();
        }
        public IActionResult insert_shadulespro(Schedule e)
        {
            db.Add(e);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_shadules));
        }
        public IActionResult sehadules_delete(int? id)
        {

            var delete = db.Schedules.FirstOrDefault(z => z.SheduleId == id);
            db.Remove(delete);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_shadules));
        }


        public IActionResult insert_specail_shadules()
		{
			ViewBag.Flight = new SelectList(db.Flightsses, "FId", "FName");
			ViewBag.Route = new SelectList(db.Routesses, "RId", "RFrom", "RTo");
			ViewBag.sho = db.SpecialSets.ToList();
			return View();
		}
		public IActionResult insert_special_shadulespro(SpecialSet e)
		{
			db.Add(e);
			db.SaveChanges();
			return RedirectToAction(nameof(insert_specail_shadules));
		}


		public IActionResult insert_class()
        {
            ViewBag.clas = db.Classes.ToList();
            return View();
        }
        public IActionResult insert_classpro(Class a)
        {
            db.Add(a);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_class));



        }
        public IActionResult class_delete(int? Id)
        {
            var delete = db.Classes.FirstOrDefault(x => x.ClassId == Id);
            db.Remove(delete);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_class));

        }

        public IActionResult class_update(int? Id)
        {
            var update = db.Classes.Find(Id);
            return View(update);

        }
        public IActionResult class_updatepro(Class a)
        {
            db.Update(a);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_class));

        }

        public IActionResult insert_flight_detail()
        {
            ViewBag.scheual = new SelectList(db.Schedules,"");
            return View();
        }

        public IActionResult insert_about()
        {
            ViewBag.about = db.Abouts.ToList();
            return View();
        }

        public IActionResult insert_aboutpro(About e , IFormFile AboutImg)
        {
            if(AboutImg != null) {

                var filename = Path.GetFileName(AboutImg.FileName);
                var filepath = Path.Combine("wwwroot/img/about" , filename);
                var dbpath = Path.Combine("img", filename);

                using(var strom = new FileStream(filepath , FileMode.Create))
                {
                    AboutImg.CopyTo(strom);
                }
                e.AboutImg = dbpath;
                db.Abouts.Add(e);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_about));
            }
            return RedirectToAction(nameof(insert_about));

        }

        public IActionResult about_delete(int? id)
        {
            var delete = db.Abouts.FirstOrDefault(z => z.AboutId == id);
            db.Remove(delete);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_about));

        }

        public IActionResult insert_choose()
        {
            ViewBag.choose = db.Chooses.ToList();
            return View();
        }

        public IActionResult insert_choosepro(Choose e)
        {
            db.Add(e);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_choose));
        }

        public IActionResult choose_delete(int? id)
        {
            var delete = db.Chooses.FirstOrDefault(z => z.CId == id);
            db.Remove(delete);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_choose));

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}