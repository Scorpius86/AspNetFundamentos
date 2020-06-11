using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Fundamentals.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Fundamentals.Web.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        // GET: api/Peoples
        [HttpGet]
        public IEnumerable<PersonViewModel> Get()
        {
            return _peopleRepository.People;
        }

        // GET: api/Peoples/Erick
        [HttpGet("{firstName}")]
        public PersonViewModel Get(string firstName)
        {
            return _peopleRepository.People.Where(w=>w.FirstName == firstName).FirstOrDefault();
        }

        // POST: api/Peoples
        [HttpPost]
        public void Post([FromBody] PersonViewModel personViewModel)
        {
            _peopleRepository.People.Add(personViewModel);
        }

        // PUT: api/Peoples/5
        [HttpPut("{firstName}")]
        public void Put(string firstName, [FromBody] PersonViewModel personViewModel)
        {
            _peopleRepository.People.Where(w => w.FirstName == firstName).FirstOrDefault().Age = personViewModel.Age;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{firstName}")]
        public void Delete(string firstName)
        {
            var person = _peopleRepository.People.Where(w => w.FirstName == firstName).FirstOrDefault();
            _peopleRepository.People.Remove(person);
        }
    }
}
