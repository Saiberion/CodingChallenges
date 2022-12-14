using AdventOfCode;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC2022
{
    public class Day09 : Day
    {
        private void TailFollow(Point h,ref Point t)
        {
            if ((h.X - t.X) < -1)
            {
                t.X--;
                if (h.Y != t.Y)
                {
                    t.Y = h.Y;
                }
            }
            else if ((h.X - t.X) > 1)
            {
                t.X++;
                if (h.Y != t.Y)
                {
                    t.Y = h.Y;
                }
            }
            else
            {
                if ((h.Y - t.Y) < -1)
                {
                    t.Y--;
                    if (h.X != t.X)
                    {
                        t.X = h.X;
                    }
                }
                else if ((h.Y - t.Y) > 1)
                {
                    t.Y++;
                    if (h.X != t.X)
                    {
                        t.X = h.X;
                    }
                }
            }
        }

        public override void Solve()
        {
            Dictionary<Point, int> tailVisits = new();
            int i;
            Point head = new(0, 0);
            Point tail = new(0, 0);

            tailVisits.Add(tail, 1);

            foreach(string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch(splitted[0])
                {
                    case "U":
                        for(i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            head.Y--;
                            TailFollow(head, ref tail);
                            if (!tailVisits.ContainsKey(tail))
                            {
                                tailVisits.Add(tail, 1);
                            }
                        }
                        break;
                    case "D":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            head.Y++;
                            TailFollow(head, ref tail);
                            if (!tailVisits.ContainsKey(tail))
                            {
                                tailVisits.Add(tail, 1);
                            }
                        }
                        break;
                    case "L":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            head.X--;
                            TailFollow(head, ref tail);
                            if (!tailVisits.ContainsKey(tail))
                            {
                                tailVisits.Add(tail, 1);
                            }
                        }
                        break;
                    case "R":
                        for (i = 0; i < int.Parse(splitted[1]); i++)
                        {
                            head.X++;
                            TailFollow(head, ref tail);
                            if (!tailVisits.ContainsKey(tail))
                            {
                                tailVisits.Add(tail, 1);
                            }
                        }
                        break;
                }
            }

            Part1Solution = tailVisits.Keys.Count.ToString();

            Part2Solution = "TBD";
        }
    }
}
