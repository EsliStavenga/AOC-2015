using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day1
{
    class Part2 : IPuzzle
    {
        public string Solution(string input)
        {
            int floor = 0;
            int steps = 1;

            foreach(char direction in input)
            {
                floor += (direction == '(') ? 1 : -1;
                if(floor == -1)
                {
                    break;
                }

                steps++;
            }

            return steps.ToString();
        }
    }
}
