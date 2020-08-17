using bloodbank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bloodbank.Context
{
    public class bloodbankDbContext:DbContext
    {
        public DbSet<BloodDonor> BloodDonors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DonationPost> DonationPosts { get; set; }

        public DbSet<PlasmaDonor> PlasmaDonors { get; set; }
    }
}