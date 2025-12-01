using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge01 : Challenge
    {
        public override void Solve()
        {
            int dial = 50;
            int direction = 0;
            int steps;
            int password = 0;
            int passwordAlternative = 0;
            int overruns;

            foreach(string line in Input)
            {
                if (line[0] == 'L')
                {
                    direction = -1;
                }
                if (line[0] == 'R')
                {
                    direction = 1;
                }

                steps = int.Parse(line[1..]);
                /*overruns = (steps / 100);
                if (overruns > 0)
                {
                    passwordAlternative += overruns;
                    steps -= overruns * 100;
                }
                dial += direction * steps;
                if ((dial < 0) || (dial > 99))
                {
                    passwordAlternative++;
                }
                dial %= 100;
                if (dial < 0)
                {
                    dial += 100;
                }
                if (dial == 0)
                {
                    password++;
                    passwordAlternative++;
                }*/
                for (int i = 0; i < steps; i++)
                {
                    if (direction == 1)
                    {
                        dial++;
                    }
                    else
                    {
                        dial--;
                    }

                    if (dial < 0)
                    {
                        dial = 99;
                    }
                    else if (dial > 99)
                    {
                        dial = 0;
                    }

                    if (dial == 0)
                    {
                        passwordAlternative++;
                    }
                }
                if (dial == 0)
                {
                    password++;
                }
            }

            Part1Solution = password.ToString();

            Part2Solution = passwordAlternative.ToString();

            Part3Solution = "";
        }
    }
}
