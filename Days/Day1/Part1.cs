using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day1
{
    class Part1 : IPuzzle
    {
        public string Solution(string input)
        {
            List<string> splitInput = input.Split("").ToList();
            int floorUpCount = input.Where(x => x == '(').Count();
            int floorDownCount = input.Where(x => x == ')').Count();


            return (floorUpCount - floorDownCount).ToString();
        }
    }
}
