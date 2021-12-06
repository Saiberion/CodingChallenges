using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day06 : Day
    {
        override public void Solve()
        {
            List<int> lanternFish = new List<int>();
            string[] splitted = Input[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string s in splitted)
            {
                lanternFish.Add(int.Parse(s));
            }

            for(int d = 0; d < 80; d++)
            {
                List<int> newfish = new List<int>();
                for(int f = 0; f < lanternFish.Count; f++)
                {
                    if (--lanternFish[f] < 0)
                    {
                        lanternFish[f] = 6;
                        newfish.Add(8);
                    }
                }
                lanternFish.AddRange(newfish);
            }

            Part1Solution = lanternFish.Count.ToString();
            Part2Solution = "TBD";
        }
    }
}
