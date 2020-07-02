using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using SimpleOrderApp.Domain;
using SimpleOrderApp.WebApp.ViewModels;

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

            var viewModel = _locationRepo.GetAll().Select(l => new LocationViewModel
            {
                Name = l.Name,
                Stock = l.Stock
            });

            return View(viewModel);
        }

        // routing will go to this action method
        // for regular requests (to /home/addlocation)
        [HttpGet]
        public IActionResult AddLocation()
        {
            return View();
        }

        // routing will go to this action method
        // for form submissions (to /home/addlocation)
        [HttpPost]
        //public IActionResult AddLocation(IFormCollection formData)
        public IActionResult AddLocation(LocationViewModel viewModel)
        {
            // any time you get data input from the user, you need to validate it.
            
            // if you model bind with a viewmodel with DataAnnotations on it like that,
            // the validations will be automatically checked, and any errors will go into ModelState for you.
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                //var location = new Location(formData["Name"], int.Parse(formData["Stock"]));

                // mapping
                var location = new Location(viewModel.Name, viewModel.Stock);

                // perform whatever operation we need to with the model.
                _locationRepo.Create(location);

                // go back to the list of locations
                // way #1:
                //return View(_locationRepo.GetAll());
                // problem: the URL still will say "/home/addlocation"
                // way #2: tell the browser to redirect to /home/index
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "there was some error, try again");
                // the asp-validation-summary tag helper (and asp-validation-for) will show any existing model errors
                return View();
                // the user will see the form again, with an error telling him something went wrong.
            }

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
