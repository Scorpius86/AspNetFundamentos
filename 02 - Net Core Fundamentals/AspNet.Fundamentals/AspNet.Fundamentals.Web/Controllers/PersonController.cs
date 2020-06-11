using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Fundamentals.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Fundamentals.Web.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            PersonViewModel fabiana = new PersonViewModel("Fabiana", 12);
            List<AddressViewModel> adresses = new List<AddressViewModel>();
            adresses.Add(new AddressViewModel(1, "San Isidro"));
            adresses.Add(new AddressViewModel(1, "Miraflores"));
            fabiana.Addresses = adresses;

            return View(fabiana);
        }
        [HttpPost]
        [Route("Person/GetPerson")]
        public IActionResult ObtenerPersona()
        {
            PersonViewModel fabiana = new PersonViewModel("Fabiana", 12);
            List<AddressViewModel> adresses = new List<AddressViewModel>();
            adresses.Add(new AddressViewModel(1, "San Isidro"));
            adresses.Add(new AddressViewModel(1, "Miraflores"));
            fabiana.Addresses = adresses;

            return Json(fabiana);
        }
    }
}