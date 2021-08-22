using AOC2015.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day2
{
    class Part1 : IPuzzle
    {
        public string Solution(string input)
        {
            Box[] boxes = GetBoxesFromInput(input);

            //IEnumerable<Box> boxes = input.Split(Environment.NewLine).ToList().Select((x) => { return Box.fromString(x); });

            return boxes.Select((x) => { return x is Box ? x.GetRequiredWrappingPaper() : 0; }).Sum().ToString();
        }

        public static Box[] GetBoxesFromInput(string input)
        {

            string[] lines = input.Split(Environment.NewLine);
            Box[] boxes = new Box[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                Box? b = Box.FromString(lines[i]);
                if (b != null)
                {
                    boxes[i] = b;
                }
            }

            return boxes;
        }
    }
}
