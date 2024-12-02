using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2021
{
    public class Day07 : AoCDay
    {
        override public void Solve()
        {
            int max = int.MinValue;
            int minFuel = int.MaxValue;
            List<int> hpos = new();
            string[] splitted = Input[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in splitted)
            {
                int i = int.Parse(s);
                max = Math.Max(i, max);
                hpos.Add(i);
            }

            for (int i = 0; i <= max; i++)
            {
                int fuel = 0;
                foreach (int p in hpos)
                {
                    fuel += Math.Abs(p - i);
                }
                minFuel = Math.Min(minFuel, fuel);
            }

            Part1Solution = minFuel.ToString();

            minFuel = int.MaxValue;
            for (int i = 0; i <= max; i++)
            {
                int fuel = 0;
                foreach (int p in hpos)
                {
                    int pchange = Math.Abs(p - i);
                    fuel += (pchange * (pchange + 1)) / 2;
                }
                minFuel = Math.Min(minFuel, fuel);
            }

            Part2Solution = minFuel.ToString();
        }
    }
}
