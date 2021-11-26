using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Coordinate3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinate3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
