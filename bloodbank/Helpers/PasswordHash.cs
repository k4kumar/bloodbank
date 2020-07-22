using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bloodbank.Helpers
{
    public class PasswordHash
    {
        public static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}