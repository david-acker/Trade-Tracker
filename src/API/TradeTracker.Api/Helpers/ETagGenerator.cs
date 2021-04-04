using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TradeTracker.Api.Helpers
{
    public static class ETagGenerator
    {
        public static string Generate(string key, byte[] contentBytes)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] combinedBytes = Combine(keyBytes, contentBytes);

            byte[] hash = ComputeHash(combinedBytes);
            
            return FormatAsETag(hash);
        }


        private static byte[] Combine(params byte[][] input)
        {
            if (input?.Count() > 1)
            {
                return input
                    .SelectMany(i => i)
                    .ToArray();
            }
            else
            {
                return input?.SingleOrDefault();
            }
        }

        private static byte[] ComputeHash(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(data);
            }
        }

        private static string FormatAsETag(byte[] data)
        {
            return BitConverter
                .ToString(data)
                .Replace("-", "");
        }
    }
}