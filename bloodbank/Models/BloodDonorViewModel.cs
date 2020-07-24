using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class BloodDonorViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string BloodGroup { get; set; }
        public DateTime? LastDonatedDate { get; set; }
    }
}