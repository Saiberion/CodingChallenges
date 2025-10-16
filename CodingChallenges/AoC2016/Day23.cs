using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day23 : AoCDay
    {
        static long Factorial(long f)
        {
            if (f == 0)
            {
                return 1;
            }
            else
            {
                return f * Factorial(f - 1);
            }
        }

        public override void Solve()
        {
            /*Part1Solution = Assembunny.ExecuteInstructions(new List<string>(Input), 7, 0, 0, 0).ToString();

            Part2Solution = Assembunny.ExecuteInstructions(new List<string>(Input), 12, 0, 0, 0).ToString();*/

            // By analyzing the asmbunny I found out that the result of the program is a! + (72 * 75)
            Part1Solution = (Factorial(7) + (72L * 75L)).ToString();
            Part2Solution = (Factorial(12) + (72L * 75L)).ToString();
        }
    }
}
