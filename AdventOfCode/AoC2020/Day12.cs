using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class Day12 : Day
    {
        override public void Solve()
        {
            int facing = 0; // 0 == East, 1 == South, 2 == West, 3 = North
            int posx = 0, posy = 0;
            int wx = 10, wy = -1;
            int sx = 0, sy = 0;

            for (int i = 0; i < Input.Count; i++)
            {
                char navinstr = Input[i][0];
                int navval = int.Parse(Input[i].Remove(0, 1));

                switch (navinstr)
                {
                    case 'E':
                        posx += navval;
                        wx += navval;
                        break;
                    case 'S':
                        posy += navval;
                        wy += navval;
                        break;
                    case 'W':
                        posx -= navval;
                        wx -= navval;
                        break;
                    case 'N':
                        posy -= navval;
                        wy -= navval;
                        break;
                    case 'L':
                        facing = (facing - (navval / 90) + 4) % 4;
                        for (int turns = 0; turns < (navval / 90); turns++)
                        {
                            int nx = wy;
                            int ny = -wx;
                            wx = nx;
                            wy = ny;
                        }
                        break;
                    case 'R':
                        facing = (facing + (navval / 90)) % 4;
                        for (int turns = 0; turns < (navval / 90); turns++)
                        {
                            int nx = -wy;
                            int ny = wx;
                            wx = nx;
                            wy = ny;
                        }
                        break;
                    case 'F':
                        switch (facing)
                        {
                            case 0:
                                posx += navval;
                                break;
                            case 1:
                                posy += navval;
                                break;
                            case 2:
                                posx -= navval;
                                break;
                            case 3:
                                posy -= navval;
                                break;
                        }
                        for (int steps = 0; steps < navval; steps++)
                        {
                            sx += wx;
                            sy += wy;
                        }
                        break;
                }
            }

            Part1Solution = (Math.Abs(posx) + Math.Abs(posy)).ToString();
            Part2Solution = (Math.Abs(sx) + Math.Abs(sy)).ToString();
        }
    }
}
