using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    public class Day15 : Day
    {
        public override void Solve()
        {
            string[] initialisationSequence = Input[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int hashCheck = 0;
            foreach (string s in initialisationSequence)
            {
                int hash = 0;
                foreach(char c in s)
                {
                    hash += c;
                    hash *= 17;
                    hash %= 256;
                }
                hashCheck += hash;
            }

            Part1Solution = hashCheck.ToString();

            Part2Solution = "TBD";
        }
    }
}
