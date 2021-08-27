using AOC2015.Entities;
using AOC2015.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using static AOC2015.Entities.Light;

namespace AOC2015.Day6
{
    class Part2 : Part1
    {
        public Part2() : base(LIGHT_TYPE.DIMMABLE) { }

        new public string Solution(string input)
        {
            this.processInput(input);


            return this.lights.Sum(x => x.Value.Sum(l => l.Brightness)).ToString() ;
        }

    }
}
