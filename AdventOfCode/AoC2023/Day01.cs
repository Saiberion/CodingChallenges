using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    public class Day01 : Day
    {
        private static List<int> GetDigitsFromString(string s, bool part2)
        {
            List<int> digits = new();

            for (int i = 0; i < s.Length; i++)
            {
                string s1 = s.Remove(0, i);
                if (s1.StartsWith("0") || (part2 && s1.StartsWith("zero")))
                {
                    digits.Add(0);
                }
                else if (s1.StartsWith("1") || (part2 && s1.StartsWith("one")))
                {
                    digits.Add(1);
                }
                else if (s1.StartsWith("2") || (part2 && s1.StartsWith("two")))
                {
                    digits.Add(2);
                }
                else if (s1.StartsWith("3") || (part2 && s1.StartsWith("three")))
                {
                    digits.Add(3);
                }
                else if (s1.StartsWith("4") || (part2 && s1.StartsWith("four")))
                {
                    digits.Add(4);
                }
                else if (s1.StartsWith("5") || (part2 && s1.StartsWith("five")))
                {
                    digits.Add(5);
                }
                else if (s1.StartsWith("6") || (part2 && s1.StartsWith("six")))
                {
                    digits.Add(6);
                }
                else if (s1.StartsWith("7") || (part2 && s1.StartsWith("seven")))
                {
                    digits.Add(7);
                }
                else if (s1.StartsWith("8") || (part2 && s1.StartsWith("eight")))
                {
                    digits.Add(8);
                }
                else if (s1.StartsWith("9") || (part2 && s1.StartsWith("nine")))
                {
                    digits.Add(9);
                }
            }
            return digits;
        }

        public override void Solve()
        {
            int sumP1 = 0;
            int sumP2 = 0;
            int twodigitnumber;
            foreach (string s in Input)
            {
                List<int> digits = GetDigitsFromString(s, false);

                if (digits.Count > 0)
                {
                    twodigitnumber = digits[0] * 10 + digits[^1];
                    sumP1 += twodigitnumber;
                }
            }
            Part1Solution = sumP1.ToString();

            foreach (string s in Input)
            {
                List<int> digits = GetDigitsFromString(s, true);

                if (digits.Count > 0)
                {
                    twodigitnumber = digits[0] * 10 + digits[^1];
                    sumP2 += twodigitnumber;
                }
            }

            Part2Solution = sumP2.ToString();
        }
    }
}
