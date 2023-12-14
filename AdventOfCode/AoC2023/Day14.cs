using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AoC2023
{
    public class Day14 : Day
    {
        public override void Solve()
        {
            List<List<char>> reflectorDish = new();

            foreach (string line in Input)
            {
                List<char> reflectorLine = new();
                foreach (char c in line)
                {
                    reflectorLine.Add(c);
                }
                reflectorDish.Add(reflectorLine);

                if (reflectorDish.Count != 0)
                {
                    for (int x = 0; x < line.Length; x++)
                    {
                        if (line[x] == 'O')
                        {
                            for (int y = reflectorDish.Count - 1; y > 0; y--)
                            {
                                if (reflectorDish[y - 1][x] == '.')
                                {
                                    reflectorDish[y][x] = '.';
                                    reflectorDish[y - 1][x] = 'O';
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            int load = 0;
            for (int i = 0; i < reflectorDish.Count; i++)
            {
                int roundrock = 0;
                foreach (char c in reflectorDish[i])
                {
                    if (c == 'O')
                    {
                        roundrock++;
                    }
                }
                load += (reflectorDish.Count - i) * roundrock;
            }

            Part1Solution = load.ToString();

            Part2Solution = "TBD";
        }
    }
}
