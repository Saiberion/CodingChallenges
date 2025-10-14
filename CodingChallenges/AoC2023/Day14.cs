using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AdventOfCode.AoC2023
{
    public class Day14 : AoCDay
    {
        private static void Tilt(List<List<char>> dish, int direction)
        {
            switch (direction)
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

        private static int GetLoad(List<List<char>> reflectorDish)
        {
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
            return load;
        }

        public override void Solve()
        {
            List<List<char>> reflectorDish = [];

            foreach (string line in Input)
            {
                List<char> reflectorLine = [];
                foreach (char c in line)
                {
                    reflectorLine.Add(c);
                }
                reflectorDish.Add(reflectorLine);
            }

            Tilt(reflectorDish, 0);

            Part1Solution = GetLoad(reflectorDish).ToString();

            Tilt(reflectorDish, 1);
            Tilt(reflectorDish, 2);
            Tilt(reflectorDish, 3);

            /*for (int i = 1; i < 1000000000; i++)
            {
                Tilt(reflectorDish, 0);
                Tilt(reflectorDish, 1);
                Tilt(reflectorDish, 2);
                Tilt(reflectorDish, 3);
            }*/

            Part2Solution = GetLoad(reflectorDish).ToString();
        }
    }
}
