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
            
            List<int> beams = [];
            int beamSplits = 0;

            beams.Add(Input[0].IndexOf('S'));

            for (int i = 1; i < Input.Count; i++)
            {
                List<int> nextBeams = [];
                foreach(int b in beams)
                {
                    if (Input[i][b] == '^')
                    {
                        if (!nextBeams.Contains(b - 1))
                        {
                            nextBeams.Add(b - 1);
                        }
                        if (!nextBeams.Contains(b + 1))
                        {
                            nextBeams.Add(b + 1);
                        }
                        beamSplits++;
                    }
                    else
                    {
                        if (!nextBeams.Contains(b))
                        {
                            nextBeams.Add(b);
                        }
                    }
                }
                beams = nextBeams;
            }

            Part1Solution = beamSplits.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
