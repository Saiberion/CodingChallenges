using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2018
{
    public class Day01 : Day
    {
        public override void Solve()
        {
            int result = 0;
            foreach (string s in Input)
            {
                result += int.Parse(s);
            }
            Part1Solution = result.ToString();

            result = 0;
            bool foundDuplicate = false;
            HashSet<int> previousFrequencies = new()
            {
                result
            };
            while (!foundDuplicate)
            {
                foreach (string s in Input)
                {
                    result += int.Parse(s);

                    if (!previousFrequencies.Add(result))
                    {
                        foundDuplicate = true;
                        break;
                    }
                }
            }
            Part2Solution = result.ToString();
        }
    }
}
