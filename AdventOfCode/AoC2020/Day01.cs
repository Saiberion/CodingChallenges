using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2020
{
    public class Day01 : AoCDay
    {
        private static string FindMatching2Entries(List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    if (i != j)
                    {
                        if ((l[i] + l[j]) == 2020)
                        {
                            return (l[i] * l[j]).ToString();
                        }
                    }
                }
            }
            return "Error";
        }

        private static string FindMatching3Entries(List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    for (int k = 0; k < l.Count; k++)
                    {
                        if ((i != j) && (j != k))
                        {
                            if ((l[i] + l[j] + l[k]) == 2020)
                            {
                                return (l[i] * l[j] * l[k]).ToString();
                            }
                        }
                    }
                }
            }
            return "Error";
        }

        override public void Solve()
        {
            List<int> accountingList = new();
            foreach (string s in Input)
            {
                accountingList.Add(int.Parse(s));
            }
            Part1Solution = FindMatching2Entries(accountingList);
            Part2Solution = FindMatching3Entries(accountingList);
        }
    }
}
