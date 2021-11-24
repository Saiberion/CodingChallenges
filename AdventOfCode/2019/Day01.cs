using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019
{
    public class Day01 : Day
    {
        public Day01()
        {
            Load("2019/inputs/day01.txt");
        }

        int CalculateFuel(int mass, bool morePrecise)
        {
            if (!morePrecise)
            {
                return mass / 3 - 2;
            }
            else
            {
                int f = mass / 3 - 2;
                if (f > 0)
                {
                    f += CalculateFuel(f, morePrecise);
                    return f;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override void Solve()
        {
            int fuel = 0;
            foreach(string s in Input)
            {
                fuel += CalculateFuel(int.Parse(s), false);
            }

            Part1Solution = fuel.ToString();

            fuel = 0;

            foreach (string s in Input)
            {
                
                fuel += CalculateFuel(int.Parse(s), true);
            }

            Part2Solution = fuel.ToString();
        }
    }
}
