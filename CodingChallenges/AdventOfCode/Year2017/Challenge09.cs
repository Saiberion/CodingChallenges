using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
    public class Challenge09 : Challenge
    {
        public override void Solve()
        {
            int currentGroupScore = 0;
            int totalScore = 0;
            bool openGarbage = false;
            int garbageCharachters = 0;

            for (int i = 0; i < Input[0].Length; i++)
            {
                switch (Input[0][i])
                {
                    case '{':
                        if (!openGarbage)
                        {
                            currentGroupScore++;
                        }
                        else
                        {
                            garbageCharachters++;
                        }
                        break;
                    case '}':
                        if (!openGarbage)
                        {
                            totalScore += currentGroupScore;
                            currentGroupScore--;
                        }
                        else
                        {
                            garbageCharachters++;
                        }
                        break;
                    case '<':
                        if (!openGarbage)
                        {
                            openGarbage = true;
                        }
                        else
                        {
                            garbageCharachters++;
                        }
                        break;
                    case '>':
                        openGarbage = false;
                        break;
                    case '!':
                        if (openGarbage)
                        {
                            i++;
                        }
                        break;
                    default:
                        if (openGarbage)
                        {
                            garbageCharachters++;
                        }
                        break;
                }


            }

            Part1Solution = totalScore.ToString();
            Part2Solution = garbageCharachters.ToString();
        }
    }
}
