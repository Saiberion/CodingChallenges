using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2024
{
    public class Day04 : AoCDay
    {
        enum Direction
        {
            Up,
            UpRight,
            Right,
            DownRight,
            Down,
            DownLeft,
            Left,
            UpLeft
        }

        private bool IsXmas(int startx, int starty, Direction dir, int steps)
        {
            char expectedChar = '\0';
            switch(steps)
            {
                case 1:
                    expectedChar = 'M';
                    break;
                case 2:
                    expectedChar = 'A';
                    break;
                case 3:
                    expectedChar = 'S';
                    break;
            }
            switch(dir)
            {
                case Direction.Up:
                    if (Input[starty - steps][startx] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.UpRight:
                    if (Input[starty - steps][startx + steps] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (Input[starty][startx + steps] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.DownRight:
                    if (Input[starty + steps][startx + steps] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (Input[starty + steps][startx] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.DownLeft:
                    if (Input[starty + steps][startx - steps] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.Left:
                    if (Input[starty][startx - steps] == expectedChar)
                    {
                        return true;
                    }
                    break;
                case Direction.UpLeft:
                    if (Input[starty - steps][startx - steps] == expectedChar)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private bool IsXmasShape(int startx, int starty, Direction dir, char expected)
        {
            switch (dir)
            {
                case Direction.Up:
                    if (Input[starty - 1][startx] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.UpRight:
                    if (Input[starty - 1][startx + 1] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (Input[starty][startx + 1] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.DownRight:
                    if (Input[starty + 1][startx + 1] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (Input[starty + 1][startx] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.DownLeft:
                    if (Input[starty + 1][startx - 1] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.Left:
                    if (Input[starty][startx - 1] == expected)
                    {
                        return true;
                    }
                    break;
                case Direction.UpLeft:
                    if (Input[starty - 1][startx - 1] == expected)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public override void Solve()
        {
            int xmasCount = 0;

            for(int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if (Input[y][x] == 'X')
                    {
                        foreach(Direction dir in Enum.GetValues<Direction>())
                        {
                            switch (dir)
                            {
                                case Direction.Up:
                                    if (y > 2)
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.UpRight:
                                    if ((y > 2) && (x < (Input[y].Length - 3)))
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.Right:
                                    if (x < (Input[y].Length - 3))
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.DownRight:
                                    if ((y < (Input.Count - 3)) && (x < (Input[y].Length - 3)))
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.Down:
                                    if (y < (Input.Count - 3))
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.DownLeft:
                                    if ((y < (Input.Count - 3)) && (x > 2))
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.Left:
                                    if (x > 2)
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                                case Direction.UpLeft:
                                    if ((y > 2) && (x > 2))
                                    {
                                        if (IsXmas(x, y, dir, 1) && IsXmas(x, y, dir, 2) && IsXmas(x, y, dir, 3))
                                        {
                                            xmasCount++;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            Part1Solution = xmasCount.ToString();

            xmasCount = 0;
            for (int y = 1; y < (Input.Count - 1); y++)
            {
                for (int x = 1; x < (Input[y].Length - 1); x++)
                {
                    if (Input[y][x] == 'A')
                    {
                        if (IsXmasShape(x, y, Direction.UpRight, 'M') && IsXmasShape(x, y, Direction.DownLeft, 'S'))
                        {
                            if (IsXmasShape(x, y, Direction.UpLeft, 'M') && IsXmasShape(x, y, Direction.DownRight, 'S'))
                            {
                                xmasCount++;
                            }
                            else if (IsXmasShape(x, y, Direction.DownRight, 'M') && IsXmasShape(x, y, Direction.UpLeft, 'S'))
                            {
                                xmasCount++;
                            }
                        }
                        else if (IsXmasShape(x, y, Direction.DownLeft, 'M') && IsXmasShape(x, y, Direction.UpRight, 'S'))
                        {
                            if (IsXmasShape(x, y, Direction.UpLeft, 'M') && IsXmasShape(x, y, Direction.DownRight, 'S'))
                            {
                                xmasCount++;
                            }
                            else if (IsXmasShape(x, y, Direction.DownRight, 'M') && IsXmasShape(x, y, Direction.UpLeft, 'S'))
                            {
                                xmasCount++;
                            }
                        }
                    }
                }
            }

            Part2Solution = xmasCount.ToString();
        }
    }
}
