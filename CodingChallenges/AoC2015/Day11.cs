﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day11 : AoCDay
    {
        static bool HasStraight(string pw)
        {
            bool result = false;

            for (int i = 0; i < pw.Length - 3; i++)
            {
                if ((pw[i + 1] == (pw[i] + 1)) && (pw[i + 2] == (pw[i] + 2)))
                {
                    result = true;
                }
            }

            return result;
        }

        static bool AllCharsValid(string pw)
        {
            bool result = true;

            if (pw.Contains('i') || pw.Contains('o') || pw.Contains('l'))
            {
                result = false;
            }

            return result;
        }

        static bool HasDifferentDoubleLetters(string pw)
        {
            bool result;
            int doubleCount = 0;
            char firstDouble = (char)0;

            for (int i = 0; i < pw.Length - 1; i++)
            {
                if (pw[i] == pw[i + 1])
                {
                    if (firstDouble == 0)
                    {
                        doubleCount++;
                        firstDouble = pw[i];
                        i++;
                    }
                    else
                    {
                        doubleCount++;
                        break;
                    }
                }
            }

            result = doubleCount == 2;

            return result;
        }

        static bool IsValidPassword(string pw)
        {
            bool result;

            result = HasStraight(pw);
            result &= AllCharsValid(pw);
            result &= HasDifferentDoubleLetters(pw);

            return result;
        }

        static string IncrementPW(string pw)
        {
            StringBuilder sb = new();
            int carry = 1;
            int index = pw.Length - 1;

            do
            {
                char c = (char)(pw[index] + carry);
                if (c > 'z')
                {
                    c = 'a';
                }
                else
                {
                    carry = 0;
                }
                sb.Append(c);
                index--;
            } while (index >= 0);

            char[] arr = sb.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        override public void Solve()
        {
            string password = Input[0];

            do
            {
                password = IncrementPW(password);
                IsValidPassword(password);
            } while (!IsValidPassword(password));
            Part1Solution = password;

            do
            {
                password = IncrementPW(password);
                IsValidPassword(password);
            } while (!IsValidPassword(password));
            Part2Solution = password;
        }
    }
}
