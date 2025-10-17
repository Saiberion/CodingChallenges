using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
    public class Challenge19 : Challenge
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
            List<string> maze = [.. Input];

            // Maze walker
            int x = FindMazeStart(maze);
            int y = 0;
            Directions4Way dir = Directions4Way.Down;
            int steps = 0;
            StringBuilder sb = new();

            while (true)
            {
                switch (dir)
                {
                    case Directions4Way.Up:
                        y--;
                        break;
                    case Directions4Way.Down:
                        y++;
                        break;
                    case Directions4Way.Left:
                        x--;
                        break;
                    case Directions4Way.Right:
                        x++;
                        break;
                }
                steps++;

                if (maze[y][x] == '+') // direction change
                {
                    switch (dir)
                    {
                        case Directions4Way.Up:
                            if (maze[y][x - 1] == '-' || char.IsLetter(maze[y][x - 1]))
                            {
                                dir = Directions4Way.Left;
                            }
                            else if (maze[y][x + 1] == '-' || char.IsLetter(maze[y][x + 1]))
                            {
                                dir = Directions4Way.Right;
                            }
                            break;
                        case Directions4Way.Down:
                            if (maze[y][x - 1] == '-' || char.IsLetter(maze[y][x - 1]))
                            {
                                dir = Directions4Way.Left;
                            }
                            else if (maze[y][x + 1] == '-' || char.IsLetter(maze[y][x + 1]))
                            {
                                dir = Directions4Way.Right;
                            }
                            break;
                        case Directions4Way.Left:
                            if (maze[y - 1][x] == '|' || char.IsLetter(maze[y - 1][x]))
                            {
                                dir = Directions4Way.Up;
                            }
                            else if (maze[y + 1][x] == '|' || char.IsLetter(maze[y + 1][x]))
                            {
                                dir = Directions4Way.Down;
                            }
                            break;
                        case Directions4Way.Right:
                            if (maze[y - 1][x] == '|' || char.IsLetter(maze[y - 1][x]))
                            {
                                dir = Directions4Way.Up;
                            }
                            else if (maze[y + 1][x] == '|' || char.IsLetter(maze[y + 1][x]))
                            {
                                dir = Directions4Way.Down;
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
