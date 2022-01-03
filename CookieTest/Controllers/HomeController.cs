using CookieTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace CookieTest.Controllers
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
            var visitString = Request.Cookies["visits"];
            int visits = 0;
            int.TryParse(visitString, out visits);
            visits++;
            CookieOptions options = new();
            options.Expires = DateTimeOffset.Now.AddSeconds(20);
            Response.Cookies.Append("visits", visits.ToString(), options);

            //Response.Cookies.Delete("visits");

            ViewBag.visits = visits;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}