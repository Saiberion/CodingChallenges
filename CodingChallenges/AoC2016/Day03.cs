using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day03 : Challenge
    {
        static int GetPossibleTrianglesByLine(List<string> input)
        {
            int possible = 0;

            foreach (string line in input)
            {
                string[] triangleSides = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(triangleSides[0]);
                int b = int.Parse(triangleSides[1]);
                int c = int.Parse(triangleSides[2]);

                if ((a + b) > c)
                {
                    if ((a + c) > b)
                    {
                        if ((b + c) > a)
                        {
                            possible++;
                        }
                    }
                }
            }

            return possible;
        }

        static int GetPossibleTrianglesByColumn(List<string> input)
        {
            int possible = 0;
            List<int[]> triangleData = [];

            foreach (string line in input)
            {
                string[] triangleSides = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                int[] l = [int.Parse(triangleSides[0]), int.Parse(triangleSides[1]), int.Parse(triangleSides[2])];
                triangleData.Add(l);
            }

            int z = 0;
            int[] triangle = new int[3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < triangleData.Count; y++)
                {
                    triangle[z++] = triangleData[y][x];
                    if (z == 3)
                    {
                        if ((triangle[0] + triangle[1]) > triangle[2])
                        {
                            if ((triangle[0] + triangle[2]) > triangle[1])
                            {
                                if ((triangle[1] + triangle[2]) > triangle[0])
                                {
                                    possible++;
                                }
                            }
                        }
                        z = 0;
                    }
                }
            }

            return possible;
        }

        public override void Solve()
        {
            Part1Solution = GetPossibleTrianglesByLine(Input).ToString();

            Part2Solution = GetPossibleTrianglesByColumn(Input).ToString();
        }
    }
}
