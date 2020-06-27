using OTPService.Helpers;
using OTPService.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OTPService.Service
{
    public class OTPGenerator : IOTPGenerator
    {
        const int secretLength = 20;
        const long ticksToSeconds = 10000000L;
        private readonly Random _random;
        private readonly int _activeTime;
        private readonly int _numberOfDigits;
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public OTPGenerator(OTPSettings settings)
        {
            _random = new Random(Guid.NewGuid().GetHashCode());
            _activeTime = settings.OTPLifeTime;
            _numberOfDigits = settings.NumberOfDigits;
        }

        public int GenerateOtp(string secret, DateTime currentTime)
        {
            var hmacHash = GenerateHash(secret, currentTime);

            var offset = hmacHash[19] & 0xf;

            var truncatedHash = (hmacHash[offset++] & 0x7f) << 24 |
                                (hmacHash[offset++] & 0xff) << 16 | 
                                (hmacHash[offset++] & 0xff) << 8 |
                                (hmacHash[offset++] & 0xff);
            
            
            return truncatedHash % (int)(Math.Pow(10, _numberOfDigits));
        }

        public string GenerateSecret()
        {
            return new string(Enumerable.Repeat(chars, secretLength)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private byte[] GenerateHash(string secret, DateTime currentTime)
        {
            using (var hmac = new HMACSHA1())
            {
                hmac.Key = Convert.FromBase64String(secret);
                var hmacBytes = hmac.ComputeHash(ConvertHelper.GetBigEndianBytes(GetWindow(currentTime)));
                return hmacBytes;
            }
        }

        private long GetWindow(DateTime currentTime)
        {
            return (currentTime.Ticks/ ticksToSeconds) / _activeTime;
        }
    }
}
