using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class PlasmaDonorViewModel
    {
        public DateTime AffectedDate { get; set; }
        public DateTime RecoveryDate { get; set; }
        public bool IsVerified { get; set; }
        public string RegNo { get; set; }
        public bool HasDonated { get; set; }
        public int UserId { get; set; }
    }
}