using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2021
{
    public class Day11 : AoCDay
    {
        private readonly Stack<int[]> FlashList = new();

        override public void Solve()
        {
            int[,] octopus = new int[10, 10];
            int flashesAfter100 = 0;
            int firstAllFlash = -1;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    octopus[x, y] = int.Parse(Input[y][x].ToString());
                }
            }

            int i = 0;
            while (true)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        IncreaseEnergy(x, y, octopus);
                    }
                }

                while (FlashList.Count > 0)
                {
                    int[] pos = FlashList.Pop();
                    if (octopus[pos[0], pos[1]] != -1)
                    {
                        IncreaseEnergy(pos[0] - 1, pos[1] - 1, octopus);
                        IncreaseEnergy(pos[0], pos[1] - 1, octopus);
                        IncreaseEnergy(pos[0] + 1, pos[1] - 1, octopus);
                        IncreaseEnergy(pos[0] + 1, pos[1], octopus);
                        IncreaseEnergy(pos[0] + 1, pos[1] + 1, octopus);
                        IncreaseEnergy(pos[0], pos[1] + 1, octopus);
                        IncreaseEnergy(pos[0] - 1, pos[1] + 1, octopus);
                        IncreaseEnergy(pos[0] - 1, pos[1], octopus);
                        octopus[pos[0], pos[1]] = -1;
                        if (i < 100)
                        {
                            flashesAfter100++;
                        }
                    }
                }

                bool allFlashed = true;
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        if (octopus[x, y] < 0)
                        {
                            octopus[x, y] = 0;
                        }
                        else
                        {
                            allFlashed = false;
                        }
                    }
                }
                if ((firstAllFlash == -1) && allFlashed)
                {
                    firstAllFlash = i + 1;
                }

                i++;
                if ((i >= 100) && (firstAllFlash != -1))
                {
                    break;
                }
            }

            Part1Solution = flashesAfter100.ToString();
            Part2Solution = firstAllFlash.ToString();
        }

        private void IncreaseEnergy(int x, int y, int[,] field)
        {
            if ((x >= 0) && (x < 10) && (y >= 0) && (y < 10) && (field[x, y] != -1))
            {
                if (++field[x, y] > 9)
                {
                    FlashList.Push([x, y]);
                }
            }
        }
    }
}
