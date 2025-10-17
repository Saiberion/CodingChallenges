using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
    public class Challenge22 : Challenge
    {
        public void GridInit(int[,] grid)
        {
            int x, y;
            int offsy = grid.GetLength(1) / 2 - Input.Count / 2;
            int offsx = grid.GetLength(0) / 2 - Input[0].Length / 2;
            for (y = 0; y < Input.Count; y++)
            {
                for (x = 0; x < Input[y].Length; x++)
                {
                    if (Input[y][x] == '#')
                    {
                        grid[x + offsx, y + offsy] = 2;
                    }
                }
            }
        }

        public int VirusInfection(int bursts, int mode)
        {
            int x, y;
            int dir = 0;
            int infectionBursts = 0;
            int[,] grid = new int[449, 365];

            GridInit(grid);

            x = grid.GetLength(0) / 2;
            y = grid.GetLength(1) / 2;

            for (int b = 0; b < bursts; b++)
            {
                switch (grid[x, y])
                {
                    case 0:
                        dir--;
                        break;
                    case 1:
                        break;
                    case 2:
                        dir++;
                        break;
                    case 3:
                        dir += 2;
                        break;
                }
                dir = (dir + 4) % 4;

                grid[x, y] = (grid[x, y] + mode) % 4;
                if (grid[x, y] == 2)
                {
                    infectionBursts++;
                }

                switch (dir)
                {
                    case 0:
                        y--;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y++;
                        break;
                    case 3:
                        x--;
                        break;
                }
            }
            return infectionBursts;
        }

        public override void Solve()
        {

            Part1Solution = VirusInfection(10000, 2).ToString();

            Part2Solution = VirusInfection(10000000, 1).ToString();
        }
    }
}
