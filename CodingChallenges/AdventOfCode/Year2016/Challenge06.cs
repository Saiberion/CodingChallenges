using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2016
{
    public class Challenge06 : Challenge
    {
        public override void Solve()
        {
            StringBuilder sbP1 = new();
            StringBuilder sbP2 = new();

            Dictionary<char, int>[] charCountingByPosition = new Dictionary<char, int>[Input[0].Length];

            for (int i = 0; i < Input[0].Length; i++)
            {
                charCountingByPosition[i] = [];
            }

            foreach (string s in Input)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (charCountingByPosition[i].TryGetValue(s[i], out int value))
                    {
                        charCountingByPosition[i][s[i]] = ++value;
                    }
                    else
                    {
                        charCountingByPosition[i].Add(s[i], 1);
                    }
                }
            }

            for (int i = 0; i < charCountingByPosition.Length; i++)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                char c1 = char.MinValue;
                char c2 = char.MinValue;
                foreach (KeyValuePair<char, int> kvp in charCountingByPosition[i])
                {
                    if (kvp.Value > max)
                    {
                        c1 = kvp.Key;
                        max = kvp.Value;
                    }

                    if (kvp.Value < min)
                    {
                        c2 = kvp.Key;
                        min = kvp.Value;
                    }
                }
                sbP1.Append(c1);
                sbP2.Append(c2);
            }
            Part1Solution = sbP1.ToString();
            Part2Solution = sbP2.ToString();
        }
    }
}
