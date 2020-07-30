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

        [Required]
        [StringLength(10,ErrorMessage ="Reg No can't be longer than 10 characters")]
        public string RegNo { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(100,ErrorMessage ="Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Nick name can't be longer than 100 characters")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Division is required")]
        [StringLength(500, ErrorMessage = "Division can't be longer than 500 characters")]
        public string Division { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(13, ErrorMessage = "Mobile number can't be longer than 13 characters")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Emergency number is required")]
        [StringLength(13, ErrorMessage = "Emergency number can't be longer than 13 characters")]
        public string EmergencyContact { get; set; }
        [DisplayName("Last Donation Date")]
        public DateTime? LastDonatedDate { get; set; }
        [Required(ErrorMessage = "Blood Group is required")]
        [DisplayName("Blood Group")]
        public string BloodGroup { get; set; }
        [StringLength(100,ErrorMessage = "Email can't be longer than 100 characters")]
        public string Email { get; set; }

        [StringLength(500,ErrorMessage ="Comments can't be longer than 500 characters")]
        public string Comment { get; set; }

        [DefaultValue(false)]
        public bool HasDonated { get; set; }
        [DefaultValue(true)]
        public bool IsVerified { get; set; }
        [DefaultValue(0)]
        public double Longitude { get; set; }
        [DefaultValue(0)]
        public double Latitude { get; set; }
    }
}