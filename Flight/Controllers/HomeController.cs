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
            var data = db.Users.FirstOrDefault( x => x.UsersName == a.UsersName && x.UsersPassword == a.UsersPassword );
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if(data != null)
            {

                if(data.RoleId == 2)
                {
                    identity = new ClaimsIdentity(new[] {

                    new Claim(ClaimTypes.Name , a.UsersName),
                    new Claim(ClaimTypes.Role , "Admin")

                    }, CookieAuthenticationDefaults .AuthenticationScheme ) ;
                    isAuthenticate = true;
                };

                if(data.RoleId == 1)
                {
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name , a.UsersName),
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
                        return RedirectToAction("Index", "Home");
                    }



				}


            }

            ViewBag.dataa = "Invalid Credentials";
            return View("Login");
        }
        [Authorize(Roles = "Admin,User")]

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,User")]
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

            var data = db.Users.ToList();
            ViewBag.opra = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(data);
        }
        public IActionResult users_delete(int? id)
        {
            var data = db.Users.FirstOrDefault(x => x.UsersId == id);
            db.Remove(data);
            db.SaveChanges();
            return RedirectToAction(nameof(view)); 
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
            ViewBag.Flight = new SelectList(db.Flightsses, "FId", "FName");
            ViewBag.Route = new SelectList(db.Routesses, "RId", "RName");
            ViewBag.sho = db.Schedules.ToList();
            return View();
        }
        public IActionResult insert_shadulespro(Schedule e)
        {
            db.Add(e);
            db.SaveChanges();
            return RedirectToAction(nameof(insert_shadules));
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}