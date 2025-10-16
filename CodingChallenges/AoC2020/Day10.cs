using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2020
{
    public class Day10 : AoCDay
    {
        override public void Solve()
        {
            List<int> adapters = [];
            int diff1 = 0, diff3 = 1;
            List<int> differences = [];
            List<int> oneblocks = [];
            int count = 0;
            int[] combinations = [1, 2, 4, 7];
            long totalCombinations = 1;

            foreach (string s in Input)
            {
                adapters.Add(int.Parse(s));
            }
            adapters.Add(0);
            adapters.Sort();

            for (int i = 0; i < (adapters.Count - 1); i++)
            {
                differences.Add(adapters[i + 1] - adapters[i]);
                switch (adapters[i + 1] - adapters[i])
                {
                    case 1:
                        diff1++;
                        count++;
                        break;
                    case 3:
                        oneblocks.Add(count);
                        count = 0;
                        diff3++;
                        break;
                }
            }
            oneblocks.Add(count);

            foreach (int i in oneblocks)
            {
                if (i > 0)
                {
                    totalCombinations *= combinations[i - 1];
                }
            }

            Part1Solution = (diff1 * diff3).ToString();
            Part2Solution = totalCombinations.ToString(); ;
        }
    }
}
