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

            CookieOptions options = new(); //cria o cookie
            options.Expires = DateTimeOffset.Now.AddSeconds(20); //tempo para expiração do cookie criado
            Response.Cookies.Append("visits", "Qualquer Coisa", options); //adiciona o cookie
            //Response.Cookies.Delete("visits"); //deleta o cookie
            return View();
        }
        public IActionResult Index2()
        {
            var visitString = Request.Cookies["visits"];
            ViewBag.visits = visitString == "Qualquer Coisa" ? "visitou" : "não visitou";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VerificaCookie()
        {
            try
            {
                if (TemCookie())
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        private bool TemCookie()
        {
            string? cookieAlert = Request.Cookies["cookieAlert"];
            var x = !(string.IsNullOrEmpty(cookieAlert));
            return x;
        }

        [HttpPost]
        public IActionResult GravaCookie()
        {
            try
            {
                CookieOptions cookieAlert = new();
                cookieAlert.Expires = DateTimeOffset.Now.AddSeconds(10); //tempo para expiração do cookie criado
                Response.Cookies.Append("cookieAlert", "Qualquer Coisa", cookieAlert); //adiciona o cookie
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}