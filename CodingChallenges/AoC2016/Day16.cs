using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day16 : Challenge
    {
        static string DragonChecksum(string input)
        {
            string[] splitted = input.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            int fillLength = int.Parse(splitted[0]);
            StringBuilder sb = new(splitted[1]);

            // Lengthen string
            while (sb.Length < fillLength)
            {
                string a = sb.ToString();
                sb.Append('0');
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (a[i] == '0')
                    {
                        sb.Append('1');
                    }
                    else
                    {
                        sb.Append('0');
                    }
                }
            }

            // get checksum
            string chk = sb.ToString().Remove(fillLength);
            do
            {
                StringBuilder sbChk = new();
                for (int i = 0; i < chk.Length - 1; i += 2)
                {
                    if (chk[i] == chk[i + 1])
                    {
                        sbChk.Append('1');
                    }
                    else
                    {
                        sbChk.Append('0');
                    }
                }
                chk = sbChk.ToString();
            } while ((chk.Length % 2) == 0);

            return chk;
        }

        public override void Solve()
        {
            Part1Solution = DragonChecksum(Input[0]);

            Part2Solution = DragonChecksum(Input[1]);
        }
    }
}
