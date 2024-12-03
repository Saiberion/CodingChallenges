using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2021
{
    public class Day06 : AoCDay
    {
        override public void Solve()
        {
            long allFish;
            long[] lanternFishDays = new long[9];
            string[] splitted = Input[0].Split([','], StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in splitted)
            {
                lanternFishDays[int.Parse(s)]++;
            }

            for (int d = 0; d < 256; d++)
            {
                if (d == 80)
                {
                    allFish = 0;
                    foreach (long l in lanternFishDays)
                    {
                        allFish += l;
                    }
                    Part1Solution = allFish.ToString();
                }
                long tmp = lanternFishDays[0];
                for (int i = 1; i < 9; i++)
                {
                    lanternFishDays[i - 1] = lanternFishDays[i];
                    if (i == 7)
                    {
                        lanternFishDays[i - 1] += tmp;
                    }
                }
                lanternFishDays[8] = tmp;
            }

            allFish = 0;
            foreach (long l in lanternFishDays)
            {
                allFish += l;
            }

            Part2Solution = allFish.ToString();
        }
    }
}
