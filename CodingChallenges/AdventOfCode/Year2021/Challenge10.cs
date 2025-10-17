using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2021
{
    public class Challenge10 : Challenge
    {
        override public void Solve()
        {
            int errorScore = 0;
            List<long> completeScores = [];
            Dictionary<char, int> errorPoints = new()
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 }
            };
            Dictionary<char, int> completePoints = new()
            {
                { '(', 1 },
                { '[', 2 },
                { '{', 3 },
                { '<', 4 }
            };

            foreach (string s in Input)
            {
                Stack<char> openingBrackets = new();
                openingBrackets.Push(s[0]);
                bool aborted = false;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == '(' || s[i] == '[' || s[i] == '{' || s[i] == '<')
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
