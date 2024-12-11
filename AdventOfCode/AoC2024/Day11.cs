using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2024
{
    public class Day11 : AoCDay
    {
        public override void Solve()
        {
            List<long> pebbles = [];

            string[] splitted = Input[0].Split([' '], StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in splitted)
            {
                pebbles.Add(long.Parse(s));
            }

            for (int blinks = 0; blinks < 25; blinks++)
            {
                List<long> newPebbles = [];
                foreach (long pebble in pebbles)
                {
                    int digitCount = pebble.ToString().Length;
                    if (pebble == 0)
                    {
                        newPebbles.Add(1);
                    }
                    else if ((digitCount % 2) == 0)
                    {
                        // Zahl aufteilen
                        long left = (long)(pebble / (Math.Pow(10, digitCount / 2)));
                        newPebbles.Add(left);
                        newPebbles.Add((long)(pebble - (left * Math.Pow(10, digitCount / 2))));
                    }
                    else
                    {
                        newPebbles.Add(pebble * 2024);
                    }
                }
                pebbles = newPebbles;
            }

            Part1Solution = pebbles.Count.ToString();

            Part2Solution = "TBD";
        }
    }
}
