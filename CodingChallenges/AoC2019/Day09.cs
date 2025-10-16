﻿using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2019
{
    public class Day09 : Challenge
    {
        override public void Solve()
        {
            IntCodeComputer ic = new(Input[0]);
            Queue<long> input = new();
            input.Enqueue(1);
            Part1Solution = ic.Execute(input).ToString();
            input.Enqueue(2);
            Part2Solution = ic.Execute(input).ToString();
        }
    }
}
