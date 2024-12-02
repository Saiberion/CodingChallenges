using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day02 : AoCDay
    {
        override public void Solve()
        {
            int wrappingPaper = 0;
            int ribbon = 0;
            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> sides = new()
                {
                    int.Parse(splitted[0]),
                    int.Parse(splitted[1]),
                    int.Parse(splitted[2])
                };
                sides.Sort();

                List<int> areas = new()
                {
                    sides[0] * sides[1],
                    sides[0] * sides[2],
                    sides[1] * sides[2]
                };
                areas.Sort();

                wrappingPaper += 3 * areas[0] + 2 * areas[1] + 2 * areas[2];
                ribbon += 2 * sides[0] + 2 * sides[1] + sides[0] * sides[1] * sides[2];
            }
            Part1Solution = wrappingPaper.ToString();
            Part2Solution = ribbon.ToString();
        }
    }
}
