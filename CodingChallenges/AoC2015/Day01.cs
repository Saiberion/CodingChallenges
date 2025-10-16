using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2015
{
    public class Day01 : AoCDay
    {
        override public void Solve()
        {
            int floor = 0;
            int stepsTaken = 0;
            bool enteredBasement = false;
            foreach (string s in Input)
            {
                foreach (char c in s)
                {
                    if (c == '(')
                    {
                        floor++;
                    }
                    else if (c == ')')
                    {
                        floor--;
                    }
                    stepsTaken++;
                    if (floor < 0)
                    {
                        if (!enteredBasement)
                        {
                            enteredBasement = true;
                            Part2Solution = stepsTaken.ToString();
                        }
                    }
                }
            }

            Part1Solution = floor.ToString();
        }
    }
}
