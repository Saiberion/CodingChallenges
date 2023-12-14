using AdventOfCode;
using AoC2021;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AoC2023
{
    public class Day14 : Day
    {
        private void Tilt(List<List<char>> dish, int direction)
        {
            switch(direction)
            {
                case 0:
                    for (int n = 1; n < dish.Count; n++)
                    {
                        for (int x = 0; x < dish[n].Count; x++)
                        {
                            if (dish[n][x] == 'O')
                            {
                                for (int y = n; y > 0; y--)
                                {
                                    if (dish[y - 1][x] == '.')
                                    {
                                        dish[y - 1][x] = 'O';
                                        dish[y][x] = '.';
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

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
            }

            Tilt(reflectorDish, 0);

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
