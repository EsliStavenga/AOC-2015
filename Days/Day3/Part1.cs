using AOC2015.Entities;
using AOC2015.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day3
{
    class Part1 : IPuzzle
    {
        private List<Position> pastHouses = new List<Position>();
        enum DIRECTION
        {
            UP = '^',
            DOWN = 'v',
            LEFT = '<',
            RIGHT = '>'
        }

        public string Solution(string input)
        {
            Position pos = new Position(0, 0);
            this.pastHouses.Add(pos.Clone());

            foreach(char d in input)
            {
                GetNewPosition(pos, d);


                if(this.pastHouses.Where(p =>
                {
                    return p.x == pos.x && p.y == pos.y;
                }).Count() == 0)
                {
                    this.pastHouses.Add(pos.Clone());
                } 
            }

            return this.pastHouses.Count().ToString();
        }

        internal static void GetNewPosition(Position pos, char d)
        {
            DIRECTION dir = (DIRECTION)d;
            int xInc = 0;
            int yInc = 0;

            switch (dir)
            {
                case DIRECTION.UP:
                    yInc++;
                    break;

                case DIRECTION.DOWN:
                    yInc--;
                    break;

                case DIRECTION.RIGHT:
                    xInc++;
                    break;

                case DIRECTION.LEFT:
                    xInc--;
                    break;

                default:
                    throw new InvalidTypeException(String.Format("Direction {0} is not defined", d));
            }

            pos.x += xInc;
            pos.y += yInc;
        }
    }
}
