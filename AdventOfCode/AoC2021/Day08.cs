using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day08 : Day
    {
        override public void Solve()
        {
            int countUnique = 0;

            foreach(string s in Input)
            {
                string[] splitted = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitted2 = splitted[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitted3 = splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s2 in splitted2)
                {
                    if ((s2.Length == 2) || (s2.Length == 3) || (s2.Length == 4) || (s2.Length == 7))
                    {
                        countUnique++;
                    }
                }
            }

            Part1Solution = countUnique.ToString();
            Part2Solution = "TBD";
        }
    }
}
