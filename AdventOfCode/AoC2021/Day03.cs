using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day03 : Day
    {
        override public void Solve()
        {
            int counter;
            int gammaRate = 0;

            for (int bitpos = 0; bitpos < Input[0].Length; bitpos++)
            {
                counter = 0;
                for(int l = 0; l < Input.Count; l++)
                {
                    if (Input[l][bitpos] == '0')
                    {
                        counter--;
                    }
                    else
                    {
                        counter++;
                    }
                }

                gammaRate <<= 1;
                if (counter > 0)
                {
                    gammaRate |= 1;
                }
                else if (counter < 0)
                {
                    gammaRate |= 0;
                }
            }

            Part1Solution = (gammaRate * (~gammaRate & ((int)Math.Pow(2, Input[0].Length) - 1))).ToString();
            Part2Solution = "TBD";
        }
    }
}
