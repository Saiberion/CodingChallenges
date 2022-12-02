using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day02 : Day
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


            foreach (string s in Input)
            {
                switch(s)
                {
                    case "A X":
                        totalScoreP1 += 1 + 3;
                        totalScoreP2 += 3 + 0;
                        break;
                    case "A Y":
                        totalScoreP1 += 2 + 6;
                        totalScoreP2 += 1 + 3;
                        break;
                    case "A Z":
                        totalScoreP1 += 3 + 0;
                        totalScoreP2 += 2 + 6;
                        break;
                    case "B X":
                        totalScoreP1 += 1 + 0;
                        totalScoreP2 += 1 + 0;
                        break;
                    case "B Y":
                        totalScoreP1 += 2 + 3;
                        totalScoreP2 += 2 + 3;
                        break;
                    case "B Z":
                        totalScoreP1 += 3 + 6;
                        totalScoreP2 += 3 + 6;
                        break;
                    case "C X":
                        totalScoreP1 += 1 + 6;
                        totalScoreP2 += 2 + 0;
                        break;
                    case "C Y":
                        totalScoreP1 += 2 + 0;
                        totalScoreP2 += 3 + 3;
                        break;
                    case "C Z":
                        totalScoreP1 += 3 + 3;
                        totalScoreP2 += 1 + 6;
                        break;
                }
            }

            Part1Solution = totalScoreP1.ToString();

            Part2Solution = totalScoreP2.ToString();
        }
    }
}
