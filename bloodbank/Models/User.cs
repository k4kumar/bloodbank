using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(70)]
        public string UserRole { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(150)]
        public string PasswordSalt { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(100)]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [StringLength(150)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [StringLength(30)]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [StringLength(255)]
        public string Image { get; set; }

        //Security Columns
        [StringLength(255)]
        public string Token { get; set; }
        [StringLength(255)]
        public string ForgetPasswordToken { get; set; }
        [StringLength(255)]
        public string SecuritySitemap { get; set; }
        public int FailedLoginAttempt { get; set; }
        public bool BlockedUser { get; set; }
        public DateTime? LastLoginAt { get; set; }

        [ForeignKey("BloodDonor")]
        public int BloodDonorId { get; set; }

        public virtual BloodDonor BloodDonor { get; set; }

    }
}