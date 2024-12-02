using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2016
{
    public class Day12 : AoCDay
    {
        public override void Solve()
        {
            Part1Solution = Assembunny.ExecuteInstructions(Input, 0, 0, 0, 0).ToString();

            Part2Solution = Assembunny.ExecuteInstructions(Input, 0, 0, 1, 0).ToString();
        }
    }
}
