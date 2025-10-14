using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode.AoC2023
{
    public class Day10 : AoCDay
    {
        public override void Solve()
        {
            char[,] pipefield = new char[Input[0].Length, Input.Count];
            Point currentPosition = new();
            int steps = 0;

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[0].Length; x++)
                {
                    pipefield[x, y] = Input[y][x];
                    if (pipefield[x, y] == 'S')
                    {
                        currentPosition.X = x;
                        currentPosition.Y = y;
                    }
                }
            }

            int nextDir = -1;
            bool loopDone = false;
            while (!loopDone)
            {
                switch (nextDir)
                {
                    case 0: // north
                        currentPosition.Y--;
                        steps++;
                        switch (pipefield[currentPosition.X, currentPosition.Y])
                        {
                            case '7':
                                nextDir = 1;
                                break;
                            case 'F':
                                nextDir = 3;
                                break;
                            case 'S':
                                loopDone = true;
                                break;
                        }
                        break;
                    case 1: // west
                        currentPosition.X--;
                        steps++;
                        switch (pipefield[currentPosition.X, currentPosition.Y])
                        {
                            case 'L':
                                nextDir = 0;
                                break;
                            case 'F':
                                nextDir = 2;
                                break;
                            case 'S':
                                loopDone = true;
                                break;
                        }
                        break;
                    case 2: // south
                        currentPosition.Y++;
                        steps++;
                        switch (pipefield[currentPosition.X, currentPosition.Y])
                        {
                            case 'L':
                                nextDir = 3;
                                break;
                            case 'J':
                                nextDir = 1;
                                break;
                            case 'S':
                                loopDone = true;
                                break;
                        }
                        break;
                    case 3: // east
                        currentPosition.X++;
                        steps++;
                        switch (pipefield[currentPosition.X, currentPosition.Y])
                        {
                            case '7':
                                nextDir = 2;
                                break;
                            case 'J':
                                nextDir = 0;
                                break;
                            case 'S':
                                loopDone = true;
                                break;
                        }
                        break;
                    case -1: // determine direction

                        if ((pipefield[currentPosition.X + 1, currentPosition.Y] == '-') || (pipefield[currentPosition.X + 1, currentPosition.Y] == 'J') || (pipefield[currentPosition.X + 1, currentPosition.Y] == '7'))
                        {
                            nextDir = 3;
                            continue;
                        }
                        else if ((pipefield[currentPosition.X - 1, currentPosition.Y] == '-') || (pipefield[currentPosition.X - 1, currentPosition.Y] == 'L') || (pipefield[currentPosition.X - 1, currentPosition.Y] == 'F'))
                        {
                            nextDir = 1;
                            continue;
                        }
                        else if ((pipefield[currentPosition.X, currentPosition.Y + 1] == '|') || (pipefield[currentPosition.X, currentPosition.Y + 1] == 'L') || (pipefield[currentPosition.X, currentPosition.Y + 1] == 'J'))
                        {
                            nextDir = 2;
                            continue;
                        }
                        else if ((pipefield[currentPosition.X, currentPosition.Y - 1] == '|') || (pipefield[currentPosition.X, currentPosition.Y - 1] == '7') || (pipefield[currentPosition.X, currentPosition.Y - 1] == 'F'))
                        {
                            nextDir = 0;
                            continue;
                        }
                        break;

                }
            }

            Part1Solution = (steps / 2).ToString();

            Part2Solution = "TBD";
        }
    }
}
