using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode.AoC2022
{
    public class Day09 : AoCDay
    {
        private static void TailFollow(Point[] rope)
        {
            for (int i = 1; i < rope.Length; i++)
            {
                int diffx = rope[i - 1].X - rope[i].X;
                int diffy = rope[i - 1].Y - rope[i].Y;

                if (Math.Abs(diffx) > 1)
                {
                    // diagonal movement
                    rope[i].X += Math.Sign(diffx);
                    rope[i].Y += Math.Sign(diffy);
                }
                else
                {
                    if (Math.Abs(diffy) > 1)
                    {
                        rope[i].Y += Math.Sign(diffy);
                        rope[i].X += Math.Sign(diffx);
                    }
                }
            }
        }

        public int Move(int ropeLength)
        {
            Dictionary<Point, int> tailVisits = [];
            int i;

            Point[] rope = new Point[ropeLength];
            for (i = 0; i < rope.Length; i++)
            {
                rope[i] = new Point(0, 0);
            }
            tailVisits.Add(rope[^1], 1);

            foreach (string s in Input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                switch (splitted[0])
                {
                    case "U":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            rope[0].Y--;
                            TailFollow(rope);
                            if (!tailVisits.ContainsKey(rope[^1]))
                            {
                                tailVisits.Add(rope[^1], 1);
                            }
                        }
                        break;
                    case "D":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            rope[0].Y++;
                            TailFollow(rope);
                            if (!tailVisits.ContainsKey(rope[^1]))
                            {
                                tailVisits.Add(rope[^1], 1);
                            }
                        }
                        break;
                    case "L":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            rope[0].X--;
                            TailFollow(rope);
                            if (!tailVisits.ContainsKey(rope[^1]))
                            {
                                tailVisits.Add(rope[^1], 1);
                            }
                        }
                        break;
                    case "R":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            rope[0].X++;
                            TailFollow(rope);
                            if (!tailVisits.ContainsKey(rope[^1]))
                            {
                                tailVisits.Add(rope[^1], 1);
                            }
                        }
                        break;
                }
            }
            return tailVisits.Keys.Count;
        }

        public override void Solve()
        {
            Part1Solution = Move(2).ToString();

            Part2Solution = Move(10).ToString();
        }
    }
}
