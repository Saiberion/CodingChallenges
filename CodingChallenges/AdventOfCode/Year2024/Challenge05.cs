using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2024
{
    public class Challenge05 : Challenge
    {
        int middlePagesSum = 0;
        public override void Solve()
        {
            List<int[]> orderingRules = [];
            List<List<int>> updatePages = [];
            foreach (string l in Input)
            {
                string[] splitted = l.Split(['|', ','], StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 2)
                {
                    orderingRules.Add([int.Parse(splitted[0]), int.Parse(splitted[1])]);
                }

                if (splitted.Length > 2)
                {
                    List<int> pages = [];
                    foreach(string s in splitted)
                    {
                        pages.Add(int.Parse(s));
                    }
                    updatePages.Add(pages);
                }
            }

            List<int> errorCounter = [];
            for (int i = 0; i < updatePages.Count; i++)
            {
                bool orderCorrect = true;
                int errors = 0;
                foreach (int[] r in orderingRules)
                {
                    if (updatePages[i].Contains(r[0]) && updatePages[i].Contains(r[1]))
                    {
                        int pos1 = updatePages[i].IndexOf(r[0]);
                        int pos2 = updatePages[i].IndexOf(r[1]);

                        if (pos1 > pos2)
                        {
                            orderCorrect = false;
                            errors++;
                        }
                    }
                }
                errorCounter.Add(errors);

                if (orderCorrect)
                {
                    middlePagesSum += updatePages[i][updatePages[i].Count / 2];
                }
            }

            Part1Solution = middlePagesSum.ToString();

            Part2Solution = "TBD";
        }
    }
}
