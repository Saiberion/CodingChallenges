using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day05 : Day
    {
        override public void Solve()
        {
            List<Line> vents = new();
            int maxX = int.MinValue, maxY = int.MinValue;
            int[,] field;

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                vents.Add(new Line(int.Parse(splitted[0]), int.Parse(splitted[1]), int.Parse(splitted[2]), int.Parse(splitted[3])));
            }

            foreach (Line v in vents)
            {
                maxX = Math.Max(maxX, v.X1);
                maxX = Math.Max(maxX, v.X2);
                maxY = Math.Max(maxY, v.Y1);
                maxY = Math.Max(maxY, v.Y2);
            }
            field = new int[maxX + 1, maxY + 1];

            foreach (Line v in vents)
            {
                if (v.IsHoritontal)
                {
                    if (v.X2 > v.X1)
                    {
                        for (int i = v.X1; i <= v.X2; i++)
                        {
                            field[i, v.Y1]++;
                        }
                    }
                    else
                    {
                        for (int i = v.X2; i <= v.X1; i++)
                        {
                            field[i, v.Y1]++;
                        }
                    }
                }
                if (v.IsVertical)
                {
                    if (v.Y2 > v.Y1)
                    {
                        for (int i = v.Y1; i <= v.Y2; i++)
                        {
                            field[v.X1, i]++;
                        }
                    }
                    else
                    {
                        for (int i = v.Y2; i <= v.Y1; i++)
                        {
                            field[v.X1, i]++;
                        }
                    }
                }
            }

            int dangerzones = 0;
            for (int y = 0; y < field.GetLength(1); y++)
            {
                for (int x = 0; x < field.GetLength(0); x++)
                {
                    if (field[x, y] > 1)
                    {
                        dangerzones++;
                    }
                }
            }

            Part1Solution = dangerzones.ToString();

            foreach (Line v in vents)
            {
                if (v.IsDiagonal)
                {
                    if ((v.X2 > v.X1) && (v.Y2 > v.Y1))
                    {
                        for (int x = v.X1, y = v.Y1; (x <= v.X2) && (y <= v.Y2); x++, y++)
                        {
                            field[x, y]++;
                        }
                    }
                    else if ((v.X2 > v.X1) && (v.Y1 > v.Y2))
                    {
                        for (int x = v.X1, y = v.Y1; (x <= v.X2) && (y >= v.Y2); x++, y--)
                        {
                            field[x, y]++;
                        }
                    }
                    else if ((v.X1 > v.X2) && (v.Y2 > v.Y1))
                    {
                        for (int x = v.X1, y = v.Y1; (x >= v.X2) && (y <= v.Y2); x--, y++)
                        {
                            field[x, y]++;
                        }
                    }
                    else
                    {
                        for (int x = v.X1, y = v.Y1; (x >= v.X2) && (y >= v.Y2); x--, y--)
                        {
                            field[x, y]++;
                        }
                    }
                }
            }

            dangerzones = 0;
            for (int y = 0; y < field.GetLength(1); y++)
            {
                for (int x = 0; x < field.GetLength(0); x++)
                {
                    if (field[x, y] > 1)
                    {
                        dangerzones++;
                    }
                }
            }

            Part2Solution = dangerzones.ToString();
        }
    }
}
