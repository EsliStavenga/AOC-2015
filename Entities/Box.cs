using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015.Entities
{
    class Box
    {
        public int length { get; }
        public int height { get; }
        public int width { get; }

        public Box() { }

        public Box(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public static Box? FromString(string s)
        {
            if(s == "")
            {
                return null;
            }

            int[] sides = s.Split("x").Select(int.Parse).ToArray();

            return new Box(sides[0], sides[1], sides[2]);
        }

        public int GetRequiredRibbon()
        {
            return this.GetVolume() + this.GetShortestDistanceAroundSides();
        }

        public int GetVolume()
        {
            return this.length * this.width * this.height;
        }

        public int GetShortestDistanceAroundSides()
        {
            return this.length * 2 + this.height * 2 + this.width * 2 - this.GetLargestSide() * 2;
        }

        public int GetRequiredWrappingPaper()
        {
            return this.GetSurfaceArea() + this.GetSmallestArea();
        }

        public int GetLargestSide()
        {
            return Math.Max(this.height, Math.Max(this.length, this.width));
        }

        public int GetSmallestArea()
        {
            return Math.Min(this.height * this.length, Math.Min(this.length * this.width, this.width * this.height));
        }

        public int GetSurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        }

    }
}
