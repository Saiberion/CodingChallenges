using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2022
{
    public class Day04 : AoCDay
    {
        public override void Solve()
        {
            int includedCounter = 0;
            int overlapCounter = 0;
            int minRange1;
            int maxRange1;
            int minRange2;
            int maxRange2;
            foreach (string s in Input)
            {
                string[] splitted = s.Split(['-', ','], StringSplitOptions.RemoveEmptyEntries);
                minRange1 = int.Parse(splitted[0]);
                maxRange1 = int.Parse(splitted[1]);
                minRange2 = int.Parse(splitted[2]);
                maxRange2 = int.Parse(splitted[3]);

                if (((minRange1 >= minRange2) && (maxRange1 <= maxRange2)) || ((minRange2 >= minRange1) && (maxRange2 <= maxRange1)))
                {
                    includedCounter++;
                }

                if (!((maxRange1 < minRange2) || (maxRange2 < minRange1)))
                {
                    overlapCounter++;
                }
            }
            Part1Solution = includedCounter.ToString();

            Part2Solution = overlapCounter.ToString();
        }
    }
}
