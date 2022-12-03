using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day03 : Day
    {
        private int GetPriority(char c)
        {
            if (char.IsLower(c))
            {
                return c - 96;
            }
            else
            {
                return c - 64 + 26;
            }
        }

        public override void Solve()
        {
            int prioritySum = 0;
            foreach(string s in Input)
            {
                string compartment1 = s.Substring(0, s.Length / 2);
                string compartment2 = s.Substring(s.Length / 2, s.Length / 2);

                foreach(char c in compartment1)
                {
                    if (compartment2.Contains(c))
                    {
                        prioritySum += GetPriority(c);
                        break;
                    }
                }
            }

            Part1Solution = prioritySum.ToString();

            prioritySum = 0;
            for (int i = 0; i < Input.Count; i += 3)
            {
                foreach (char c in Input[i])
                {
                    if (Input[i + 1].Contains(c) && Input[i + 2].Contains(c))
                    {
                        prioritySum += GetPriority(c);
                        break;
                    }
                }
            }

            Part2Solution = prioritySum.ToString();
        }
    }
}
