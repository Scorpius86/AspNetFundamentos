using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Fundamentals.Web.Models
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {

        }
        public PersonViewModel(string firstName, int age)
        {
            FirstName = firstName;
            Age = age;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
    }
}
