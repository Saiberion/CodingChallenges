using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2021
{
    public class Day02 : Challenge
    {
        override public void Solve()
        {
            int depth = 0;
            int movpos = 0;

            foreach (string s in Input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                switch (splitted[0])
                {
                    case "forward":
                        movpos += int.Parse(splitted[1]);
                        break;
                    case "up":
                        depth -= int.Parse(splitted[1]);
                        break;
                    case "down":
                        depth += int.Parse(splitted[1]);
                        break;

                }
            }

            Part1Solution = (depth * movpos).ToString();

            depth = 0;
            movpos = 0;
            int aim = 0;

            foreach (string s in Input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                switch (splitted[0])
                {
                    case "forward":
                        movpos += int.Parse(splitted[1]);
                        depth += aim * int.Parse(splitted[1]);
                        break;
                    case "up":
                        aim -= int.Parse(splitted[1]);
                        break;
                    case "down":
                        aim += int.Parse(splitted[1]);
                        break;

                }
            }

            Part2Solution = (depth * movpos).ToString();
        }
    }
}
