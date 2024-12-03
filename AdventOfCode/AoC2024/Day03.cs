using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.AoC2024
{
    public class Day03 : AoCDay
    {
        public override void Solve()
        {
            string pattern = @"mul\(\d{1,3},\d{1,3}\)";
            int multSum = 0;
            foreach(string line in Input)
            {
                Regex r = new(pattern);
                MatchCollection m = r.Matches(line);
                foreach(Match m2 in m)
                {
                    string[] splitted = m2.Value.Split(['(', ')', ','], StringSplitOptions.RemoveEmptyEntries);
                    multSum += int.Parse(splitted[1]) * int.Parse(splitted[2]);
                }
            }

            Part1Solution = multSum.ToString();

            pattern = @"(mul\(\d{1,3},\d{1,3}\))|(do\(\))|(don't\(\))";
            multSum = 0;
            bool doMult = true;
            foreach (string line in Input)
            {
                Regex r = new(pattern);
                MatchCollection m = r.Matches(line);
                foreach (Match m2 in m)
                {
                    string[] splitted = m2.Value.Split(['(', ')', ','], StringSplitOptions.RemoveEmptyEntries);
                    if (splitted[0].Equals("mul"))
                    {
                        if (doMult)
                        {
                            multSum += int.Parse(splitted[1]) * int.Parse(splitted[2]);
                        }
                    }
                    else if (splitted[0].Equals("don't"))
                    {
                        doMult = false;
                    }
                    else if (splitted[0].Equals("do"))
                    {
                        doMult = true;
                    }
                }
            }

            Part2Solution = multSum.ToString();
        }
    }
}
