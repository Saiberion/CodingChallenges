using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.AoC2021
{
    public class Line
    {
        public int X1 { internal set; get; }
        public int X2 { internal set; get; }
        public int Y1 { internal set; get; }
        public int Y2 { internal set; get; }

        public bool IsHoritontal { internal set; get; }
        public bool IsVertical { internal set; get; }
        public bool IsDiagonal { internal set; get; }

        public Line(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            if (y1 == y2)
            {
                IsHoritontal = true;
            }
            else if (x1 == x2)
            {
                IsVertical = true;
            }
            else
            {
                IsDiagonal = true;
            }
        }
    }
}
