using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day10 : Day
    {
        override public void Solve()
        {
            int errorScore = 0;
            List<long> completeScores = new List<long>();
            Dictionary<char, int> errorPoints = new Dictionary<char, int>();
            errorPoints.Add(')', 3);
            errorPoints.Add(']', 57);
            errorPoints.Add('}', 1197);
            errorPoints.Add('>', 25137);
            Dictionary<char, int> completePoints = new Dictionary<char, int>();
            completePoints.Add('(', 1);
            completePoints.Add('[', 2);
            completePoints.Add('{', 3);
            completePoints.Add('<', 4);

            foreach (string s in Input)
            {
                Stack<char> openingBrackets = new Stack<char>();
                openingBrackets.Push(s[0]);
                bool aborted = false;
                for (int i = 1; i < s.Length; i++)
                {
                    if ((s[i] == '(') || (s[i] == '[') || (s[i] == '{') || (s[i] == '<'))
                    {
                        openingBrackets.Push(s[i]);
                    }
                    else
                    {
                        char lastOpen = openingBrackets.Pop();
                        if (lastOpen == '(')
                        {
                            if (s[i] != ')')
                            {
                                errorScore += errorPoints[s[i]];
                                aborted = true;
                                break;
                            }
                        }
                        else if (lastOpen == '[')
                        {
                            if (s[i] != ']')
                            {
                                errorScore += errorPoints[s[i]];
                                aborted = true;
                                break;
                            }
                        }
                        else if (lastOpen == '{')
                        {
                            if (s[i] != '}')
                            {
                                errorScore += errorPoints[s[i]];
                                aborted = true;
                                break;
                            }
                        }
                        else if (lastOpen == '<')
                        {
                            if (s[i] != '>')
                            {
                                errorScore += errorPoints[s[i]];
                                aborted = true;
                                break;
                            }
                        }
                    }
                }
                if (aborted == false)
                {
                    long completeScore = 0;
                    while (openingBrackets.Count > 0)
                    {
                        char bracket = openingBrackets.Pop();
                        completeScore = completeScore * 5 + completePoints[bracket];
                    }
                    completeScores.Add(completeScore);
                }
            }
            completeScores.Sort();
            Part1Solution = errorScore.ToString();
            Part2Solution = completeScores[completeScores.Count / 2].ToString();
        }
    }
}
