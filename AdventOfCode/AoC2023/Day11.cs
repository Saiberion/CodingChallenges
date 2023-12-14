using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC2023
{
    public class Day11 : Day
    {
        public static int GetDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public override void Solve()
        {
            int sumPaths = 0;
            List<List<char>> universe = new();
            List<Point> galaxies = new();

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

            for (int y = 0; y < universe.Count; y++)
            {
                for(int x = 0; x < universe[y].Count; x++)
                {
                    if (universe[y][x] == '#')
                    {
                        galaxies.Add(new(x, y));
                    }
                }
            }

            for(int i = 0; i < galaxies.Count - 1; i++)
            {
                for(int j = i + 1; j < galaxies.Count; j++)
                {
                    int path = GetDistance(galaxies[i], galaxies[j]);
                    sumPaths += path;
                }
            }

            Part1Solution = sumPaths.ToString();

            Part2Solution = "TBD";
        }
    }
}
