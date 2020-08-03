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
            BloodDonor bloodDonor = db.BloodDonors.Find(bloodDonorId);
            if (bloodDonor == null)
                return null;
            return GetBloodDonor(bloodDonor);
        }

        public static List<BloodDonor> GetBloodDonorsList()
        {
            var db = new bloodbankDbContext();
            List<BloodDonor> result = new List<BloodDonor>();
            List<BloodDonor> bloodDonors = db.BloodDonors.OrderBy(e=>e.IsVerified).ThenBy(e=>e.LastDonatedDate).ToList();
            if (bloodDonors == null)
                return null;
            foreach(BloodDonor donor in bloodDonors)
            {
                BloodDonor resultDonor = GetBloodDonor(donor);
                result.Add(resultDonor);
            }
            return result;
        }

        private static BloodDonor GetBloodDonor(BloodDonor donor)
        {
            return new BloodDonor
            {
                Name = donor.Name,
                NickName = donor.NickName ?? "",
                Email = donor.Email ?? "",
                LastDonatedDate = donor.LastDonatedDate ?? new DateTime(2000, 1, 1),
                Comment = donor.Comment ?? "",
                BloodGroup = donor.BloodGroup,
                HasDonated = donor.HasDonated,
                Id = donor.Id,
                IsVerified = donor.IsVerified,
                Mobile = donor.Mobile,
                EmergencyContact = donor.EmergencyContact ?? donor.Mobile,
                Division = donor.Division,
                RegNo = donor.RegNo,
                Latitude = 0,
                Longitude = 0
            };
        }

        public static bool CheckDonorExist(string regNo)
        {
            var db = new bloodbankDbContext();
            BloodDonor bloodDonor = db.BloodDonors.Where(e=>e.RegNo == regNo).FirstOrDefault();
            if (bloodDonor == null)
                return false;
            return true;
        }

        public static List<BloodDonor> GetActiveBloodDonorsList()
        {
            var db = new bloodbankDbContext();
            List<BloodDonor> result = new List<BloodDonor>();
            List<BloodDonor> bloodDonors = db.BloodDonors.Where(e=>e.IsVerified).OrderBy(e => e.LastDonatedDate).ToList();
            if (bloodDonors == null)
                return null;
            foreach (BloodDonor donor in bloodDonors)
            {
                BloodDonor resultDonor = GetBloodDonor(donor);
                result.Add(resultDonor);
            }
            return result;
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
            blooddonor.Division = model.Division;
            blooddonor.NickName = model.NickName;
            blooddonor.RegNo = model.RegNo;
            blooddonor.EmergencyContact = model.EmergencyContact;
            blooddonor.Comment = model.Comment;
            blooddonor.Longitude = 0;
            blooddonor.Latitude = 0;
            blooddonor.IsVerified = false;
            blooddonor.HasDonated = model.LastDonatedDate == null ? false : true;
           

            db.BloodDonors.Add(blooddonor);
            blooddonor.Id = db.SaveChanges();

            UserViewModel user = new UserViewModel
            {
                Password = model.Password,
                UserName = model.Username,
                Email = model.Email?? ""
            };

            int result = UserDataAccess.CreateUser(user);

            return blooddonor.Id;
        }

        public static BloodDonor ApproveDonor(int id)
        {
            var db = new bloodbankDbContext();
            var blooddonor = new BloodDonor();
            BloodDonor bloodDonor = db.BloodDonors.Find(id);
            if (bloodDonor == null)
                return null;

            bloodDonor.IsVerified = true;
            db.Entry(bloodDonor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return bloodDonor;
        }

        public static BloodDonor LastDonationDateUpdate(int id,DateTime date)
        {
            var db = new bloodbankDbContext();
            var blooddonor = new BloodDonor();
            BloodDonor bloodDonor = db.BloodDonors.Find(id);
            if (bloodDonor == null)
                return null;

            bloodDonor.LastDonatedDate = date;
            bloodDonor.HasDonated = true;
            db.Entry(bloodDonor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return bloodDonor;
        }



    }
}