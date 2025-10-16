using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2018
{
    class MovingLight
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }

        public void Tick()
        {
            PosX += VelX;
            PosY += VelY;
        }

        public void ReverseTick()
        {
            PosX -= VelX;
            PosY -= VelY;
        }
    }

    class LightArea
    {
        public int MinX { get; set; }
        public int MinY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public long DistanceX { get { return MaxX - MinX; } }
        public long DistanceY { get { return MaxY - MinY; } }
        public long Area { get { return DistanceX * DistanceY; } }

        public LightArea(List<MovingLight> lights)
        {
            MinX = int.MaxValue;
            MinY = int.MaxValue;
            MaxX = int.MinValue;
            MaxY = int.MinValue;

            foreach (MovingLight m in lights)
            {
                MinX = Math.Min(MinX, m.PosX);
                MinY = Math.Min(MinY, m.PosY);
                MaxX = Math.Max(MaxX, m.PosX);
                MaxY = Math.Max(MaxY, m.PosY);
            }
        }
    }

    public class Day10 : AoCDay
    {
        static private string LightPlotter(List<MovingLight> lights)
        {
            LightArea la = new(lights);

            int[,] plot = new int[la.DistanceX + 1, la.DistanceY + 1];

            foreach (MovingLight m in lights)
            {
                plot[m.PosX - la.MinX, m.PosY - la.MinY] = 1;
            }

            for (int y = 0; y < plot.GetLength(1); y++)
            {
                for (int x = 0; x < plot.GetLength(0); x++)
                {
                    System.Diagnostics.Debug.Write(string.Format("{0}", plot[x, y] == 1 ? "#" : "."));
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("");

            return DotmatrixToString.Render(plot);
        }

        public override void Solve()
        {
            List<MovingLight> movingLights = [];

            foreach (string s in Input)
            {
                string[] splitted = s.Split(['<', ',', '>', ' '], StringSplitOptions.RemoveEmptyEntries);
                movingLights.Add(new MovingLight()
                {
                    PosX = int.Parse(splitted[1]),
                    PosY = int.Parse(splitted[2]),
                    VelX = int.Parse(splitted[4]),
                    VelY = int.Parse(splitted[5])
                });
            }
            LightArea la = new(movingLights);
            long minArea = la.Area;
            int ticks = 0;

            while (true)
            {
                foreach (MovingLight m in movingLights)
                {
                    m.Tick();
                }
                la = new LightArea(movingLights);
                if (la.Area > minArea)
                {
                    foreach (MovingLight m in movingLights)
                    {
                        m.ReverseTick();
                    }
                    break;
                }
                else
                {
                    minArea = la.Area;
                    ticks++;
                }
            }

            Part1Solution = LightPlotter(movingLights);
            Part2Solution = ticks.ToString();
        }
    }
}
