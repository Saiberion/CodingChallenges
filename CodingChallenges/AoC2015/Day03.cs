using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AoC2015
{
    public class Day03 : AoCDay
    {
        override public void Solve()
        {
            Dictionary<Point, int> houses = [];
            int[] x = [0, 0], y = [0, 0];
            int move = 0;

            houses.Add(new Point(x[0], y[0]), 1);

            foreach (string s in Input)
            {
                foreach (char c in s)
                {
                    switch (c)
                    {
                        case '^':
                            y[0]--;
                            break;
                        case 'v':
                            y[0]++;
                            break;
                        case '<':
                            x[0]--;
                            break;
                        case '>':
                            x[0]++;
                            break;
                    }
                    if (!houses.ContainsKey(new Point(x[0], y[0])))
                    {
                        houses.Add(new Point(x[0], y[0]), 1);
                    }
                }
            }
            Part1Solution = houses.Count.ToString();

            x[0] = 0;
            y[0] = 0;
            houses.Clear();
            houses.Add(new Point(x[0], y[0]), 2);

            foreach (string s in Input)
            {
                foreach (char c in s)
                {
                    switch (c)
                    {
                        case '^':
                            y[move]--;
                            break;
                        case 'v':
                            y[move]++;
                            break;
                        case '<':
                            x[move]--;
                            break;
                        case '>':
                            x[move]++;
                            break;
                    }
                    if (!houses.ContainsKey(new Point(x[move], y[move])))
                    {
                        houses.Add(new Point(x[move], y[move]), 1);
                    }
                    move = (move + 1) % 2;
                }
            }
            Part2Solution = houses.Count.ToString();
        }
    }
}
