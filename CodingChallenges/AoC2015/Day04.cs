using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CodingChallenges.AoC2015
{
    public class Day04 : AoCDay
    {
        override public void Solve()
        {
            string key = Input[0];
            byte[] hash;
            bool finishedP1 = false, finishedP2 = false;

            int index = 1;
            while (!(finishedP1 && finishedP2))
            {
                hash = MD5.HashData(Encoding.ASCII.GetBytes(key + index));

                if (!finishedP1 && (hash[0] == 0) && (hash[1] == 0) && (hash[2] <= 0x0f))
                {
                    finishedP1 = true;
                    Part1Solution = index.ToString();
                }

                if (!finishedP2 && (hash[0] == 0) && (hash[1] == 0) && (hash[2] == 0))
                {
                    finishedP2 = true;
                    Part2Solution = index.ToString();
                }

                index++;
            }
        }
    }
}
