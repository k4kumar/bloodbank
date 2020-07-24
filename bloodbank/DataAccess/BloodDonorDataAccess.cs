using bloodbank.Context;
using bloodbank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.DataAccess
{
    public class BloodDonorDataAccess
    {
        public static BloodDonor Get(int bloodDonorId)
        {
            var db = new bloodbankDbContext();
            var bloodDonor = db.BloodDonors.Find(bloodDonorId);
            if (bloodDonor == null)
                return null;
            return bloodDonor;
        }

        public static List<BloodDonor> GetBloodDonorsList()
        {
            var db = new bloodbankDbContext();
            var bloodDonors = db.BloodDonors.OrderBy(e=>e.LastDonatedDate).ToList();
            if (bloodDonors == null)
                return null;
            return bloodDonors;
        }

        public static List<BloodDonor> GetActiveBloodDonorsList()
        {
            var db = new bloodbankDbContext();
            var bloodDonors = db.BloodDonors.Where(e=>e.IsVerified).OrderBy(e => e.LastDonatedDate).ToList();
            if (bloodDonors == null)
                return null;
            return bloodDonors;
        }


        public static int RegisterBloodDonor(BloodDonorViewModel model)
        {
            var db = new bloodbankDbContext();
            var blooddonor = new BloodDonor();
            blooddonor.Name = model.Name;
            blooddonor.Email = model.Email;
            blooddonor.Mobile = model.Mobile;
            blooddonor.IsVerified = false;
            blooddonor.LastDonatedDate = model.LastDonatedDate?? new DateTime(2000,1,1);
            blooddonor.BloodGroup = model.BloodGroup;
            blooddonor.Address = model.Address;
            blooddonor.Longitude = 0;
            blooddonor.Latitude = 0;
            blooddonor.IsVerified = false;
            blooddonor.HasDonated = model.LastDonatedDate == null ? false : true;
           

            db.BloodDonors.Add(blooddonor);
            blooddonor.Id = db.SaveChanges();

            return blooddonor.Id;
        }


    }
}