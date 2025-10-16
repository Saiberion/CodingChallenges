using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2022
{
    public class Day02 : AoCDay
    {
        public override void Solve()
        {
            int totalScoreP1 = 0;
            int totalScoreP2 = 0;
            // A: Rock
            // B: Paper
            // C: Scissors

            // Loss         0
            // Draw         3
            // Win          6

            // X: Rock      1   Loose
            // Y: Paper     2   Draw
            // Z: Scissors  3   Win
            // ABCDEFGHIJKLMNOPQRSTUVWXYZ

            foreach (string s in Input)
            {
                totalScoreP1 += s[2] - 'W' + ((s[2] - s[0] - ('W' - 'A') + 3) % 3) * 3;

                totalScoreP2 += (s[0] - 'A' + s[2] - 'Y' + 3) % 3 + 1 + (s[2] - 'Y' + 1) * 3;
            }

            Part1Solution = totalScoreP1.ToString();

            Part2Solution = totalScoreP2.ToString();
        }
    }
}
