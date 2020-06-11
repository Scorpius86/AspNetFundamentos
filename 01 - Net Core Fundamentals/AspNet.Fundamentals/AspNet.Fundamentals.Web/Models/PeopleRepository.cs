using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Fundamentals.Web.Models
{
    public class PeopleRepository:IPeopleRepository
    {
        public PeopleRepository(List<PersonViewModel> people)
        {
            People = people;
        }
        public List<PersonViewModel> People { get; set; }
    }
}
