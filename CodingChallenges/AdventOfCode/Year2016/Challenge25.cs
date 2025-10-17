using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2016
{
    public class Challenge25 : Challenge
    {
        public override void Solve()
        {
            int i = 0;
            do
            {
                Console.WriteLine("Antenne input {0}", i);
            }
            while (Assembunny.ExecuteInstructions(Input, i++, 0, 0, 0) == 0);
            Part1Solution = (--i).ToString();

            Part2Solution = "Active";
        }
    }
}
