using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day18 : Challenge
    {
        static int TrapRoom(List<string> input, int rows)
        {
            int safeTiles = 0;

            foreach (char c in input[^1])
            {
                if (c == '.')
                {
                    safeTiles++;
                }
            }
            while (input.Count < rows)
            {
                StringBuilder sb = new();

                for (int i = 0; i < input[^1].Length; i++)
                {
                    bool left, center, right;
                    if (i == 0)
                    {
                        left = false;
                    }
                    else
                    {
                        left = input[^1][i - 1] == '^';
                    }
                    center = input[^1][i] == '^';
                    if (i == (input[^1].Length - 1))
                    {
                        right = false;
                    }
                    else
                    {
                        right = input[^1][i + 1] == '^';
                    }

                    if ((!left && !center && right)
                        || (!left && center && right)
                        || (left && !center && !right)
                        || (left && center && !right))
                    {
                        sb.Append('^');
                    }
                    else
                    {
                        sb.Append('.');
                        safeTiles++;
                    }
                }
                input.Add(sb.ToString());
            }

            return safeTiles;
        }

        public override void Solve()
        {
            Part1Solution = TrapRoom(new List<string>(Input), 40).ToString();

            Part2Solution = TrapRoom(new List<string>(Input), 400000).ToString();
        }
    }
}
