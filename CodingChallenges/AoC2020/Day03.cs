using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2020
{
    public class Day03 : Challenge
    {
        override public void Solve()
        {
            int x;
            int y;
            List<int[]> slopes =
            [
                [1, 1],
                [3, 1],
                [5, 1],
                [7, 1],
                [1, 2]
            ];
            int[] trees = new int[slopes.Count];
            long treemultiply = 1;

            for (int i = 0; i < slopes.Count; i++)
            {
                x = 0;
                y = 0;
                while (true)
                {
                    x = (x + slopes[i][0]) % Input[y].Length;
                    y += slopes[i][1];
                    if (y >= Input.Count)
                    {
                        break;
                    }
                    else
                    {
                        if (Input[y][x] == '#')
                        {
                            trees[i]++;
                        }
                    }
                }
                treemultiply *= trees[i];
            }

            Part1Solution = trees[1].ToString();
            Part2Solution = (treemultiply).ToString();
        }
    }
}
