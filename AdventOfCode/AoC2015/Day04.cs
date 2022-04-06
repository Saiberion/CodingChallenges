using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2015
{
    public class Day04: Day
    {
        override public void Solve()
        {
            MD5Managed md5 = new MD5Managed();
            string key = Input[0];
            byte[] hash;

            int index = 1;
            while(true)
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(key + index));

                if ((hash[0] == 0) && (hash[1] == 0) && (hash[2] <= 0x0f))
                {
                    Part1Solution = index.ToString();
                    break;
                }

                index++;
            }

            while (true)
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(key + index));

                if ((hash[0] == 0) && (hash[1] == 0) && (hash[2] == 0))
                {
                    Part2Solution = index.ToString();
                    break;
                }

                index++;
            }
        }
    }
}
