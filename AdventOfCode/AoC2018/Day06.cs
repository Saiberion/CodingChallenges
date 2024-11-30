using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2018
{
    class Coordinate
    {
        public int Y { get; set; }
        public int X { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Day06 : Day
    {
        static List<Coordinate> GetCoordinates(List<string> input)
        {
            List<Coordinate> result = new();
            foreach (string line in input)
            {
                string[] splitted = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Coordinate coordinate = new(int.Parse(splitted[0]), int.Parse(splitted[1]));
                result.Add(coordinate);
            }
            return result;
        }

        static int GetHighestXCoord(List<Coordinate> coordinates)
        {
            int result = 0;

            foreach (Coordinate c in coordinates)
            {
                if (c.X > result)
                {
                    result = c.X;
                }
            }

            return result + 1;
        }

        static int GetHighestYCoord(List<Coordinate> coordinates)
        {
            int result = 0;

            foreach (Coordinate c in coordinates)
            {
                if (c.Y > result)
                {
                    result = c.Y;
                }
            }

            return result + 1;
        }

        static int CalculateDistance(int row1, int col1, int row2, int col2)
        {
            int distance = Math.Abs(row1 - row2) + Math.Abs(col1 - col2);
            return distance;
        }

        public override void Solve()
        {
            HashSet<int> Infinites = new();


            List<Coordinate> coordinates = GetCoordinates(Input);
            int highestX = GetHighestXCoord(coordinates);
            int highestY = GetHighestYCoord(coordinates);
            int[,] grid = new int[highestY, highestX];

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    int minDistance = Int32.MaxValue;
                    int chosen = 0;

                    for (int k = 0; k < coordinates.Count; k++)
                    {
                        var distance = CalculateDistance(y, x, coordinates[k].Y, coordinates[k].X);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            chosen = k + 1;
                        }
                        else if (minDistance == distance)
                            chosen = -1;
                    }

                    if (y == grid.GetLength(0) - 1 || x == grid.GetLength(1) - 1 || y == 0 || x == 0)
                        Infinites.Add(chosen);

                    grid[y, x] = chosen;
                }
            }

            Dictionary<int, int> AreaSizes = new();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (Infinites.Contains(grid[i, j]))
                        continue;

                    if (!AreaSizes.ContainsKey(grid[i, j]))
                        AreaSizes.Add(grid[i, j], 0);

                    AreaSizes[grid[i, j]] += 1;
                }
            }

            Part1Solution = AreaSizes.OrderByDescending(a => a.Value).First().Value.ToString();

            var result = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    var distance = 0;
                    for (int k = 0; k < coordinates.Count; k++)
                    {
                        distance += CalculateDistance(i, j, coordinates[k].Y, coordinates[k].X);
                    }
                    if (distance < 10000) result += 1;
                }
            }

            Part2Solution = result.ToString();
        }
    }
}
