using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computer_store_API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CumulativePoints { get; set; }
        public int Gender { get; set; }

    }
}
