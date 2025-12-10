using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge07 : Challenge
    {
        public override void Solve()
        {
            
            int beamSplits = 0;
            long[] activeBeams = new long [Input[0].Length];

            activeBeams[Input[0].IndexOf('S')] = 1;

            for (int i = 1; i < Input.Count; i++)
            {
                for (int k = 0; k < Input[i].Length; k++)
                {
                    if ((Input[i][k] == '^') && (activeBeams[k] > 0))
                    {
                        beamSplits++;
                        activeBeams[k - 1] += activeBeams[k];
                        activeBeams[k + 1] += activeBeams[k];
                        activeBeams[k] = 0;
                    }
                }
            }

            Part1Solution = beamSplits.ToString();

            long allTimelines = 0;
            foreach (long a in activeBeams)
            {
                allTimelines += a;
            }

            Part2Solution = allTimelines.ToString();

            Part3Solution = "";
        }
    }
}
