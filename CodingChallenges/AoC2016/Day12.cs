using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day12 : Challenge
    {
        public override void Solve()
        {
            Part1Solution = Assembunny.ExecuteInstructions(Input, 0, 0, 0, 0).ToString();

            Part2Solution = Assembunny.ExecuteInstructions(Input, 0, 0, 1, 0).ToString();
        }
    }
}
