using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge05 : Challenge
    {
        public override void Solve()
        {
            List<long[]> ranges = [];
            List<long> ingredients = [];

            long countFresh = 0;

            foreach(string line in Input)
            {
                if (line.Length > 0)
                {
                    if (line.Contains('-'))
                    {
                        string[] r = line.Split(['-'], StringSplitOptions.RemoveEmptyEntries);
                        ranges.Add([long.Parse(r[0]), long.Parse(r[1])]);
                    }
                    else
                    {
                        ingredients.Add(long.Parse(line));
                    }
                }
            }

            foreach(long id in ingredients)
            {
                foreach (long[] range in ranges)
                {
                    if ((id >= range[0]) && (id <= range[1]))
                    {
                        countFresh++;
                        break;
                    }
                }
            }

            Part1Solution = countFresh.ToString();

            List<long[]> rangesMerged = [];
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;

            foreach (long[] range in ranges)
            {
                int i;
                for (i = 0; i < rangesMerged.Count; i++)
                {
                    if (range[1] < rangesMerged[i][0])
                    {
                        // range is completely before checked range element
                        rangesMerged.Insert(i, range);
                        a++;
                        break;
                    }
                    else if (range[0] > rangesMerged[i][1])
                    {
                        // range is after current block
                        continue;
                    }
                    else if ((range[0] >= rangesMerged[i][0]) && (range[1] <= rangesMerged[i][1]))
                    {
                        // swallowed by the range, nothing to do
                        b++;
                        break;
                    }
                    else if (range[1] == rangesMerged[i][0])
                    {
                        rangesMerged[i][0] = range[0];
                        c++;
                        break;
                    }
                    else if ((range[0] <= rangesMerged[i][1]) && (range[1] > rangesMerged[i][1]))
                    {
                        range[0] = rangesMerged[i][1] + 1;
                    }
                    else if ((range[0] < rangesMerged[i][0]) && (range[1] > rangesMerged[i][0]) && (range[1] <= rangesMerged[i][1]))
                    {
                        // we have overlap at the lower end of the existing range
                        rangesMerged[i][0] = range[0];
                        break;
                    }
                    else
                    {
                        break;
                    }
                    /*else if ((range[0] < rangesMerged[i][0]) && (range[1] >= rangesMerged[i][1]))
                    {
                        // we have overlap at the lower end of the existing range
                        rangesMerged[i][0] = range[0];
                        range[0] = rangesMerged[i][1];
                    }*/
                }
                if (i == rangesMerged.Count)
                {
                    rangesMerged.Add(range);
                    d++;
                }
            }

            long idCount = 0;
            foreach (long[] range in rangesMerged)
            {
                idCount += range[1] - range[0] + 1;
            }

            Part2Solution = idCount.ToString();

            Part3Solution = "";
        }
    }
}
