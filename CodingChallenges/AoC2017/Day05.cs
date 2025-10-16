using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2017
{
    public class Day05 : Challenge
    {
        static int ListWalkerPart1(List<int> jumpList)
        {
            int steps = 0;
            int index = 0;
            List<int> jList = new(jumpList);

            while (true)
            {
                steps++;
                index += jList[index]++;
                if (index >= jList.Count)
                {
                    return steps;
                }
            }
        }

        static int ListWalkerPart2(List<int> jumpList)
        {
            int steps = 0;
            int index = 0;
            List<int> jList = new(jumpList);

            while (true)
            {
                int prevIndex = index;
                steps++;
                index += jList[index];
                if (jList[prevIndex] >= 3)
                {
                    jList[prevIndex]--;
                }
                else
                {
                    jList[prevIndex]++;
                }
                if (index >= jList.Count)
                {
                    return steps;
                }
            }
        }

        public override void Solve()
        {
            List<int> jumpList = [];
            foreach (string line in Input)
            {
                jumpList.Add(int.Parse(line));
            }

            Part1Solution = ListWalkerPart1(jumpList).ToString();
            Part2Solution = ListWalkerPart2(jumpList).ToString();
        }
    }
}
