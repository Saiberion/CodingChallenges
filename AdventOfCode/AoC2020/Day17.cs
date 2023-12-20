using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AoC2020
{
    public class Day17 : Day
    {
        override public void Solve()
        {
            // TODO finish up
            Dictionary<Vector3, bool> pocketDimension = new();

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if (Input[y][x] == '#')
                    {
                        pocketDimension.Add(new Vector3(x, y, 0), true);
                    }
                }
            }

            float minx = float.MaxValue, maxx = float.MinValue, miny = float.MaxValue, maxy = float.MinValue, minz = float.MaxValue, maxz = float.MinValue;
            foreach(Vector3 p in pocketDimension.Keys)
            {
                minx = Math.Min(minx, p.X) - 1;
                miny = Math.Min(miny, p.Y) - 1;
                minz = Math.Min(minz, p.Z) - 1;

                maxx = Math.Max(maxx, p.X) + 1;
                maxy = Math.Max(maxy, p.Y) + 1;
                maxz = Math.Max(maxz, p.Z) + 1;
            }
            
            Part1Solution = "TBD";
            Part2Solution = "TBD";
        }
    }
}
