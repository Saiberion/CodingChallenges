using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2020
{
    public class Challenge02 : Challenge
    {
        private static bool IsValidPassword(string pw, int min, int max, char pol)
        {
            int countedPol = 0;
            for (int i = 0; i < pw.Length; i++)
            {
                if (pw[i] == pol)
                {
                    countedPol++;
                }
            }
            return countedPol >= min && countedPol <= max;
        }

        private static bool IsValidPasswordAdvanced(string pw, int idx1, int idx2, char pol)
        {
            return pw[idx1] == pol && pw[idx2] != pol || pw[idx1] != pol && pw[idx2] == pol;
        }

        override public void Solve()
        {
            int validCount = 0;
            int validCountAdvanced = 0;
            foreach (string s in Input)
            {
                string[] splitted = s.Split(['-', ' ', ':'], StringSplitOptions.RemoveEmptyEntries);
                int i1 = int.Parse(splitted[0]);
                int i2 = int.Parse(splitted[1]);
                char c = splitted[2][0];
                string p = splitted[3];
                if (IsValidPassword(p, i1, i2, c))
                {
                    validCount++;
                }
                if (IsValidPasswordAdvanced(p, i1 - 1, i2 - 1, c))
                {
                    validCountAdvanced++;
                }
            }
            Part1Solution = validCount.ToString();
            Part2Solution = validCountAdvanced.ToString();
        }
    }
}
