using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2020
{
    public class Day14 : Challenge
    {
        override public void Solve()
        {
            long maskAND = 0, maskOR = 0;
            Dictionary<long, long> memory = [];
            foreach (string s in Input)
            {
                if (s.StartsWith("mask"))
                {
                    string[] splitted = s.Split([" = "], StringSplitOptions.RemoveEmptyEntries);
                    maskOR = Convert.ToInt64(splitted[1].Replace('X', '0'), 2);
                    maskAND = Convert.ToInt64(splitted[1].Replace('X', '1'), 2);
                }
                else
                {
                    string[] splitted = s.Split(['[', ']', ' ', '='], StringSplitOptions.RemoveEmptyEntries);
                    long addr = long.Parse(splitted[1]);
                    long val = (long.Parse(splitted[2]) & maskAND) | maskOR;
                    if (!memory.TryAdd(addr, val))
                    {
                        memory[addr] = val;
                    }
                }
            }

            long sum = 0;
            foreach (KeyValuePair<long, long> kvp in memory)
            {
                sum += kvp.Value;
            }

            Part1Solution = sum.ToString();
            Part2Solution = "TBD";
        }
    }
}
