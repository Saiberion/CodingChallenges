using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
    public class Day10 : Day
    {
        public override void Solve()
        {
            KnotHash knotHash = new KnotHash();

            Part1Solution = knotHash.GetHashChecksum(Input[0]).ToString();
            Part2Solution = knotHash.GetHashString(Input[0]);
        }
    }
}
