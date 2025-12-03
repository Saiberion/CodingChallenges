using CodingChallenges;
using CodingChallenges.AdventOfCode.Year2021;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge03 : Challenge
    {
        static private long FindLargestJoltage(string batteryBank,int digits)
        {
            StringBuilder sb = new();

            int scanStart = -1;
            for (int j = 0; j < digits; j++)
            {
                char largestBattery = '0';
                for (int i = (scanStart + 1); i < (batteryBank.Length - digits + 1 + j); i++)
                {
                    if (batteryBank[i] > largestBattery)
                    {
                        largestBattery = batteryBank[i];
                        scanStart = i;
                    }
                }
                sb.Append(largestBattery);
            }

            return long.Parse(sb.ToString());
        }

        public override void Solve()
        {   
            long overallJoltageP1 = 0;
            long overallJoltageP2 = 0;
            foreach (string line in Input)
            {
                overallJoltageP1 += FindLargestJoltage(line, 2);
                overallJoltageP2 += FindLargestJoltage(line, 12);
            }
            Part1Solution = overallJoltageP1.ToString();

            Part2Solution = overallJoltageP2.ToString();

            Part3Solution = "";
        }
    }
}
