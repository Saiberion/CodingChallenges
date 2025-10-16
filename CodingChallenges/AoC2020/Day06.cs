using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2020
{
    public class Day06 : AoCDay
    {
        override public void Solve()
        {
            int personCounter = 0;
            Dictionary<char, int> groupAnswers = [];
            int sumOfYesAnswersPerGroup = 0;
            int sumOfYesAnswersPerGroupAdvanced = 0;
            for (int i = 0; i < Input.Count; i++)
            {
                if (string.IsNullOrEmpty(Input[i]))
                {
                    // blank line --> new group
                    sumOfYesAnswersPerGroup += groupAnswers.Count;

                    foreach (KeyValuePair<char, int> kvp in groupAnswers)
                    {
                        if (kvp.Value == personCounter)
                        {
                            sumOfYesAnswersPerGroupAdvanced++;
                        }
                    }
                    personCounter = 0;
                    groupAnswers = [];
                }
                else
                {
                    personCounter++;
                    foreach (char c in Input[i])
                    {
                        if (groupAnswers.TryGetValue(c, out int value))
                        {
                            groupAnswers[c] = ++value;
                        }
                        else
                        {
                            groupAnswers.Add(c, 1);
                        }
                    }
                }
            }
            sumOfYesAnswersPerGroup += groupAnswers.Count;
            foreach (KeyValuePair<char, int> kvp in groupAnswers)
            {
                if (kvp.Value == personCounter)
                {
                    sumOfYesAnswersPerGroupAdvanced++;
                }
            }

            Part1Solution = sumOfYesAnswersPerGroup.ToString();
            Part2Solution = sumOfYesAnswersPerGroupAdvanced.ToString();
        }
    }
}
