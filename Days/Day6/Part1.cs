using AOC2015.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static AOC2015.Entities.Light;

namespace AOC2015.Day6
{
    class Part1 : IPuzzle
    {
        private int gridSize = 1000;
        protected Dictionary<int, Light[]> lights = new Dictionary<int, Light[]>();

        //we need a parameter less constructor for autoloading
        public Part1() : this(LIGHT_TYPE.STANDARD) { }

        public Part1(LIGHT_TYPE lightType)
        {
            for(int i = 0; i < this.gridSize; i++)
            {
                Light[] row = new Light[this.gridSize]; // this.lights.TryGetValue(i, out Light[] row);

                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = new Light(type: lightType);
                }

                this.lights.Add(i, row);
            }
        }

        public string Solution(string input)
        {
            this.processInput(input);
            return this.lights.Select(x => x.Value.Where(l => l.IsOn()).Count()).Sum().ToString();
        }

        protected void processInput(string input)
        {
            input = input.Replace("turn", "").Replace("through", "").Replace("  ", " ");
            string[] lines = input.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] words = line.Trim().Split(' ');
                string command = words[0];

                string[] minCoords = words[1].Split(',');
                int minX = int.Parse(minCoords[0]);
                int minY = int.Parse(minCoords[1]);

                string[] maxCoords = words[2].Split(',');
                int maxX = int.Parse(maxCoords[0]);
                int maxY = int.Parse(maxCoords[1]);

                for (int i = minY; i <= maxY; i++)
                {
                    Light[] row = this.lights[i];

                    for (int j = minX; j <= maxX; j++)
                    {
                        row[j].ExecuteCommand(command);
                    }
                }

            }
        }
    }
}
