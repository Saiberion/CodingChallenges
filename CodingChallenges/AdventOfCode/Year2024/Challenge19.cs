using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2024
{
    public class Challenge19 : Challenge
    {
        public override void Solve()
        {
            List<string> towels = [];
            //List<string> patterns = [];
            foreach (string line in Input)
            {
                if (line.Contains(','))
                {
                    foreach (string s in line.Split([','], StringSplitOptions.RemoveEmptyEntries))
                    {
                        towels.Add(s);
                    }
                    towels.Sort();
                }
                else if (!string.IsNullOrEmpty(line))
                {

                }
            }


            Part1Solution = "TBD";

            Part2Solution = "TBD";
        }
    }
}
