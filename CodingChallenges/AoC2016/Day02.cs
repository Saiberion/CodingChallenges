using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day02 : Challenge
    {
        static string KeypadNormal(List<string> input)
        {
            StringBuilder sb = new();
            Point p = new(1, 1);
            foreach (string line in input)
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case 'U':
                            if (p.Y > 0)
                            {
                                p.Y--;
                            }
                            break;
                        case 'D':
                            if (p.Y < 2)
                            {
                                p.Y++;
                            }
                            break;
                        case 'L':
                            if (p.X > 0)
                            {
                                p.X--;
                            }
                            break;
                        case 'R':
                            if (p.X < 2)
                            {
                                p.X++;
                            }
                            break;
                    }
                }
                int key = p.X + 1 + p.Y * 3;
                sb.Append(key);
            }
            return sb.ToString();
        }

        static string KeypadSpecial(List<string> input)
        {
            Dictionary<Point, char> keypad = new()
            {
                { new Point(0, 0), 'X' },
                { new Point(1, 0), 'X' },
                { new Point(2, 0), '1' },
                { new Point(3, 0), 'X' },
                { new Point(4, 0), 'X' },

                { new Point(0, 1), 'X' },
                { new Point(1, 1), '2' },
                { new Point(2, 1), '3' },
                { new Point(3, 1), '4' },
                { new Point(4, 1), 'X' },

                { new Point(0, 2), '5' },
                { new Point(1, 2), '6' },
                { new Point(2, 2), '7' },
                { new Point(3, 2), '8' },
                { new Point(4, 2), '9' },

                { new Point(0, 3), 'X' },
                { new Point(1, 3), 'A' },
                { new Point(2, 3), 'B' },
                { new Point(3, 3), 'C' },
                { new Point(4, 3), 'X' },

                { new Point(0, 4), 'X' },
                { new Point(1, 4), 'X' },
                { new Point(2, 4), 'D' },
                { new Point(3, 4), 'X' },
                { new Point(4, 4), 'X' }
            };

            Point p = new(0, 2);

            StringBuilder sb = new();

            foreach (string line in input)
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case 'U':
                            if (p.Y > 0)
                            {
                                p.Y--;
                                if (keypad[p] == 'X')
                                {
                                    p.Y++;
                                }
                            }
                            break;
                        case 'D':
                            if (p.Y < 4)
                            {
                                p.Y++;
                                if (keypad[p] == 'X')
                                {
                                    p.Y--;
                                }
                            }
                            break;
                        case 'L':
                            if (p.X > 0)
                            {
                                p.X--;
                                if (keypad[p] == 'X')
                                {
                                    p.X++;
                                }
                            }
                            break;
                        case 'R':
                            if (p.X < 4)
                            {
                                p.X++;
                                if (keypad[p] == 'X')
                                {
                                    p.X--;
                                }
                            }
                            break;
                    }
                }

                sb.Append(keypad[p]);
            }
            return sb.ToString();
        }

        public override void Solve()
        {
            Part1Solution = KeypadNormal(Input);

            Part2Solution = KeypadSpecial(Input);
        }
    }
}
