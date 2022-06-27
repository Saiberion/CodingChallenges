using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class Day11 : Day
    {
        public int CountOccupiedSeatsInSight(int x, int y, char[,] seatingArea, int distance)
        {
            int occupied = 0;

            if (distance > 0)
            {
                if (((x - distance) >= 0) && ((y - distance) >= 0))
                {
                    if (seatingArea[x - distance, y - distance] == '#')
                    {
                        occupied++;
                    }
                }
                if ((y - distance) >= 0)
                {
                    if (seatingArea[x, y - distance] == '#')
                    {
                        occupied++;
                    }
                }
                if (((x + distance) < seatingArea.GetLength(0)) && ((y - distance) >= 0))
                {
                    if (seatingArea[x + distance, y - distance] == '#')
                    {
                        occupied++;
                    }
                }
                if ((x + distance) < seatingArea.GetLength(0))
                {
                    if (seatingArea[x + distance, y] == '#')
                    {
                        occupied++;
                    }
                }
                if (((x + distance) < seatingArea.GetLength(0)) && ((y + distance) < seatingArea.GetLength(1)))
                {
                    if (seatingArea[x + distance, y + distance] == '#')
                    {
                        occupied++;
                    }
                }
                if ((y + distance) < seatingArea.GetLength(1))
                {
                    if (seatingArea[x, y + distance] == '#')
                    {
                        occupied++;
                    }
                }
                if (((x - distance) >= 0) && ((y + distance) < seatingArea.GetLength(1)))
                {
                    if (seatingArea[x - distance, y + distance] == '#')
                    {
                        occupied++;
                    }
                }
                if ((x - distance) >= 0)
                {
                    if (seatingArea[x - distance, y] == '#')
                    {
                        occupied++;
                    }
                }
            }
            else
            {
                for (int i = y; i > 0; i--)
                {
                    if (seatingArea[x, i - 1] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[x, i - 1] == 'L')
                    {
                        break;
                    }
                }

                for (int i = y; i < (seatingArea.GetLength(1) - 1); i++)
                {
                    if (seatingArea[x, i + 1] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[x, i + 1] == 'L')
                    {
                        break;
                    }
                }

                for (int i = x; i > 0; i--)
                {
                    if (seatingArea[i - 1, y] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[i - 1, y] == 'L')
                    {
                        break;
                    }
                }

                for (int i = x; i < (seatingArea.GetLength(0) - 1); i++)
                {
                    if (seatingArea[i + 1, y] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[i + 1, y] == 'L')
                    {
                        break;
                    }
                }

                for (int a = x, b = y; (a > 0) && (b > 0); a--, b--)
                {
                    if (seatingArea[a - 1, b - 1] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[a - 1, b - 1] == 'L')
                    {
                        break;
                    }
                }

                for (int a = x, b = y; (a < (seatingArea.GetLength(0) - 1)) && (b < (seatingArea.GetLength(1) - 1)); a++, b++)
                {
                    if (seatingArea[a + 1, b + 1] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[a + 1, b + 1] == 'L')
                    {
                        break;
                    }
                }

                for (int a = x, b = y; (a < (seatingArea.GetLength(0) - 1)) && (b > 0); a++, b--)
                {
                    if (seatingArea[a + 1, b - 1] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[a + 1, b - 1] == 'L')
                    {
                        break;
                    }
                }

                for (int a = x, b = y; (a > 0) && (b < (seatingArea.GetLength(1) - 1)); a--, b++)
                {
                    if (seatingArea[a - 1, b + 1] == '#')
                    {
                        occupied++;
                        break;
                    }
                    else if (seatingArea[a - 1, b + 1] == 'L')
                    {
                        break;
                    }
                }
            }
            return occupied;
        }

        public char GetNextSeatState(int x, int y, char[,] seatingArea, int distance, int seatLimit)
        {
            char nextSeatState;

            if (seatingArea[x,y] == '.')
            {
                nextSeatState = '.';
            }
            else
            {
                int neighbors = CountOccupiedSeatsInSight(x, y, seatingArea, distance);
                if (seatingArea[x,y] == 'L')
                {
                    if (neighbors == 0)
                    {
                        nextSeatState = '#';
                    }
                    else
                    {
                        nextSeatState = 'L';
                    }
                }
                else
                {
                    if (neighbors >= seatLimit)
                    {
                        nextSeatState = 'L';
                    }
                    else
                    {
                        nextSeatState = '#';
                    }
                }
            }

            return nextSeatState;
        }

        private int RunSeating(int distance, int seatLimit, char[,] seatingArea)
        {
            char[,] newSeatingArea;
            char[,] oldSeatingArea = null;
            int occupiedSeats = 0;
            
            newSeatingArea = seatingArea.Clone() as char[,];
            bool somethingChanged = true;
            while (somethingChanged)
            {
                somethingChanged = false;
                oldSeatingArea = newSeatingArea.Clone() as char[,];
                for (int y = 0; y < oldSeatingArea.GetLength(1); y++)
                {
                    for (int x = 0; x < oldSeatingArea.GetLength(0); x++)
                    {
                        char newState = GetNextSeatState(x, y, oldSeatingArea, distance, seatLimit);
                        if (newSeatingArea[x, y] != newState)
                        {
                            somethingChanged = true;
                        }
                        newSeatingArea[x, y] = newState;
                    }
                }
            }

            for (int y = 0; y < oldSeatingArea.GetLength(1); y++)
            {
                for (int x = 0; x < oldSeatingArea.GetLength(0); x++)
                {
                    if (newSeatingArea[x, y] == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }
            return occupiedSeats;
        }

        override public void Solve()
        {
            char[,] seatingArea = new char[Input[0].Length, Input.Count];
            
            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    seatingArea[x, y] = Input[y][x];
                }
            }

            Part1Solution = RunSeating(1, 4, seatingArea).ToString();
            Part2Solution = RunSeating(0, 5, seatingArea).ToString();
        }
    }
}
