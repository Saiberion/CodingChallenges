using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2022
{
    public class Day08 : AoCDay
    {
        private int[] AnalyzePlantation(int[,] plantation)
        {
            int visibleTrees = 0;
            int maxScenicScore = int.MinValue;
            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if ((x == 0) || (y == 0) || (x == (Input[y].Length - 1)) || (y == (Input.Count - 1)))
                    {
                        visibleTrees++;
                        plantation[x, y] = 0;
                    }
                    else
                    {
                        int x1, x2, y1, y2;
                        int distanceLeft = 0, distanceRight = 0, distanceUp = 0, distanceDown = 0;
                        bool visibleLeft = true, visibleRight = true, visibleUp = true, visibleDown = true;

                        for (x1 = x - 1; x1 >= 0; x1--)
                        {
                            distanceLeft++;
                            if (Input[y][x1] >= Input[y][x])
                            {
                                // view blocked
                                visibleLeft = false;
                                break;
                            }
                        }

                        for (x2 = x + 1; x2 < Input[y].Length; x2++)
                        {
                            distanceRight++;
                            if (Input[y][x2] >= Input[y][x])
                            {
                                // view blocked
                                visibleRight = false;
                                break;
                            }
                        }

                        for (y1 = y - 1; y1 >= 0; y1--)
                        {
                            distanceUp++;
                            if (Input[y1][x] >= Input[y][x])
                            {
                                // view blocked
                                visibleUp = false;
                                break;
                            }
                        }

                        for (y2 = y + 1; y2 < Input.Count; y2++)
                        {
                            distanceDown++;
                            if (Input[y2][x] >= Input[y][x])
                            {
                                // view blocked
                                visibleDown = false;
                                break;
                            }
                        }

                        if (visibleLeft || visibleRight || visibleUp || visibleDown)
                        {
                            visibleTrees++;
                        }
                        plantation[x, y] = distanceLeft * distanceRight * distanceUp * distanceDown;
                        maxScenicScore = Math.Max(maxScenicScore, plantation[x, y]);
                    }
                }
            }
            return new int[] { visibleTrees, maxScenicScore };
        }

        public override void Solve()
        {
            int[,] plantation = new int[Input[0].Length, Input.Count];

            int[] results = AnalyzePlantation(plantation);

            Part1Solution = results[0].ToString();

            Part2Solution = results[1].ToString();
        }
    }
}
