using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2021
{
    public class Day09 : AoCDay
    {
        override public void Solve()
        {
            List<int[]> basins = new();
            int y = Input.Count;
            int x = Input[0].Length;
            int risklevel = 0;

            int[,] heightMap = new int[x, y];

            for (y = 0; y < heightMap.GetLength(1); y++)
            {
                for (x = 0; x < heightMap.GetLength(0); x++)
                {
                    heightMap[x, y] = int.Parse(Input[y][x].ToString());
                }
            }

            for (y = 0; y < heightMap.GetLength(1); y++)
            {
                for (x = 0; x < heightMap.GetLength(0); x++)
                {
                    bool isLowPoint = true;
                    if (x > 0)
                    {
                        if (heightMap[x - 1, y] <= heightMap[x, y])
                        {
                            continue;
                        }
                    }
                    if (y > 0)
                    {
                        if (heightMap[x, y - 1] <= heightMap[x, y])
                        {
                            continue;
                        }
                    }
                    if (x < (heightMap.GetLength(0) - 1))
                    {
                        if (heightMap[x + 1, y] <= heightMap[x, y])
                        {
                            continue;
                        }
                    }
                    if (y < (heightMap.GetLength(1) - 1))
                    {
                        if (heightMap[x, y + 1] <= heightMap[x, y])
                        {
                            continue;
                        }
                    }

                    if (isLowPoint)
                    {
                        basins.Add(new int[] { x, y });
                        risklevel += heightMap[x, y] + 1;
                    }
                }
            }

            Part1Solution = risklevel.ToString();

            List<int> basinAreas = new();

            foreach (int[] baspos in basins)
            {
                Stack<int[]> flood = new();
                flood.Push(baspos);

                int area = 0;
                while (flood.Count > 0)
                {
                    int[] fillpos = flood.Pop();
                    if ((fillpos[0] >= 0) && (fillpos[0] < heightMap.GetLength(0)) &&
                        (fillpos[1] >= 0) && (fillpos[1] < heightMap.GetLength(1)))
                    {
                        if ((heightMap[fillpos[0], fillpos[1]] >= 0) && (heightMap[fillpos[0], fillpos[1]] < 9))
                        {
                            area++;
                            heightMap[fillpos[0], fillpos[1]] += 10;
                            flood.Push(new int[] { fillpos[0] - 1, fillpos[1] });
                            flood.Push(new int[] { fillpos[0] + 1, fillpos[1] });
                            flood.Push(new int[] { fillpos[0], fillpos[1] - 1 });
                            flood.Push(new int[] { fillpos[0], fillpos[1] + 1 });
                        }
                    }
                }
                basinAreas.Add(area);
            }
            basinAreas.Sort();
            basinAreas.Reverse();

            Part2Solution = (basinAreas[0] * basinAreas[1] * basinAreas[2]).ToString();
        }
    }
}
