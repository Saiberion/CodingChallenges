using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.AoC2016
{
    class Location2
    {
        public int X;
        public int Y;
        public string Movement = "";
    }

    public class Day17 : AoCDay
    {
        static List<Location2> GetWalkableAdjacentSquares(int x, int y, string input, string movement)
        {
            byte[] hash = MD5.HashData(Encoding.ASCII.GetBytes(input + movement));

            List<Location2> possibleLocations = [];

            if ((((hash[0] >> 4) & 0xf) > 10) && (y > 0))
            {
                possibleLocations.Add(new Location2 { X = x, Y = y - 1, Movement = movement + "U" });
            }
            if (((hash[0] & 0xf) > 10) && (y < 3))
            {
                possibleLocations.Add(new Location2 { X = x, Y = y + 1, Movement = movement + "D" });
            }
            if ((((hash[1] >> 4) & 0xf) > 10) && (x > 0))
            {
                possibleLocations.Add(new Location2 { X = x - 1, Y = y, Movement = movement + "L" });
            }
            if (((hash[1] & 0xf) > 10) && (x < 3))
            {
                possibleLocations.Add(new Location2 { X = x + 1, Y = y, Movement = movement + "R" });
            }

            return possibleLocations;
        }

        static Tuple<string?, int> MazeRunner(string passcode)
        {
            Location2 current;
            Location2 start = new() { X = 0, Y = 0 };
            Location2 target = new() { X = 3, Y = 3 };
            List<Location2> openList =
            [
                // add the starting position to the open list
                start
            ];
            List<Location2> targetList = [];

            while (openList.Count > 0)
            {
                // get the square with the lowest F score from openList
                current = openList[0];

                // remove it from the open list
                openList.Remove(current);

                if ((current.X == target.X) && (current.Y == target.Y))
                {
                    // store result
                    targetList.Add(current);
                    continue;
                }

                List<Location2> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, passcode, current.Movement);

                foreach (Location2 adjacentSquare in adjacentSquares)
                {
                    openList.Add(adjacentSquare);
                }
            }

            string? shortest = null;
            int mostSteps = int.MinValue;
            foreach (Location2 l in targetList)
            {
                if ((shortest == null) || (l.Movement.Length < shortest.Length))
                {
                    shortest = l.Movement;
                }
                if (l.Movement.Length > mostSteps)
                {
                    mostSteps = l.Movement.Length;
                }
            }

            return new Tuple<string?, int>(shortest, mostSteps);
        }

        public override void Solve()
        {
            Tuple<string?, int> result = MazeRunner(Input[0]);
            if (result.Item1 != null)
            {
                Part1Solution = result.Item1.ToString();
            }
            else
            {
                Part1Solution = "Error";
            }

            Part2Solution = result.Item2.ToString();
        }
    }
}
