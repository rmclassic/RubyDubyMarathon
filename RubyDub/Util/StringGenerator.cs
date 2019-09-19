using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Util
{
    public static class StringGenerator
    {
        static Random RandomIntGenerator = new Random();
        public static string GenerateRandomString(int _length, bool haschars = true, bool hasnums = true)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string nums = "0123456789";
            string bank = "";

            if (haschars)
                bank += chars;
            if (hasnums)
                bank += nums;

            string random = "";
            
            for (int i = 0; i < _length; i++)
            {
                random += bank[RandomIntGenerator.Next() % bank.Length];
            }
            return random;
        }
    }
}
