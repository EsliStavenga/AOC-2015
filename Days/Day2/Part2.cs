using AOC2015.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day2
{
    class Part2 : IPuzzle
    {
        public string Solution(string input)
        {
            Box[] boxes = Part1.GetBoxesFromInput(input);

            //IEnumerable<Box> boxes = input.Split(Environment.NewLine).ToList().Select((x) => { return Box.fromString(x); });

            return boxes.Select((x) => { return x is Box ? x.GetRequiredRibbon() : 0; }).Sum().ToString();
        }
    }
}
