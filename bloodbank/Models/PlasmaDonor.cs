using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class PlasmaDonor
    {
        public int Id { get; set; }
        public DateTime AffectedDate { get; set; }
        public DateTime RecoveryDate { get; set; }
        public bool IsVerified { get; set; }
        public bool HasDonated { get; set; }

        [ForeignKey("BloodDonor")]
        public int BloodDonorId { get; set; }

        public virtual BloodDonor BloodDonor { get; set; }
    }
}