using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge09 : Challenge
    {
        public override void Solve()
        {
            List<Coordinate2D> redTiles = [];
            foreach (string line in Input)
            {
                string[] coords = line.Split([','], StringSplitOptions.RemoveEmptyEntries);
                redTiles.Add(new(long.Parse(coords[0]), long.Parse(coords[1])));
            }

            long maxArea = long.MinValue;

            for (int i = 0; i < redTiles.Count - 1; i++)
            {
                for (int j = i + 1; j < redTiles.Count; j++)
                {
                    long newArea = (Math.Abs(redTiles[i].X - redTiles[j].X) + 1) * (Math.Abs(redTiles[i].Y - redTiles[j].Y) + 1);
                    if (newArea > maxArea)
                    {
                        maxArea = newArea;
                    }
                }
            }

            Part1Solution = maxArea.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
