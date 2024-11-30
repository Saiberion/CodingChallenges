using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AoC2015
{
    public class Day04 : Day
    {
        override public void Solve()
        {
            MD5 md5 = MD5.Create();
            string key = Input[0];
            byte[] hash;
            bool finishedP1 = false, finishedP2 = false;

            int index = 1;
            while (!(finishedP1 && finishedP2))
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(key + index));

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
