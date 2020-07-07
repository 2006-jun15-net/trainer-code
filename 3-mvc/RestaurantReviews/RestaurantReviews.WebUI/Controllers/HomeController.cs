using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantReviews.Domain.Model;
using RestaurantReviews.WebUI.ViewModels;

namespace RestaurantReviews.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["currentUser"] = "Nick";
            ViewBag.currentUser = "Not Nick";
            //TempData["data"] = new List<Restaurant> { new Restaurant { Id = 1 } };

            return View();
        }

        // GET: Privacy (not Home/Privacy)
        [Route("privacy")]
        //[HttpPost("privacy")] // sets route AND limits to POST
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
