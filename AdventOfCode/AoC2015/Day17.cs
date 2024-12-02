using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day17 : AoCDay
    {
        private static readonly List<List<int>> combinations = new();

        private static void SumUpRecursive(List<int> numbers, int target, List<int> partial)
        {
            int s = 0;
            foreach (int x in partial) s += x;

            if (s == target)
            {
                combinations.Add(new List<int>(partial));
            }

            if (s >= target)
            {
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }

                List<int> partial_rec = new(partial)
                {
                    n
                };
                SumUpRecursive(remaining, target, partial_rec);
            }
        }

        private static void SumUp(List<int> numbers, int target)
        {
            SumUpRecursive(numbers, target, new List<int>());
        }

        override public void Solve()
        {
            int target = 150;
            List<int> bottles = new();
            foreach (string s in Input)
            {
                bottles.Add(int.Parse(s));
            }

            SumUp(bottles, target);
            Part1Solution = combinations.Count.ToString();

            int minContainer = int.MaxValue;
            foreach (List<int> l in combinations)
            {
                minContainer = Math.Min(minContainer, l.Count);
            }

            for (int i = 0; i < combinations.Count; i++)
            {
                if (combinations[i].Count != minContainer)
                {
                    combinations.RemoveAt(i);
                    i--;
                    continue;
                }
            }

            Part2Solution = combinations.Count.ToString();
        }
    }
}
