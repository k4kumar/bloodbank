using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int BloodDonorId { get; set; }
    }
}