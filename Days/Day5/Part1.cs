using AOC2015.Entities;
using AOC2015.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AOC2015.Day5
{
    class Part1 : IPuzzle
    {
        private readonly string[] illegalStrings = new string[] { "ab", "cd", "pq", "xy" };
        private readonly char[] vowels = new char[] { 'a', 'e', 'u', 'i', 'o' };

        public string Solution(string input)
        {
            string[] lines = input.Split(Environment.NewLine);
            int niceStringCount = 0;

            foreach(string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                bool hasIllegalCharacter = this.containsIllegalString(line);
                int vowelCount = line.ToCharArray().Where(x => this.vowels.Contains(x)).Count();
                bool hasDoubleRow = this.hasLetterInARow(line);

                if (hasIllegalCharacter || vowelCount < 3 || !hasLetterInARow(line))
                {
                    continue;
                }

                niceStringCount++;
            }

            return niceStringCount.ToString();
        }

        private bool hasLetterInARow(string s)
        {
            char lastChar = s[0];
            s = s.Remove(0, 1);

            foreach (char c in s)
            {
                if(c == lastChar)
                {
                    return true;
                }

                lastChar = c;
            }

            return false;

        }

        private bool containsIllegalString(string s)
        {
            foreach(string i in this.illegalStrings)
            {
                if(s.Contains(i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
