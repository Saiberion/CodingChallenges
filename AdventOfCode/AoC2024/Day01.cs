using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2024
{
    public class Day01 : AoCDay
    {
        public override void Solve()
        {
            List<int> left = [];
            List<int> right = [];
            foreach (string s in Input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                left.Add(int.Parse(splitted[0]));
                right.Add(int.Parse(splitted[1]));
            }

            left.Sort();
            right.Sort();

            int sumOfDifferences = 0;

            for(int i = 0; i < left.Count; i++)
            {
                sumOfDifferences += Math.Abs(right[i] - left[i]);
            }

            Part1Solution = sumOfDifferences.ToString();

            int similarityScore = 0;
            for (int i = 0; i < left.Count; i++)
            {
                int score = 0;
                for (int j = 0; j < right.Count; j++)
                {
                    if (left[i] == right[j])
                    {
                        score += left[i];
                    }
                }
                similarityScore += score;
            }

            Part2Solution = similarityScore.ToString();
        }
    }
}
