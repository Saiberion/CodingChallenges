using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2024
{
    public class Clawmachine
    {
        public Point ADistance;
        public Point BDistance;
        public Point Prize;

        private List<(int a, int b)> winningButtonPresses = [];

        public int MinimumTokensForWin = int.MaxValue;

        public void FindValidButtonPresses()
        {
            winningButtonPresses = [];
            for (int a = 0; a < 100; a++)
            {
                for (int b = 0; b < 100; b++)
                {
                    int x = a * ADistance.X + b * BDistance.X;
                    int y = a * ADistance.Y + b * BDistance.Y;
                    if ((x == Prize.X) && (y == Prize.Y))
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

    public class Day13 : AoCDay
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
                    int x, y;
                    x = int.Parse(splitted[3]);
                    y = int.Parse(splitted[5]);
                    if (splitted[1].Equals("A"))
                    {
                        cm.ADistance.X = x;
                        cm.ADistance.Y = y;
                    }
                    else
                    {
                        cm.BDistance.X = x;
                        cm.BDistance.Y = y;
                    }
                }
                else if (line.StartsWith("Prize"))
                {
                    cm.Prize.X = int.Parse(splitted[2]);
                    cm.Prize.Y = int.Parse(splitted[4]);
                }
                else if (string.IsNullOrEmpty(line))
                {
                    // new clawmachine
                    clawmachines.Add(cm);
                    cm = new();
                }
            }
            clawmachines.Add(cm);

            int tokenUsage = 0;
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
