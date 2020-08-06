using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class DonationPost
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        [StringLength(255)]
        public String Location { get; set; }
        [StringLength(255)]
        public String Hospital { get; set; }
        [StringLength(100)]
        public String Contact { get; set; }
        [StringLength(10)]
        public String BloodGroup { get; set; }
        public String Details { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}