using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
    public class Day01 : AoCDay
    {
        static int SumUp(string input, int compareSkip)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[(i + compareSkip) % input.Length])
                {
                    result += input[i] - '0';
                }
            }
            return result;
        }

        public override void Solve()
        {
            Part1Solution = SumUp(Input[0], 1).ToString();
            Part2Solution = SumUp(Input[0], Input[0].Length / 2).ToString();
        }
    }
}
