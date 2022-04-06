using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2015
{
    public class Day20: Day
    {
        override public void Solve()
        {
            int thresholdPresents = int.Parse(Input[0]);

            int[] houses = new int[thresholdPresents / 10];

            int min = int.MaxValue;
            for (int i = 1; i < houses.Length; i++)
            {
                for (int j = i; j < houses.Length; j += i)
                {
                    houses[j] += i * 10;
                    if (houses[j] >= thresholdPresents)
                    {
                        min = Math.Min(min, j);
                    }
                }
            }
            Part1Solution = min.ToString();

            int[] houses2 = new int[thresholdPresents * 2];
            for (int i = 1; i < houses2.Length; i++)
            {
                for (int x = 0; x < i * 50; x += i)
                {
                    houses2[x] += i * 11;
                    if (houses2[i] >= thresholdPresents)
                    {
                        Part2Solution = i.ToString();
                        return;
                    }
                }
            }
        }
    }
}
