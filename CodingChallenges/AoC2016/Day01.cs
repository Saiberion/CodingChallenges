using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day01 : Challenge
    {
        static Point[] FollowDirections(List<string> input)
        {
            HashSet<Point> visitedCoords = [];
            Point[] c = [new(), new()];
            Directions4Way facing = Directions4Way.Up;
            bool c1Set = false;

            visitedCoords.Add(new(0, 0));

            string[] splitted = input[0].Split([',', ' '], StringSplitOptions.RemoveEmptyEntries);

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
                if (!Enum.IsDefined(facing))
                {
                    if ((int)facing > 0)
                    {
                        facing = Directions4Way.Up;
                    }
                    else
                    {
                        facing = Directions4Way.Left;
                    }
                }
                int steps = int.Parse(s.Remove(0, 1));

                while (steps-- > 0)
                {
                    switch (facing)
                    {
                        case Directions4Way.Up:
                            c[0].Y++;
                            break;
                        case Directions4Way.Right:
                            c[0].X++;
                            break;
                        case Directions4Way.Down:
                            c[0].Y--;
                            break;
                        case Directions4Way.Left:
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
