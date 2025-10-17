using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2019
{
    public class Challenge04 : Challenge
    {
        static bool IsValidPassword(int pw)
        {
            bool valid = true;
            int[] digits = new int[6];

            for (int i = 0; i < 6; i++)
            {
                digits[i] = pw % 10;
                pw /= 10;
            }

            bool hasDoubleDigit = false;
            for (int i = 5; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    valid = false;
                    break;
                }
                if (digits[i] == digits[i - 1])
                {
                    hasDoubleDigit = true;
                }
            }

            return valid && hasDoubleDigit;
        }

        static bool IsValidPasswordExtended(int pw)
        {
            bool notDecrementingDigits = true;
            bool hasValidDoubleDigit = false;

            int[] digits = new int[6];

            for (int i = 0; i < 6; i++)
            {
                digits[i] = pw % 10;
                pw /= 10;
            }

            int matchCount = 0;
            for (int i = 5; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    notDecrementingDigits = false;
                    break;
                }

                if (digits[i] == digits[i - 1])
                {
                    matchCount++;
                }
                else
                {
                    if (matchCount == 1)
                    {
                        hasValidDoubleDigit = true;
                    }
                    matchCount = 0;
                }
            }

            if (matchCount == 1)
            {
                hasValidDoubleDigit = true;
            }

            return notDecrementingDigits && hasValidDoubleDigit;
        }

        override public void Solve()
        {
            int rangeStart = int.Parse(Input[0]);
            int rangeEnd = int.Parse(Input[1]);

            List<int> validPasswords = [];

            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                if (IsValidPassword(i))
                {
                    validPasswords.Add(i);
                }
            }

            Part1Solution = validPasswords.Count.ToString();

            validPasswords.Clear();

            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                if (IsValidPasswordExtended(i))
                {
                    validPasswords.Add(i);
                }
            }

            Part2Solution = validPasswords.Count.ToString();
        }
    }
}
