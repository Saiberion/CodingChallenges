using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges
{
    public class Coordinate3D(long x, long y, long z)
    {
        public long X { get; set; } = x;
        public long Y { get; set; } = y;
        public long Z { get; set; } = z;

        public long GetDistanceTo(Coordinate3D other)
        {
            // skip the square root part as we do not need to know the exact distance but only have to compare them
            long deltaX = X - other.X;
            long deltaY = Y - other.Y;
            long deltaZ = Z - other.Z;

            // for the exact distance we would need to switch to floating point and calculate the square root of the following return value
            return deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ;
        }
    }

    public class Coordinate2D(long x, long y)
    {
        public long X { get; set; } = x;
        public long Y { get; set; } = y;
    }
}
