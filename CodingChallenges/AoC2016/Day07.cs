﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2016
{
    public class Day07 : AoCDay
    {
        static bool IPv7HasTLS(string ipv7)
        {
            bool isHypernet = false;
            bool hasABBA = false;
            bool hasABBAinHypernet = false;
            for (int i = 0; i < (ipv7.Length - 3); i++)
            {
                if (ipv7[i] == '[')
                {
                    // start hypernet sequence
                    isHypernet = true;
                }
                else if (ipv7[i] == ']')
                {
                    // end hypernet sequence
                    isHypernet = false;
                }
                else
                {
                    // is ABBA
                    if ((ipv7[i] != ipv7[i + 1]) && (ipv7[i] == ipv7[i + 3]) && (ipv7[i + 1] == ipv7[i + 2]))
                    {
                        if (!isHypernet)
                        {
                            hasABBA = true;
                        }
                        else
                        {
                            hasABBAinHypernet = true;
                        }
                    }
                }
            }

            return hasABBA && !hasABBAinHypernet;
        }

        static bool IPv7HasSSL(string ipv7)
        {
            string[] splitted = ipv7.Split(['[', ']'], StringSplitOptions.RemoveEmptyEntries);
            bool ret = false;

            for (int i = 0; i < splitted.Length; i += 2)
            {
                for (int j = 0; j < (splitted[i].Length - 2); j++)
                {
                    if ((splitted[i][j] != splitted[i][j + 1]) && (splitted[i][j] == splitted[i][j + 2]))
                    {
                        for (int k = 1; k < splitted.Length; k += 2)
                        {
                            for (int l = 0; l < (splitted[k].Length - 2); l++)
                            {
                                if ((splitted[k][l] == splitted[i][j + 1]) && (splitted[k][l] == splitted[k][l + 2]) && (splitted[k][l + 1] == splitted[i][j]))
                                {
                                    ret = true;
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }

        static int CountTLSIPv7(List<string> input)
        {
            int ret = 0;

            foreach (string s in input)
            {
                if (IPv7HasTLS(s))
                {
                    ret++;
                }
            }
            return ret;
        }

        static int CountSSLIPv7(List<string> input)
        {
            int ret = 0;

            foreach (string s in input)
            {
                if (IPv7HasSSL(s))
                {
                    ret++;
                }
            }
            return ret;
        }

        public override void Solve()
        {
            Part1Solution = CountTLSIPv7(Input).ToString();

            Part2Solution = CountSSLIPv7(Input).ToString();
        }
    }
}
