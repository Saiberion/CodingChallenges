using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC2017
{
    public class Day22 : Day
    {
        public void GridInit(Dictionary<Point, int> grid)
        {
            int x, y;
            grid.Clear();
            for (y = 0; y < Input.Count; y++)
            {
                for (x = 0; x < Input[y].Length; x++)
                {
                    if (Input[y][x] == '#')
                    {
                        grid.Add(new Point(x, y), 2);
                    }
                    else
                    {
                        grid.Add(new Point(x, y), 0);
                    }
                }
            }
        }

        public int VirusInfection(int bursts, int mode)
        {
            int x, y;
            int dir = 0;
            int infectionBursts = 0;
            Dictionary<Point, int> grid = new Dictionary<Point, int>();

            GridInit(grid);

            x = Input[0].Length / 2;
            y = Input.Count / 2;

            for (int b = 0; b < bursts; b++)
            {
                Point p = new Point(x, y);
                if (!grid.ContainsKey(p))
                {
                    grid.Add(new Point(x, y), 0);
                }

                switch (grid[p])
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

                grid[p] = (grid[p] + mode) % 4;
                if (grid[p] == 2)
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
