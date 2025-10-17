using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2021
{
    public class Challenge01 : Challenge
    {
        override public void Solve()
        {
            int curr;
            int prev = int.Parse(Input[0]);
            int increased = 0;

            for (int i = 0; i < Input.Count; i++)
            {
                curr = int.Parse(Input[i]);
                if (curr > prev)
                {
                    increased++;
                }
                prev = curr;
            }

            Part1Solution = increased.ToString();

            increased = 0;
            prev = int.Parse(Input[0]);
            for (int i = 1; i < Input.Count; i++)
            {
                if (i < 3)
                {
                    prev += int.Parse(Input[i]);
                }
                else
                {
                    curr = prev - int.Parse(Input[i - 3]) + int.Parse(Input[i]);
                    if (curr > prev)
                    {
                        increased++;
                    }
                    prev = curr;
                }
            }

            Part2Solution = increased.ToString();
        }
    }
}
