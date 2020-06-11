using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Fundamentals.Web.Models;

namespace AspNet.Fundamentals.Web.Controllers
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
            PersonViewModel fabiana = new PersonViewModel("Fabiana", 12);
            List<AddressViewModel> adresses = new List<AddressViewModel>();
            adresses.Add(new AddressViewModel( 1, "San Isidro"));
            adresses.Add(new AddressViewModel(1, "Miraflores"));
            fabiana.Addresses = adresses;

            return View(fabiana);
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
