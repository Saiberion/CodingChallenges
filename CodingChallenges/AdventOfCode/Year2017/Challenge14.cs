using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
    public class Challenge14 : Challenge
    {
        static void FillRegion(int regionNumber, int x, int y, List<int[]> grid)
        {
            grid[y][x] = regionNumber;

            if (x > 0 && grid[y][x - 1] == -1)
            {
                FillRegion(regionNumber, x - 1, y, grid);
            }
            if (x < 127 && grid[y][x + 1] == -1)
            {
                FillRegion(regionNumber, x + 1, y, grid);
            }
            if (y > 0 && grid[y - 1][x] == -1)
            {
                FillRegion(regionNumber, x, y - 1, grid);
            }
            if (y < 127 && grid[y + 1][x] == -1)
            {
                FillRegion(regionNumber, x, y + 1, grid);
            }
        }

        public override void Solve()
        {
            string baseKey = Input[0];
            KnotHash knotHash = new();
            List<int[]> diskGrid = [];
            int usedGridCells = 0;
            int regionCount = 0;

            for (int i = 0; i < 128; i++)
            {
                int[] arr = new int[128];
                int baseIndex = 0;
                string hash = knotHash.GetHashString(string.Format("{0}-{1}", baseKey, i));
                foreach (char c in hash)
                {
                    byte b = Convert.ToByte(c.ToString(), 16);
                    for (int k = 3; k >= 0; k--)
                    {
                        if ((b & 1 << k) > 0)
                        {
                            usedGridCells++;
                            arr[baseIndex++] = -1;
                        }
                        else
                        {
                            arr[baseIndex++] = 0;
                        }
                    }
                }
                diskGrid.Add(arr);
            }

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    if (diskGrid[y][x] == -1)
                    {
                        FillRegion(++regionCount, x, y, diskGrid);
                    }
                }
            }

            Part1Solution = usedGridCells.ToString();
            Part2Solution = regionCount.ToString();
        }
    }
}
