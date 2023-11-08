using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC2022
{
    public class Day14 : Day
    {
        public override void Solve()
        {
            Dictionary<Point, bool> cave = new();
            int maxy = int.MinValue;
            int spawns = 0;
            Point p;

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                Point lineStart = new(int.Parse(splitted[0]), int.Parse(splitted[1]));
                cave[lineStart] = true;
                maxy = Math.Max(maxy, lineStart.Y);
                for (int i = 2; i < splitted.Length; i += 2)
                {
                    p = new(int.Parse(splitted[i]), int.Parse(splitted[i + 1]));
                    if (lineStart.X == p.X)
                    {
                        int ydiff;
                        if (lineStart.Y < p.Y)
                        {
                            ydiff = 1;
                        }
                        else
                        {
                            ydiff = -1;
                        }
                        for(int y = lineStart.Y; y != p.Y; y += ydiff, maxy = Math.Max(maxy, y))
                        {
                            cave[new(p.X, y)] = true;
                        }
                        cave[p] = true;
                    }
                    else
                    {
                        int xdiff;
                        if (lineStart.X < p.X)
                        {
                            xdiff = 1;
                        }
                        else
                        {
                            xdiff = -1;
                        }
                        for (int x = lineStart.X; x != p.X; x += xdiff)
                        {
                            cave[new(x, p.Y)] = true;
                        }
                        cave[p] = true;
                    }
                    lineStart = p;
                }
            }

            for(p = new(500, 0); p.Y < maxy; )
            {
                if (cave.TryGetValue(new(p.X, p.Y + 1), out _))
                {
                    if (cave.TryGetValue(new(p.X - 1, p.Y + 1), out _))
                    {
                        if (cave.TryGetValue(new(p.X + 1, p.Y + 1), out _))
                        {
                            cave[p] = true;
                            spawns++;
                            p = new(500, 0);
                        }
                        else
                        {
                            p = new(p.X + 1, p.Y + 1);
                        }
                    }
                    else
                    {
                        p = new(p.X - 1, p.Y + 1);
                    }
                }
                else
                {
                    p = new(p.X, p.Y + 1);
                }
            }

            Part1Solution = spawns.ToString();

            for (p = new(500, 0); p.Y < maxy;)
            {
                if (cave.TryGetValue(new(p.X, p.Y + 1), out _))
                {
                    if (cave.TryGetValue(new(p.X - 1, p.Y + 1), out _))
                    {
                        if (cave.TryGetValue(new(p.X + 1, p.Y + 1), out _))
                        {
                            cave[p] = true;
                            spawns++;
                            p = new(500, 0);
                        }
                        else
                        {
                            p = new(p.X + 1, p.Y + 1);
                        }
                    }
                    else
                    {
                        p = new(p.X - 1, p.Y + 1);
                    }
                }
                else
                {
                    p = new(p.X, p.Y + 1);
                }
            }

            Part2Solution = "TBD";
        }
    }
}
