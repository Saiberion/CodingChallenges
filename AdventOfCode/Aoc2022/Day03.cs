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
            int prioritySumP1 = 0;
            int prioritySumP2 = 0;

            for (int i = 0; i < Input.Count; i++)
            {
                string compartment1 = Input[i].Substring(0, Input[i].Length / 2);
                string compartment2 = Input[i].Substring(Input[i].Length / 2, Input[i].Length / 2);

                foreach(char c in compartment1)
                {
                    if (compartment2.Contains(c))
                    {
                        prioritySumP1 += GetPriority(c);
                        break;
                    }
                }

                if ((i % 3) == 0)
                {
                    foreach (char c in Input[i])
                    {
                        if (Input[i + 1].Contains(c) && Input[i + 2].Contains(c))
                        {
                            prioritySumP2 += GetPriority(c);
                            break;
                        }
                    }
                }
            }

            Part1Solution = prioritySumP1.ToString();

            Part2Solution = prioritySumP2.ToString();
        }
    }
}
