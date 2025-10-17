using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2024
{
    public class Challenge11 : Challenge
    {
        public override void Solve()
        {
            List<long> pebbles = [];

            string[] splitted = Input[0].Split([' '], StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in splitted)
            {
                pebbles.Add(long.Parse(s));
            }

            // still have to find a mathematical way to calculate the number of pebbles after each blink to solve for part 2
            // because brute forcing part 2 needs probably more RAM than any consumer machine at this time has.
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
                    else if (digitCount % 2 == 0)
                    {
                        // Zahl aufteilen
                        long left = (long)(pebble / Math.Pow(10, digitCount / 2));
                        newPebbles.Add(left);
                        newPebbles.Add((long)(pebble - left * Math.Pow(10, digitCount / 2)));
                    }
                    else
                    {
                        newPebbles.Add(pebble * 2024);
                    }
                }
                pebbles = newPebbles;
                if (blinks == 24)
                {
                    Part1Solution = pebbles.Count.ToString();
                }
            }

            Part2Solution = pebbles.Count.ToString();
        }
    }
}
