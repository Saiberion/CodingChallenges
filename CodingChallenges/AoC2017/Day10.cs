using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2017
{
    public class Day10 : Challenge
    {
        public override void Solve()
        {
            KnotHash knotHash = new();

            Part1Solution = knotHash.GetHashChecksum(Input[0]).ToString();
            Part2Solution = knotHash.GetHashString(Input[0]);
        }
    }
}
