using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges
{
    public class Coordinate3D(int x, int y, int z)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Z { get; set; } = z;

        public int GetDistanceTo(Coordinate3D other)
        {
            // skip the square root part as we do not need to know the exact distance but only have to compare them
            int deltaX = X - other.X;
            int deltaY = Y - other.Y;
            int deltaZ = Z - other.Z;

            // for the exact distance we would need to switch to floating point and calculate the square root of the following return value
            return deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ;
        }
    }
}
