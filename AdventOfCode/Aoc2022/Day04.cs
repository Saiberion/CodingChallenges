using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day04 : Day
    {
        public override void Solve()
        {
            int includedCounter = 0;
            int overlapCounter = 0;
            foreach(string s in Input)
            {
                string[] splitted = s.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (((int.Parse(splitted[0]) >= int.Parse(splitted[2])) && (int.Parse(splitted[1]) <= int.Parse(splitted[3]))) ||
                   ((int.Parse(splitted[2]) >= int.Parse(splitted[0])) && (int.Parse(splitted[3]) <= int.Parse(splitted[1])))) 
                {
                    includedCounter++;
                }

                if (!((int.Parse(splitted[1]) < int.Parse(splitted[2])) ||
                    (int.Parse(splitted[3]) < int.Parse(splitted[0]))))
                {
                    overlapCounter++;
                }
            }
            Part1Solution = includedCounter.ToString();

            Part2Solution = overlapCounter.ToString();
        }
    }
}
