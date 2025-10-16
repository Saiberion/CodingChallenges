using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CodingChallenges.AoC2022
{
    public class Day10 : Challenge
    {
        public override void Solve()
        {
            int ticks = 0;
            int regx = 1;
            int signalStregnth = 0;
            int[,] crt = new int[40, 6];
            int currentline = 0;
            int currentPos = 0;
            for (int i = 0; i < Input.Count; i++)
            {
                string[] splitted = Input[i].Split([' '], StringSplitOptions.RemoveEmptyEntries);
                ticks++;
                if ((((ticks - 1) % 40) == (regx - 1)) || (((ticks - 1) % 40) == (regx)) || (((ticks - 1) % 40) == (regx + 1)))
                {
                    crt[currentPos, currentline] = 1;
                }
                else
                {
                    crt[currentPos, currentline] = 0;
                }
                if ((ticks == 20) || (ticks == 60) || (ticks == 100) || (ticks == 140) || (ticks == 180) || (ticks == 220))
                {
                    signalStregnth += ticks * regx;
                }
                if (++currentPos == 40)
                {
                    currentPos = 0;
                    currentline++;
                }
                if (splitted[0].Equals("addx"))
                {
                    ticks++;
                    if ((((ticks - 1) % 40) == (regx - 1)) || (((ticks - 1) % 40) == (regx)) || (((ticks - 1) % 40) == (regx + 1)))
                    {
                        crt[currentPos, currentline] = 1;
                    }
                    else
                    {
                        crt[currentPos, currentline] = 0;
                    }
                    if ((ticks == 20) || (ticks == 60) || (ticks == 100) || (ticks == 140) || (ticks == 180) || (ticks == 220))
                    {
                        signalStregnth += ticks * regx;
                    }
                    if (++currentPos == 40)
                    {
                        currentPos = 0;
                        currentline++;
                    }
                    regx += int.Parse(splitted[1]);
                }
            }
            Part1Solution = signalStregnth.ToString();

            Part2Solution = DotmatrixToString.Render(crt);
        }
    }
}
