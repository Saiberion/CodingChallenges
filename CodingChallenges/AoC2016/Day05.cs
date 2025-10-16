using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day05 : AoCDay
    {
        static string[] GeneratePassword(string input)
        {
            StringBuilder pwLeftRight = new();
            Dictionary<int, string> pwPosDetect = [];

            int index = 0;
            while (pwPosDetect.Count < 8)
            {
                string toHash;
                toHash = input + index;
                byte[] hash = MD5.HashData(System.Text.Encoding.ASCII.GetBytes(toHash.ToString()));

                if (hash[0] == 0 && hash[1] == 0 && hash[2] <= 0x0F)
                {
                    int pos = hash[2] & 0x0f;
                    if (pwLeftRight.Length < 8)
                    {
                        pwLeftRight.Append(pos.ToString("X2")[1]);
                    }

                    if (pos < 8)
                    {
                        if (!pwPosDetect.ContainsKey(pos))
                        {
                            pwPosDetect.Add(pos, ((hash[3] & 0xf0) >> 4).ToString("X"));
                        }
                    }
                }
                index++;
            }

            string[] result =
            [
                pwLeftRight.ToString(),
                pwPosDetect[0] + pwPosDetect[1] + pwPosDetect[2] + pwPosDetect[3] + pwPosDetect[4] + pwPosDetect[5] + pwPosDetect[6] + pwPosDetect[7],
            ];
            return result;
        }

        public override void Solve()
        {
            string[] results = GeneratePassword(Input[0]);
            Part1Solution = results[0];

            Part2Solution = results[1];
        }
    }
}
