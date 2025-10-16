﻿using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2019
{
    public class Day05 : Challenge
    {
        override public void Solve()
        {
            IntCodeComputer ic = new(Input[0]);
            Queue<long> input = new();
            input.Enqueue(1);
            Part1Solution = ic.Execute(input).ToString();
            input.Enqueue(5);
            Part2Solution = ic.Execute(input).ToString();
        }
    }
}
