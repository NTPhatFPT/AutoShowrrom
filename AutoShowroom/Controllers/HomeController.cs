using AutoShowroom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models1;
using Microsoft.AspNetCore.Http;

namespace AutoShowroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CheckLogin(UserAccount acc)
        {
            string username = acc.Username;
            string password = acc.UserPassword;
            using(var db = new MyStockContext())
            {
                UserAccount user = null;
                user = db.UserAccounts.Where(acc => acc.Username.Equals(username) && acc.UserPassword.Equals(password)).FirstOrDefault();
                if (user != null)
                {
                    if (user.Role == 1)
                    {
                        HttpContext.Session.SetInt32("role", 1);
                        HttpContext.Session.SetString("username", acc.Username);
                        return RedirectToAction("CarsManagement","Cars");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("role", 2);
                        HttpContext.Session.SetString("username", acc.Username);
                        return View("Index");
                    }
                }
                else
                {
                    TempData["fail"] = "Incorrect User name or Password!";
                    return View("Login");
                }
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Home");
        }
    }
}
