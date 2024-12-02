using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day10 : AoCDay
    {
        static string LookAndSay(string origin, int iterations)
        {
            StringBuilder sb = new();
            for (int iter = 0; iter < iterations; iter++)
            {
                for (int i = 0; i < origin.Length; i++)
                {
                    int j;
                    char see = origin[i];
                    int count = 1;
                    for (j = i + 1; j < origin.Length; j++)
                    {
                        if (see == origin[j])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    i = j - 1;
                    sb.Append(count);
                    sb.Append(see);
                }
                origin = sb.ToString();
                sb.Clear();
            }
            return origin;
        }

        override public void Solve()
        {
            string origin = Input[0];

            origin = LookAndSay(origin, 40).ToString();
            Part1Solution = origin.Length.ToString();
            origin = LookAndSay(origin, 10).ToString();
            Part2Solution = origin.Length.ToString();
        }
    }
}
