using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC2016
{
    public class Day01 : Day
    {
        Point[] FollowDirections(List<string> input)
        {
            HashSet<Point> visitedCoords = new HashSet<Point>();
            Point[] c = new Point[2];
            c[0] = new Point();
            c[1] = new Point();
            int facing = 0;
            bool c1Set = false;

            visitedCoords.Add(new Point(0, 0));

            string[] splitted = input[0].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in splitted)
            {
                switch (s[0])
                {
                    case 'R':
                        facing++;
                        break;
                    case 'L':
                        facing--;
                        break;
                }
                if (facing > 3)
                {
                    facing = 0;
                }
                if (facing < 0)
                {
                    facing = 3;
                }
                int steps = int.Parse(s.Remove(0, 1));

                while (steps-- > 0)
                {
                    switch (facing)
                    {
                        case 0:
                            c[0].Y++;
                            break;
                        case 1:
                            c[0].X++;
                            break;
                        case 2:
                            c[0].Y--;
                            break;
                        case 3:
                            c[0].X--;
                            break;
                    }
                    if (!c1Set)
                    {
                        if (!visitedCoords.Add(c[0]))
                        {
                            c[1].X = c[0].X;
                            c[1].Y = c[0].Y;
                            c1Set = true;
                        }
                    }
                }
            }

            return c;
        }

        public override void Solve()
        {
            Point[] c = FollowDirections(Input);
            Part1Solution = (Math.Abs(c[0].X) + Math.Abs(c[0].Y)).ToString();

            Part2Solution = (Math.Abs(c[1].X) + Math.Abs(c[1].Y)).ToString();
        }
    }
}
