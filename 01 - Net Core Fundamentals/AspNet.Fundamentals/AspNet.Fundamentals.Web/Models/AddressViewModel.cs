using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Fundamentals.Web.Models
{
    public class AddressViewModel
    {
        public AddressViewModel(int addressId,string district)
        {
            AddressId = addressId;
            District = district;
        }
        public int AddressId { get; set; }
        public string District { get; set; }
    }
}
