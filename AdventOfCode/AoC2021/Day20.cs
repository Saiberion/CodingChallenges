using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day20 : Day
    {
        override public void Solve()
        {
            string enhanceAlgo = Input[0];
            char[,] image = new char[Input[1].Length, Input.Count - 2];

            for(int y = 0; y < image.GetLength(1); y++)
            {
                for(int x = 0; x < image.GetLength(0); x++)
                {
                    image[x, y] = Input[y + 2][x];
                }
            }

            for (int i = 0; i < 2; i++)
            {
                //image = EnhanceImage(image, enhanceAlgo);
                char[,] newimg = new char[image.GetLength(0) + 2, image.GetLength(1) + 2];
                
                for (int y = -1; y <= image.GetLength(1); y++)
                {
                    for (int x = -1; x <= image.GetLength(0); x++)
                    {
                        int enhanceIdx = 0;

                        for(int y0 = -1; y0 < 2; y0++)
                        {
                            for (int x0 = -1; x0 < 2; x0++)
                            {
                                enhanceIdx <<= 1;
                                if (image[x + x0, y + y0] == '#')
                                {
                                    enhanceIdx |= 1;
                                }
                            }
                        }
                    }
                }
            }

            Part1Solution = "TBD";
            Part2Solution = "TBD";
        }
    }
}
