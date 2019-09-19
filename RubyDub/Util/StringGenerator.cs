using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Util
{
    public static class StringGenerator
    {
        static Random RandomIntGenerator = new Random();
        public static string GenerateRandomString(int _length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string random = "";
            
            for (int i = 0; i < _length; i++)
            {
                random += chars[RandomIntGenerator.Next() % chars.Length];
            }
            return random;
        }
    }
}
