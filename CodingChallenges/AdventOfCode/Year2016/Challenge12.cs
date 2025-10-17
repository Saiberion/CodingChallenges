using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2016
{
    public class Challenge12 : Challenge
    {
        public override void Solve()
        {
            Part1Solution = Assembunny.ExecuteInstructions(Input, 0, 0, 0, 0).ToString();

            Part2Solution = Assembunny.ExecuteInstructions(Input, 0, 0, 1, 0).ToString();
        }
    }
}
