using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge03 : Challenge
    {
        public override void Solve()
        {
            
            int overallJoltage = 0;
            foreach(string line in Input)
            {
                char largestTenth = '0';
                char largestOneth = '0';
                int indexTenth = 0;
                for (int i = 0; i < (line.Length - 1); i++)
                {
                    if (line[i] > largestTenth)
                    {
                        largestTenth = line[i];
                        indexTenth = i;
                    }
                }
                for (int i = (line.Length - 1); i > indexTenth; i--)
                {
                    if (line[i] > largestOneth)
                    {
                        largestOneth = line[i];
                    }
                }
                string joltage = string.Format("{0}{1}", largestTenth, largestOneth);
                overallJoltage += int.Parse(joltage);
            }
            Part1Solution = overallJoltage.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
