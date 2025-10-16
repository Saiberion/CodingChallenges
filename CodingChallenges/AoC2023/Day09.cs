using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2023
{
    public class Day09 : AoCDay
    {
        public override void Solve()
        {
            long sumP1 = 0;
            long sumP2 = 0;
            List<List<long>> histories = [];

            foreach (string line in Input)
            {
                List<long> history = [];
                string[] splitted = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in splitted)
                {
                    history.Add(long.Parse(s));
                }
                histories.Add(history);
            }

            foreach (List<long> hist in histories)
            {
                List<List<long>> differenceTree = [hist];
                bool allZeroes = true;

                do
                {
                    allZeroes = true;
                    List<long> differences = [];
                    for (int i = 1; i < differenceTree[^1].Count; i++)
                    {
                        long diff = differenceTree[^1][i] - differenceTree[^1][i - 1];
                        if (diff != 0)
                        {
                            allZeroes = false;
                        }
                        differences.Add(diff);
                    }
                    differenceTree.Add(differences);
                } while (allZeroes == false);

                differenceTree[^1].Add(0);
                for (int t = differenceTree.Count - 2; t >= 0; t--)
                {
                    differenceTree[t].Add(differenceTree[t][^1] + differenceTree[t + 1][^1]);
                }
                sumP1 += differenceTree[0][^1];

                differenceTree[^1].Insert(0, 0);
                for (int t = differenceTree.Count - 2; t >= 0; t--)
                {
                    differenceTree[t].Insert(0, differenceTree[t][0] - differenceTree[t + 1][0]);
                }
                sumP2 += differenceTree[0][0];
            }

            Part1Solution = sumP1.ToString();

            Part2Solution = sumP2.ToString();
        }
    }
}
