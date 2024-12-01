using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
    public class Day17 : AoCDay
    {
        public override void Solve()
        {
            List<int> spinLock = new();
            int currentPosition = 0;
            int valueAt1 = 0;

            // Part 1
            spinLock.Add(0);
            for (int i = 1; i <= 2017; i++)
            {
                currentPosition = (currentPosition + 359) % i + 1;
                spinLock.Insert(currentPosition, i);
            }

            Part1Solution = spinLock[currentPosition + 1].ToString();

            // Part 2
            currentPosition = 0;
            for (int i = 1; i <= 50000000; i++)
            {
                currentPosition = (currentPosition + 359) % i + 1;
                if (currentPosition == 1)
                {
                    valueAt1 = i;
                }
            }

            Part2Solution = valueAt1.ToString();
        }
    }
}
