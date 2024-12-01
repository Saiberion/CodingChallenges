using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
    public class Day19 : AoCDay
    {
        static int FindMazeStart(List<string> maze)
        {
            int x;
            for (x = 0; x < maze[0].Length; x++)
            {
                if (maze[0][x] == '|')
                {
                    break;
                }
            }
            return x;
        }

        public override void Solve()
        {
            List<string> maze = new(Input);

            // Maze walker
            int x = FindMazeStart(maze);
            int y = 0;
            EDirections dir = EDirections.eDown;
            int steps = 0;
            StringBuilder sb = new();

            while (true)
            {
                switch (dir)
                {
                    case EDirections.eUp:
                        y--;
                        break;
                    case EDirections.eDown:
                        y++;
                        break;
                    case EDirections.eLeft:
                        x--;
                        break;
                    case EDirections.eRight:
                        x++;
                        break;
                }
                steps++;

                if (maze[y][x] == '+') // direction change
                {
                    switch (dir)
                    {
                        case EDirections.eUp:
                            if ((maze[y][x - 1] == '-') || char.IsLetter(maze[y][x - 1]))
                            {
                                dir = EDirections.eLeft;
                            }
                            else if ((maze[y][x + 1] == '-') || char.IsLetter(maze[y][x + 1]))
                            {
                                dir = EDirections.eRight;
                            }
                            break;
                        case EDirections.eDown:
                            if ((maze[y][x - 1] == '-') || char.IsLetter(maze[y][x - 1]))
                            {
                                dir = EDirections.eLeft;
                            }
                            else if ((maze[y][x + 1] == '-') || char.IsLetter(maze[y][x + 1]))
                            {
                                dir = EDirections.eRight;
                            }
                            break;
                        case EDirections.eLeft:
                            if ((maze[y - 1][x] == '|') || char.IsLetter(maze[y - 1][x]))
                            {
                                dir = EDirections.eUp;
                            }
                            else if ((maze[y + 1][x] == '|') || char.IsLetter(maze[y + 1][x]))
                            {
                                dir = EDirections.eDown;
                            }
                            break;
                        case EDirections.eRight:
                            if ((maze[y - 1][x] == '|') || char.IsLetter(maze[y - 1][x]))
                            {
                                dir = EDirections.eUp;
                            }
                            else if ((maze[y + 1][x] == '|') || char.IsLetter(maze[y + 1][x]))
                            {
                                dir = EDirections.eDown;
                            }
                            break;
                    }
                }
                else if (maze[y][x] == ' ') // Reached end of maze
                {
                    break;
                }
                else
                {
                    if (char.IsLetter(maze[y][x]))
                    {
                        sb.Append(maze[y][x]);
                    }
                }
            }

            Part1Solution = sb.ToString();
            Part2Solution = steps.ToString();
        }
    }
}
