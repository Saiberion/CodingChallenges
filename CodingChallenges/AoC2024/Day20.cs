using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2024
{
    public class Day20 : AoCDay
    {
        public override void Solve()
        {
            Point start = new(), end = new();
            char[,] raceTrack = new char[Input[0].Length, Input.Count];

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    raceTrack[x, y] = Input[y][x];
                    if (Input[y][x] == 'S')
                    {
                        start.X = x;
                        start.Y = y;
                    }
                    if (Input[y][x] == 'E')
                    {
                        end.X = x;
                        end.Y = y;
                    }
                }
            }

            int steps = 0;

            while (raceTrack[start.X, start.Y] != 'E')
            {
                if ((raceTrack[start.X, start.Y - 1] == '.') || (raceTrack[start.X, start.Y - 1] == 'E'))
                {
                    steps++;
                    raceTrack[start.X, start.Y] = ',';
                    start.Y--;
                }
                else if ((raceTrack[start.X + 1, start.Y] == '.') || (raceTrack[start.X + 1, start.Y] == 'E'))
                {
                    steps++;
                    raceTrack[start.X, start.Y] = ',';
                    start.X++;
                }
                else if ((raceTrack[start.X, start.Y + 1] == '.') || (raceTrack[start.X, start.Y + 1] == 'E'))
                {
                    steps++;
                    raceTrack[start.X, start.Y] = ',';
                    start.Y++;
                }
                else if ((raceTrack[start.X - 1, start.Y] == '.') || (raceTrack[start.X - 1, start.Y] == 'E'))
                {
                    steps++;
                    raceTrack[start.X, start.Y] = ',';
                    start.X--;
                }
            }

            Part1Solution = steps.ToString();
            
            Part2Solution = "TBD";
        }
    }
}
