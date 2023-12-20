using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class Day14 : Day
    {
        override public void Solve()
        {
            long maskAND = 0, maskOR = 0;
            Dictionary<long, long> memory = new();
            foreach(string s in Input)
            {
                if (s.StartsWith("mask"))
                {
                    string[] splitted = s.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                    maskOR = Convert.ToInt64(splitted[1].Replace('X', '0'), 2);
                    maskAND = Convert.ToInt64(splitted[1].Replace('X', '1'), 2);
                }
                else
                {
                    string[] splitted = s.Split(new char[] { '[', ']', ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    long addr = long.Parse(splitted[1]);
                    long val = (long.Parse(splitted[2]) & maskAND) | maskOR;
                    if (memory.ContainsKey(addr))
                    {
                        memory[addr] = val;
                    }
                    else
                    {
                        memory.Add(addr, val);
                    }
                }
            }

            long sum = 0;
            foreach(KeyValuePair<long, long> kvp in memory)
            {
                sum += kvp.Value;
            }

            Part1Solution = sum.ToString();
            Part2Solution = "TBD";
        }
    }
}
