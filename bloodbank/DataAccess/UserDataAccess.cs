using bloodbank.Context;
using bloodbank.Helpers;
using bloodbank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.DataAccess
{
    public class UserDataAccess
    {
        public static User CheckUserLogin(string username, string password)
        {
            var db = new bloodbankDbContext();
            var hashPassword = PasswordHash.Hash(password);
            return db.Users.FirstOrDefault(e => e.UserName == username && e.Password == hashPassword);
        }

        public static int AutoGenerateUser()
        {
            var db = new bloodbankDbContext();
            List<BloodDonor> bloodDonors = db.BloodDonors.ToList();
            int result = 0;
            foreach(BloodDonor bloodDonor in bloodDonors)
            {
                bool exist = db.Users.Where(e => e.BloodDonorId == bloodDonor.Id).Count() > 0;
                if(!exist)
                {
                    
                    User user = new User
                    {
                        UserName = bloodDonor.RegNo,
                        Password = PasswordHash.Hash(bloodDonor.RegNo),
                        Email = bloodDonor.Email?? "",
                        PasswordSalt = Guid.NewGuid().ToString("N").Substring(0, 8),
                        ForgetPasswordToken = Guid.NewGuid().ToString("N").Substring(0, 20),
                        Token = Guid.NewGuid().ToString("N").Substring(0, 6),
                        SecuritySitemap = Guid.NewGuid().ToString("N").Substring(0, 12),
                        FailedLoginAttempt = 0,
                        LastLoginAt = DateTime.Now,
                        MobileNumber = "",
                        BlockedUser = false,
                        FullName = bloodDonor.Name,
                        Image = "",
                        UserRole = "user",
                        BloodDonorId = bloodDonor.Id
                    };

                    db.Users.Add(user);
                }
                result = db.SaveChanges();
            }
            return result;
        }

        public static object GetUserInfoById(int userId)
        {
            var db = new bloodbankDbContext();
            var user = db.Users.Find(userId);
            if (user == null)
                return null;
            return new
            {
                userId = user.UserId,
                email = user.Email ?? "",
                name = user.FullName ?? "",
                username = user.UserName ?? "",
                phone = user.MobileNumber ?? "",
                role = user.UserRole?? ""

            };
        }

        public static int CreateUser(UserViewModel user)
        {
            var db = new bloodbankDbContext();
            User create_user = new User
            {
                UserName = user.UserName,
                Password = PasswordHash.Hash(user.Password),
                Email = user.Email,
                PasswordSalt = Guid.NewGuid().ToString("N").Substring(0, 8),
                ForgetPasswordToken = Guid.NewGuid().ToString("N").Substring(0, 20),
                Token = Guid.NewGuid().ToString("N").Substring(0, 6),
                SecuritySitemap = Guid.NewGuid().ToString("N").Substring(0, 12),
                FailedLoginAttempt = 0,
                LastLoginAt = DateTime.Now,
                MobileNumber = "",
                BlockedUser = false,
                FullName = user.UserName,
                Image = "",
                UserRole = "user"
            };
            db.Users.Add(create_user);
            int result = db.SaveChanges();

            return result;
        }
    }
}