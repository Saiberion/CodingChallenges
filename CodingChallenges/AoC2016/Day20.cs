using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day20 : Challenge
    {
        static Tuple<long, long> MinimumFreeIP(List<string> input)
        {
            long validIPs = 0;
            long minResult = -1;
            List<long[]> ranges = [];
            foreach (string s in input)
            {
                string[] splitted = s.Split(['-'], StringSplitOptions.RemoveEmptyEntries);
                ranges.Add([long.Parse(splitted[0]), long.Parse(splitted[1])]);
            }

            long minAllowed;

            long minimumBlocked = uint.MaxValue;
            long[] minRange = [];
            foreach (long[] arr in ranges)
            {
                if (minimumBlocked > arr[0])
                {
                    minimumBlocked = arr[0];
                    minRange = arr;
                }
            }

            if (minRange[0] > 0)
            {
                return new Tuple<long, long>(0, 0);
            }
            else
            {
                minAllowed = minRange[1] + 1;
                ranges.Remove(minRange);
            }

            do
            {
                minimumBlocked = uint.MaxValue;
                foreach (long[] arr in ranges)
                {
                    if (minimumBlocked > arr[0])
                    {
                        minimumBlocked = arr[0];
                        minRange = arr;
                    }
                }
                if ((minRange[0] < minAllowed) && (minRange[1] < minAllowed))
                {
                    // ignore, this range is already dead
                    ranges.Remove(minRange);
                }
                else if ((minRange[0] > minAllowed) && (minRange[1] > minAllowed))
                {
                    // no range is starting earlier, result found
                    // could get used for Part 2 counting
                    validIPs += minRange[0] - minAllowed;
                    if (minResult == -1)
                    {
                        minResult = minAllowed;
                    }
                    minAllowed = minRange[1] + 1;
                    ranges.Remove(minRange);
                }
                else
                {
                    // overlapping region
                    minAllowed = minRange[1] + 1;
                    ranges.Remove(minRange);
                }
            } while (ranges.Count > 0);

            return new Tuple<long, long>(minResult, validIPs);
        }

        public override void Solve()
        {
            Tuple<long, long> res = MinimumFreeIP(Input);
            Part1Solution = res.Item1.ToString();

            Part2Solution = res.Item2.ToString();
        }
    }
}
