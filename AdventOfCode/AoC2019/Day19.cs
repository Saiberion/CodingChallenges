using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Day19 : Day
    {
        override public void Solve()
        {
            // TODO I did solve part 1 of this but it seems I lost the code
            Part2Solution = "TBD";

            IntCodeComputer ic = new IntCodeComputer(Input[0]);
            Queue<long> input = new Queue<long>();

            long countAffected = 0;
            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 50; x++)
                {
                    input.Enqueue(x);
                    input.Enqueue(y);
                    countAffected += ic.Execute(input);
                }
            }

            Part1Solution = countAffected.ToString();
        }
    }
}
