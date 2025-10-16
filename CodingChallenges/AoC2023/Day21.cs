using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AoC2023
{
    public class Day21 : Challenge
    {
        private static bool IsValidLocation(char[,] g, Point p)
        {
            if ((p.X >= 0) && (p.X < g.GetLength(0)))
            {
                if ((p.Y >= 0) && (p.Y < g.GetLength(1)))
                {
                    if (g[p.X, p.Y] == '.')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static List<Point> GetPossibleNewLocations(char[,] g, Point p)
        {
            List<Point> l = [];
            Point n;

            n = new(p.X + 1, p.Y);
            if (IsValidLocation(g, n))
            {
                l.Add(n);
            }
            n = new(p.X - 1, p.Y);
            if (IsValidLocation(g, n))
            {
                l.Add(n);
            }
            n = new(p.X, p.Y + 1);
            if (IsValidLocation(g, n))
            {
                l.Add(n);
            }
            n = new(p.X, p.Y - 1);
            if (IsValidLocation(g, n))
            {
                l.Add(n);
            }
            return l;
        }

        public override void Solve()
        {
            char[,] garden = new char[Input[0].Length, Input.Count];
            Point startingPosition = new();
            List<Point> reachableTiles = [];

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[0].Length; x++)
                {
                    garden[x, y] = Input[y][x];
                    if (garden[x, y] == 'S')
                    {
                        startingPosition.X = x;
                        startingPosition.Y = y;
                        garden[x, y] = '.';
                    }
                }
            }

            reachableTiles.Add(new(startingPosition.X, startingPosition.Y));

            for (int i = 0; i < 64; i++)
            {
                List<Point> newTiles = [];
                foreach (Point p in reachableTiles)
                {
                    List<Point> possibleLocations = GetPossibleNewLocations(garden, p);
                    foreach (Point n in possibleLocations)
                    {
                        if (!newTiles.Contains(n))
                        {
                            newTiles.Add(n);
                        }
                    }
                }
                reachableTiles = new(newTiles);
            }

            Part1Solution = reachableTiles.Count.ToString();

            Part2Solution = "TBD";
        }
    }
}
