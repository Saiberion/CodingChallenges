using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge06 : Challenge
    {
        public override void Solve()
        {
            List<string[]> mathProblems = [];
            foreach (string line in Input)
            {
                string[] data = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                mathProblems.Add(data);
            }

            long grandTotal = 0;
            long result;
            for (int i = 0; i < mathProblems[0].Length; i++)
            {
                if (mathProblems[^1][i][0] == '+')
                {
                    // addition
                    result = 0;
                    for (int j = 0; j < mathProblems.Count - 1; j++)
                    {
                        result += long.Parse(mathProblems[j][i]);
                    }
                }
                else
                {
                    // multiplication
                    result = 1;
                    for (int j = 0; j < mathProblems.Count - 1; j++)
                    {
                        result *= long.Parse(mathProblems[j][i]);
                    }
                }
                grandTotal += result;
            }

            Part1Solution = grandTotal.ToString();

            grandTotal = 0;
            List<long> numbers = [];
            for (int i = Input[0].Length - 1; i >= 0; i--)
            {
                StringBuilder sb = new();
                for (int j = 0; j < Input.Count - 1; j++)
                {
                    sb.Append(Input[j][i]);
                }
                string num = sb.ToString().Trim();
                if (!string.IsNullOrEmpty(num))
                {
                    numbers.Add(long.Parse(num));
                }
                else
                {
                    if (Input[^1][i + 1] == '+')
                    {
                        // addition
                        result = 0;
                        foreach(long l in numbers)
                        {
                            result += l;
                        }
                    }
                    else
                    {
                        // multiplication
                        result = 1;
                        foreach (long l in numbers)
                        {
                            result *= l;
                        }
                    }
                    grandTotal += result;
                    numbers.Clear();
                }
                if (i == 0)
                {
                    if (Input[^1][i] == '+')
                    {
                        // addition
                        result = 0;
                        foreach (long l in numbers)
                        {
                            result += l;
                        }
                    }
                    else
                    {
                        // multiplication
                        result = 1;
                        foreach (long l in numbers)
                        {
                            result *= l;
                        }
                    }
                    grandTotal += result;
                }
            }

            Part2Solution = grandTotal.ToString();

            Part3Solution = "";
        }
    }
}
