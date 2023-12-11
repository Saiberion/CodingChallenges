using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    public class Day11 : Day
    {
        public override void Solve()
        {
            List<List<char>> universe = new();

            foreach (string line in Input)
            {
                List<char> mapLine = new();
                foreach (char c in line)
                {
                    mapLine.Add(c);
                }
                universe.Add(mapLine);
            }

            for (int y = 0; y < universe.Count; y++)
            {
                bool noGalaxies = true;
                for (int x = 0; x < universe[y].Count; x++)
                {
                    if (universe[y][x] != '.')
                    {
                        noGalaxies = false;
                    }
                }
                if (noGalaxies)
                {
                    universe.Insert(y, new List<char>(universe[y]));
                    y++;
                }
            }

            for (int x = 0; x < universe[0].Count; x++)
            {
                bool noGalaxies = true;
                for (int y = 0; y < universe.Count; y++)
                {
                    if (universe[y][x] != '.')
                    {
                        noGalaxies = false;
                    }
                }
                if (noGalaxies)
                {
                    for (int y = 0; y < universe.Count; y++)
                    {
                        universe[y].Insert(x, '.');
                    }
                    x++;
                }
            }

            Part1Solution = "TBD";

            Part2Solution = "TBD";
        }
    }
}
