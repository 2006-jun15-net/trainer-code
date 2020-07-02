using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleOrderApp.Domain;
using SimpleOrderApp.WebApp.Models;

namespace SimpleOrderApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationRepository _locationRepo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILocationRepository locationRepo, ILogger<HomeController> logger)
        {
            _locationRepo = locationRepo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var dummyData = new Location[]
            //{
            //    new Location("location 1", 1),
            //    new Location("location 2", 1)
            //};

            // bad code - separation of concerns is mostly ok but we should use dependency injection
            // for even more.
            //var factory = new SimpleOrderContextFactory();
            //using SimpleOrderContext context = factory.CreateDbContext();
            //ILocationRepository locationRepo = new LocationRepository(context);

            return View(_locationRepo.GetAll());
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
