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
            List<long> ingredients = [];

            long countFresh = 0;

            foreach(string line in Input)
            {
                if (line.Length > 0)
                {
                    if (line.Contains('-'))
                    {
                        string[] r = line.Split(['-'], StringSplitOptions.RemoveEmptyEntries);
                        ranges.Add([long.Parse(r[0]), long.Parse(r[1])]);
                    }
                    else
                    {
                        ingredients.Add(long.Parse(line));
                    }
                }
            }

            foreach(long id in ingredients)
            {
                foreach (long[] range in ranges)
                {
                    if ((id >= range[0]) && (id <= range[1]))
                    {
                        countFresh++;
                        break;
                    }
                }
            }

            Part1Solution = countFresh.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
