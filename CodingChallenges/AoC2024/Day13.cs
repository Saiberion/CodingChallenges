using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2024
{
    public class Clawmachine
    {
        public long Ax;
        public long Ay;
        public long Bx;
        public long By;
        public long PrizeX;
        public long PrizeY;

        private List<(long a, long b)> winningButtonPresses = [];

        public long MinimumTokensForWin = long.MaxValue;

        public void FindValidButtonPresses()
        {
            winningButtonPresses = [];
            for (long a = 0; a < 100; a++)
            {
                for (long b = 0; b < 100; b++)
                {
                    long x = a * Ax + b * Bx;
                    long y = a * Ay + b * By;
                    if ((x == PrizeX) && (y == PrizeY))
                    {
                        winningButtonPresses.Add((a, b));
                        MinimumTokensForWin = Math.Min(MinimumTokensForWin, a * 3 + b);
                    }
                }
            }
            if (winningButtonPresses.Count == 0)
            {
                MinimumTokensForWin = 0;
            }
        }
    }

    public class Day13 : Challenge
    {
        public override void Solve()
        {
            List<Clawmachine> clawmachines = [];
            Clawmachine cm = new();

            foreach(string line in Input)
            {
                string[] splitted = line.Split([' ', ':', '+', ',', '='], StringSplitOptions.RemoveEmptyEntries);
                if (line.StartsWith("Button"))
                {
                    long x, y;
                    x = long.Parse(splitted[3]);
                    y = long.Parse(splitted[5]);
                    if (splitted[1].Equals("A"))
                    {
                        cm.Ax = x;
                        cm.Ay = y;
                    }
                    else
                    {
                        cm.Bx = x;
                        cm.By = y;
                    }
                }
                else if (line.StartsWith("Prize"))
                {
                    cm.PrizeX = int.Parse(splitted[2]);
                    cm.PrizeY = int.Parse(splitted[4]);
                }
                else if (string.IsNullOrEmpty(line))
                {
                    // new clawmachine
                    clawmachines.Add(cm);
                    cm = new();
                }
            }
            clawmachines.Add(cm);

            long tokenUsage = 0;
            foreach (Clawmachine c in clawmachines)
            {
                c.FindValidButtonPresses();
                tokenUsage += c.MinimumTokensForWin;
            }


            Part1Solution = tokenUsage.ToString();

            Part2Solution = "TBD";
        }
    }
}
