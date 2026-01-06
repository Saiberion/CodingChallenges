using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge11 : Challenge
    {
        static long PathCount(Dictionary<string, string[]> g, string from, string to, Dictionary<string, long> cache)
        {
            if (!cache.ContainsKey(from))
            {
                if (from == to)
                {
                    cache[from] = 1;
                }
                else
                {
                    long res = 0;
                    foreach (string next in g[from])
                    {
                        res += PathCount(g, next, to, cache);
                    }
                    cache[from] = res;
                }
            }
            return cache[from];
        }

        public override void Solve()
        {
            Dictionary<string, string[]> devices= [];

            foreach (string line in Input)
            {
                string[] devcon = line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries);
                devices.Add(devcon[0], [.. devcon[1..]]);
            }
            devices["out"] = [];
            Part1Solution = PathCount(devices, "you", "out", []).ToString();

            if (UseTestData)
            {
                devices.Clear();
                foreach (string line in TestInput[1])
                {
                    string[] devcon = line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries);
                    devices.Add(devcon[0], [.. devcon[1..]]);
                }
                devices["out"] = [];
            }

            long a = PathCount(devices, "dac", "out", []);
            long b = PathCount(devices, "fft", "dac", []);
            long c = PathCount(devices, "svr", "fft", []);
            long d = PathCount(devices, "fft", "out", []);
            long e = PathCount(devices, "dac", "fft", []);
            long f = PathCount(devices, "svr", "dac", []);

            Part2Solution = ((a * b * c) + (d * e * f)).ToString();

            Part3Solution = "";
        }
    }
}
