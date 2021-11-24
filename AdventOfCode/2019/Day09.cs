using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019
{
    public class Day09 : Day
    {
        public Day09()
        {
            Load("2019/inputs/day09.txt");
        }

        override public void Solve()
        {
            IntCodeComputer ic = new IntCodeComputer(Input[0]);
            Queue<long> input = new Queue<long>();
            input.Enqueue(1);
            Part1Solution = ic.Execute(input).ToString();
            input.Enqueue(2);
            Part2Solution = ic.Execute(input).ToString();
        }
    }
}
