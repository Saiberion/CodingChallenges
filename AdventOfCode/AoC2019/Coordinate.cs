using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2019
{
    public class Coordinate3D(int x, int y, int z)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Z { get; set; } = z;
    }
}
