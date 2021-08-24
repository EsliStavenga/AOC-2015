using AOC2015.Entities;
using AOC2015.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AOC2015.Day4
{
    class Part1 : IPuzzle
    {

        protected int leadingZeroesCount = 5;

        public string Solution(string input)
        {
            int counter = 0;
            string hash = "";
            string leadingZeroes = new String('0', leadingZeroesCount);

            while (!hash.StartsWith(leadingZeroes))
            {
                hash = CreateMD5Hash(input + (++counter).ToString());
            }

            return counter.ToString();
        }

        public string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
