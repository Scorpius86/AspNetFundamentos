using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Fundamentals.Web.Models
{
    public interface IPeopleRepository
    {
        public List<PersonViewModel> People { get; set; }
    }
}
