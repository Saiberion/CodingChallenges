using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode.AoC2023
{
    public class Day11 : AoCDay
    {
        public static int GetDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public static long GetSumOfDistances(List<List<char>> universe, int expansion)
        {
            long sumPaths = 0;
            List<Point> galaxies = [];

            // get galaxy coordinates
            for (int y = 0; y < universe.Count; y++)
            {
                for (int x = 0; x < universe[y].Count; x++)
                {
                    if (universe[y][x] == '#')
                    {
                        galaxies.Add(new(x, y));
                    }
                }
            }

            // universe expansion part 1
            for (int y = universe.Count - 1; y >= 0; y--)
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
                    for (int g = 0; g < galaxies.Count; g++)
                    {
                        if (galaxies[g].Y > y)
                        {
                            Point p = galaxies[g];
                            p.Y += expansion;
                            galaxies.RemoveAt(g);
                            galaxies.Insert(g, p);
                        }
                    }
                }
            }

            // universe expansion part 2
            for (int x = universe[0].Count - 1; x >= 0; x--)
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
                    for (int g = 0; g < galaxies.Count; g++)
                    {
                        if (galaxies[g].X > x)
                        {
                            Point p = galaxies[g];
                            p.X += expansion;
                            galaxies.RemoveAt(g);
                            galaxies.Insert(g, p);
                        }
                    }
                }
            }

            // get all distances
            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    int path = GetDistance(galaxies[i], galaxies[j]);
                    sumPaths += path;
                }
            }
            return sumPaths;
        }

        public override void Solve()
        {
            List<List<char>> universe = [];

            // Build universe map
            foreach (string line in Input)
            {
                List<char> mapLine = [];
                foreach (char c in line)
                {
                    mapLine.Add(c);
                }
                universe.Add(mapLine);
            }

            Part1Solution = GetSumOfDistances(universe, 1).ToString();

            Part2Solution = GetSumOfDistances(universe, 999999).ToString();
        }
    }
}
