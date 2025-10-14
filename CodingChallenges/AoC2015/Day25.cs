using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day25 : AoCDay
    {
        override public void Solve()
        {
            int row = 2981;
            int col = 3075;
            int r = 1, c = 1;
            int index = 1;
            int maxrow = 1;
            long code = 20151125;

            while (!((r == row) && (c == col)))
            {
                r--;
                c++;
                if (r == 0)
                {
                    c = 1;
                    r = ++maxrow;
                }
                index++;
                code *= 252533;
                code %= 33554393;
            }

            Part1Solution = code.ToString();
            Part2Solution = "Active";
        }
    }
}
