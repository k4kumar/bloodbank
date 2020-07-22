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
    }
}