using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;

namespace AoC2023
{
    public class Day18 : AoCDay
    {
        public override void Solve()
        {
            int[,] lagoon = new int[551, 248];
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            Point diggerPos = new(188, 226);
            int area = 0;

            foreach (string line in Input)
            {
                string[] instructions = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int steps = int.Parse(instructions[1]);

                switch (instructions[0])
                {
                    case "U":
                        //diggerPos.Y -= steps;
                        for (int i = steps; i > 0; i--)
                        {
                            diggerPos.Y--;
                            lagoon[diggerPos.X, diggerPos.Y] = 1;
                            area++;
                        }
                        break;
                    case "D":
                        //diggerPos.Y += steps;
                        for (int i = steps; i > 0; i--)
                        {
                            diggerPos.Y++;
                            lagoon[diggerPos.X, diggerPos.Y] = 1;
                            area++;
                        }
                        break;
                    case "L":
                        //diggerPos.X -= steps;
                        for (int i = steps; i > 0; i--)
                        {
                            diggerPos.X--;
                            lagoon[diggerPos.X, diggerPos.Y] = 1;
                            area++;
                        }
                        break;
                    case "R":
                        //diggerPos.X += steps;
                        for (int i = steps; i > 0; i--)
                        {
                            diggerPos.X++;
                            lagoon[diggerPos.X, diggerPos.Y] = 1;
                            area++;
                        }
                        break;
                }

                minX = Math.Min(minX, diggerPos.X);
                minY = Math.Min(minY, diggerPos.Y);
                maxX = Math.Max(maxX, diggerPos.X);
                maxY = Math.Max(maxY, diggerPos.Y);
            }

            Point fillStart = new(maxX / 2, maxY / 2);
            Queue<Point> fillPoints = new();
            fillPoints.Enqueue(fillStart);

            while (fillPoints.Count > 0)
            {
                Point p = fillPoints.Dequeue();
                if (lagoon[p.X, p.Y] == 0)
                {
                    area++;
                    lagoon[p.X, p.Y] = 1;
                    fillPoints.Enqueue(new(p.X + 1, p.Y));
                    fillPoints.Enqueue(new(p.X - 1, p.Y));
                    fillPoints.Enqueue(new(p.X, p.Y + 1));
                    fillPoints.Enqueue(new(p.X, p.Y - 1));
                }
            }

            Part1Solution = area.ToString();

            Part2Solution = "TBD";
        }
    }
}
