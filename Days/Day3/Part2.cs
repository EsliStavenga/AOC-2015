using AOC2015.Entities;
using AOC2015.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2015.Day3
{
    class Part2 : IPuzzle
    {
        private List<Position> pastHouses = new List<Position>();
        private SANTA_GEN whosMoveIsItAnyways = SANTA_GEN.SANTA;
        enum SANTA_GEN
        {
            SANTA,
            ROBOT_SANTA
        }


        public string Solution(string input)
        {
            Position santa = new Position(0, 0);
            Position roboSanta = new Position(0, 0);

            this.pastHouses.Add(santa.Clone());

            foreach(char d in input)
            {
                Position pos;
                if (whosMoveIsItAnyways == SANTA_GEN.SANTA)
                {
                     pos = santa;
                    whosMoveIsItAnyways = SANTA_GEN.ROBOT_SANTA;
                } else
                {
                    pos = roboSanta;
                    whosMoveIsItAnyways = SANTA_GEN.SANTA;
                }

                Part1.GetNewPosition(pos, d);


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
    }
}
