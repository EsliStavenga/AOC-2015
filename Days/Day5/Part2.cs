using AOC2015.Entities;
using AOC2015.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day5
{
    class Part2 : IPuzzle
    {
        public string Solution(string input)
        {
            string[] lines = input.Split(Environment.NewLine);
            int niceStringCount = 0;

            foreach (string line in lines) {
                bool hasOverlap = this.hasPairWithoutOverlap(line);
                bool hasRepeating = this.hasRepeatingCharacter(line);

                if (!(hasOverlap && hasRepeating))
                {
                    continue;
                }

                niceStringCount++;
            }

            return niceStringCount.ToString();
        }

        private bool hasRepeatingCharacter(string s)
        {
            int max = s.Length - 2;

            for(int i = 0; i < max; i++)
            {
                if(s[i] == s[i+2])
                {
                    return true;
                }
            }

            return false;
        }

        private bool hasPairWithoutOverlap(string s)
        {
            int max = s.Length - 1;

            // loop over all the characters in the string
            for (int i = 0; i < max; i++)
            {
                //create a string of the character at the current index and the next one
                string tmp = s.Substring(i, 2);

                //remove all the strings up to and including the current characters
                //this so a string like "aaa" won't match the pair trigger
                if(s.Remove(0, i+2).Contains(tmp))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
