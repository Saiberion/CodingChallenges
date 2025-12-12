using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge12 : Challenge
    {
        public override void Solve()
        {
            List<int> treeAreas = [];
            List<int[]> areaPresents = [];
            List<int> presentSize = [];
            int presentIndex = -1;
            foreach (string line in Input)
            {
                if (line.Contains('x'))
                {
                    string[] treeInfo = line.Split(['x', ':', ' '], StringSplitOptions.RemoveEmptyEntries);
                    treeAreas.Add(int.Parse(treeInfo[0]) * int.Parse(treeInfo[1]));
                    areaPresents.Add([int.Parse(treeInfo[2]), int.Parse(treeInfo[3]), int.Parse(treeInfo[4]), int.Parse(treeInfo[5]), int.Parse(treeInfo[6]), int.Parse(treeInfo[7])]);
                }
                else if (line.Length > 0)
                {
                    if (line.Contains(':'))
                    {
                        presentIndex = int.Parse(line[0].ToString());
                        presentSize.Add(0);
                    }
                    else
                    {
                        foreach(char c in line)
                        {
                            if (c == '#')
                            {
                                presentSize[presentIndex]++;
                            }
                        }
                    }
                }
            }

            int allFit = 0;
            for (int i = 0; i < treeAreas.Count; i++)
            {
                int spacePresents = 0;
                for (int k = 0; k < areaPresents[i].Length; k++)
                {
                    spacePresents += areaPresents[i][k] * presentSize[k];
                }
                if (spacePresents <= treeAreas[i])
                {
                    allFit++;
                }
            }

            Part1Solution = allFit.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
