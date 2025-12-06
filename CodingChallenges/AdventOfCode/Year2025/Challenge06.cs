using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge06 : Challenge
    {
        public override void Solve()
        {
            List<string[]> mathProblems = [];
            foreach (string line in Input)
            {
                string[] data = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                mathProblems.Add(data);
            }

            long grandTotal = 0;
            long result = 0;
            for (int i = 0; i < mathProblems[0].Length; i++)
            {
                if (mathProblems[^1][i][0] == '+')
                {
                    // addition
                    result = 0;
                    for (int j = 0; j < mathProblems.Count - 1; j++)
                    {
                        result += long.Parse(mathProblems[j][i]);
                    }
                }
                else
                {
                    // multiplication
                    result = 1;
                    for (int j = 0; j < mathProblems.Count - 1; j++)
                    {
                        result *= long.Parse(mathProblems[j][i]);
                    }
                }
                grandTotal += result;
            }

            Part1Solution = grandTotal.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
