using bloodbank.Context;
using bloodbank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.DataAccess
{
    public class DonationPostDataAccess
    {
        public static DonationPost AddDonationPost(DonationPost model)
        {
            var db = new bloodbankDbContext();
            db.DonationPosts.Add(model);
            db.SaveChanges();
            return model;
        }

        public static List<DonationPost> GetDonationPosts()
        {
            var db = new bloodbankDbContext();
            return db.DonationPosts.ToList();
        }
    }
}