using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge05 : Challenge
    {
        public override void Solve()
        {
            List<long[]> ranges = [];
            foreach (string line in Input)
            {
                if (line.Contains('-'))
                {
                    string[] r = line.Split(['-'], StringSplitOptions.RemoveEmptyEntries);
                    ranges.Add([long.Parse(r[0]), long.Parse(r[1])]);
                }
                else if (line.Length > 0)
                {

                }
            }

            Part1Solution = "TBD";

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
