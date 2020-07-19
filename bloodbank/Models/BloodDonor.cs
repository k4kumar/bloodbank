using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class BloodDonor
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100,ErrorMessage ="Name can't be longer than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(500, ErrorMessage = "Address can't be longer than 500 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(13, ErrorMessage = "Mobile number can't be longer than 13 characters")]
        public string Mobile { get; set; }
        [DisplayName("Last Donation Date")]
        public DateTime? LastDonatedDate { get; set; }
        [Required(ErrorMessage = "Blood Group is required")]
        [DisplayName("Blood Group")]
        public string BloodGroup { get; set; }
        public string Email { get; set; }
        [DefaultValue(false)]
        public bool HasDonated { get; set; }
        [DefaultValue(true)]
        public bool IsVerified { get; set; }
    }
}