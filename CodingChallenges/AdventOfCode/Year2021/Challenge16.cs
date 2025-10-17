using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2021
{
    public class Challenge16 : Challenge
    {
        private int sumVersions;
        override public void Solve()
        {
            string binaryMessage = ConvertHexToBinaryText(Input[0]);

            sumVersions = 0;
            PacketParser(binaryMessage);

            Part1Solution = sumVersions.ToString();
            Part2Solution = "TBD";
        }

        private string PacketParser(string binmsg)
        {
            int pckidx = 0;
            string version = binmsg.Substring(pckidx, 3);
            int ver = 0;
            foreach (char c in version)
            {
                ver <<= 1;
                ver |= c - 0x30;
            }
            sumVersions += ver;
            pckidx += 3;
            string typeid = binmsg.Substring(pckidx, 3);
            pckidx += 3;

            if (typeid.Equals("100"))
            {
                // decipher literal
                // but for now just skip over those
                while (binmsg[pckidx] == '1')
                {
                    pckidx += 5;
                }
                pckidx += 5;
            }
            else
            {
                if (binmsg[pckidx] == '0')
                {
                    string subpkglen = binmsg.Substring(++pckidx, 15);
                    int len = 0;
                    foreach (char c in subpkglen)
                    {
                        len <<= 1;
                        len |= c - 0x30;
                    }
                    pckidx += 15;
                    string remain = binmsg.Substring(pckidx, len);
                    while (remain.Length > 0)
                    {
                        remain = PacketParser(remain);
                    }
                    pckidx += len;
                }
                else
                {
                    string subpkgcnt = binmsg.Substring(++pckidx, 11);
                    int cnt = 0;
                    foreach (char c in subpkgcnt)
                    {
                        cnt <<= 1;
                        cnt |= c - 0x30;
                    }
                    pckidx += 11;
                    for (int s = 0; s < cnt; s++)
                    {
                        binmsg = PacketParser(binmsg[pckidx..]);
                        pckidx = 0;
                    }
                }
            }
            return binmsg[pckidx..];
        }

        private static string ConvertHexToBinaryText(string hex)
        {
            StringBuilder sb = new();

            foreach (char c in hex)
            {
                switch (c)
                {
                    case '0':
                        sb.Append("0000");
                        break;
                    case '1':
                        sb.Append("0001");
                        break;
                    case '2':
                        sb.Append("0010");
                        break;
                    case '3':
                        sb.Append("0011");
                        break;
                    case '4':
                        sb.Append("0100");
                        break;
                    case '5':
                        sb.Append("0101");
                        break;
                    case '6':
                        sb.Append("0110");
                        break;
                    case '7':
                        sb.Append("0111");
                        break;
                    case '8':
                        sb.Append("1000");
                        break;
                    case '9':
                        sb.Append("1001");
                        break;
                    case 'A':
                        sb.Append("1010");
                        break;
                    case 'B':
                        sb.Append("1011");
                        break;
                    case 'C':
                        sb.Append("1100");
                        break;
                    case 'D':
                        sb.Append("1101");
                        break;
                    case 'E':
                        sb.Append("1110");
                        break;
                    case 'F':
                        sb.Append("1111");
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
