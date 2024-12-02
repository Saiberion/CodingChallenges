using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2018
{
    public class Day12 : AoCDay
    {
        long SimulateGenerations(long gens)
        {
            string currentState = "";
            string previousState = "";
            Dictionary<string, string> replacements = new();
            foreach (string s in Input)
            {
                if (s.StartsWith("initial state"))
                {
                    currentState = s[15..];
                }
                else if (s.Length > 0)
                {
                    string[] splitted = s.Split(new char[] { ' ', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    replacements.Add(splitted[0], splitted[1]);
                }
            }

            long leftmostPotNumber = 0;

            for (long i = 0; i < gens; i++)
            {
                if (previousState.Equals(currentState))
                {
                    leftmostPotNumber += gens - i;
                    break;
                }
                previousState = currentState;

                currentState = string.Format("....{0}....", currentState);
                leftmostPotNumber -= 2;

                StringBuilder sb = new();
                for (int j = 2; j < currentState.Length - 2; j++)
                {
                    string r = currentState.Substring(j - 2, 5);
                    if (replacements.ContainsKey(r))
                    {
                        sb.Append(replacements[r]);
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                currentState = sb.ToString();
                currentState = currentState.TrimEnd(new char[] { '.' });
                string t = currentState.TrimStart(new char[] { '.' });
                leftmostPotNumber += (currentState.Length - t.Length);
                currentState = t;
            }

            long sum = 0;
            for (int l = 0; l < currentState.Length; l++)
            {
                if (currentState[l] == '#')
                {
                    sum += leftmostPotNumber + l;
                }
            }
            return sum;
        }

        public override void Solve()
        {
            Part1Solution = SimulateGenerations(20).ToString();
            Part2Solution = SimulateGenerations(50000000000).ToString();
        }
    }
}
