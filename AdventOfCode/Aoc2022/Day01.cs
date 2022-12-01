using AdventOfCode;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day01 : Day
    {
        private static int SumUp(List<int> backpack)
        {
            int c = 0;
            foreach(int i in backpack)
            {
                c += i;
            }
            return c;
        }

        private int GetCaloriesTopElves(List<int> sortedWeights, int topCount)
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
            List<List<int>> elves = new();
            List<int> backpack = new();
            List<int> totalCalories = new();

            foreach (string s in Input)
            {
                if (string.IsNullOrEmpty(s))
                {
                    elves.Add(backpack);
                    backpack = new List<int>();
                }
                else
                {
                    backpack.Add(int.Parse(s));
                }
            }

            foreach(List<int> e in elves)
            {
                int cal = SumUp(e);
                totalCalories.Add(cal);
            }

            totalCalories.Sort();
            totalCalories.Reverse();

            Part1Solution = GetCaloriesTopElves(totalCalories, 1).ToString();

            Part2Solution = GetCaloriesTopElves(totalCalories, 3).ToString();
        }
    }
}
