﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2022
{
    public class Day01 : AoCDay
    {
        private static int GetCaloriesTopElves(List<int> sortedWeights, int topCount)
        {
            int sum = 0;

            for (int i = 0; i < topCount; i++)
            {
                sum += sortedWeights[i];
            }
            return sum;
        }

        public override void Solve()
        {
            List<int> elves = [];

            int calories = 0;

            foreach (string s in Input)
            {
                if (string.IsNullOrEmpty(s))
                {
                    elves.Add(calories);
                    calories = 0;
                }
                else
                {
                    calories += int.Parse(s);
                }
            }

            elves.Sort();
            elves.Reverse();

            Part1Solution = GetCaloriesTopElves(elves, 1).ToString();

            Part2Solution = GetCaloriesTopElves(elves, 3).ToString();
        }
    }
}
