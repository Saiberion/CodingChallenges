using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2021
{
    public class Day14 : AoCDay
    {
        override public void Solve()
        {
            string polymer = Input[0];
            Dictionary<string, string> polypair = [];

            foreach (string s in Input)
            {
                if (s.Contains(" -> "))
                {
                    string[] splitted = s.Split([" -> "], StringSplitOptions.RemoveEmptyEntries);
                    polypair.Add(splitted[0], splitted[1]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int l = 0; l < (polymer.Length - 1); l += 2)
                {
                    string rule = polymer.Substring(l, 2);
                    polymer = polymer.Insert(l + 1, polypair[rule]);
                }
            }

            Dictionary<char, int> distribution = [];

            foreach (char c in polymer)
            {
                if (distribution.TryGetValue(c, out int value))
                {
                    distribution[c] = ++value;
                }
                else
                {
                    distribution.Add(c, 1);
                }
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int i in distribution.Values)
            {
                min = Math.Min(min, i);
                max = Math.Max(max, i);
            }

            Part1Solution = (max - min).ToString();
            Part2Solution = "TBD";
        }
    }
}
