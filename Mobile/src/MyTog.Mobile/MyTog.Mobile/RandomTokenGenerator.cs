using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Kalinkin.MyTog.Mobile
{
    class RandomTokenGenerator
    {
        public static string GenerateUrlSafeToken(int strength = 16)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var randomBytes = new byte[strength];
            random.NextBytes(randomBytes); // fills randomBytes with random bytes
            var token = HttpUtility.UrlEncode(randomBytes); // unlike straight-up Base64, safe in URLs
            return token;
        }

        public static string GenerateCryptographicUrlSafeToken(int strength = 16)
        {
            var random = new RNGCryptoServiceProvider();
            var randomBytes = new byte[strength];
            random.GetBytes(randomBytes); // fills randomBytes with random bytes
            var token = HttpUtility.UrlEncode(randomBytes); // unlike straight-up Base64, safe in URLs
            return token;
        }
    }
}
