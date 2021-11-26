using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC2019
{
    public class Day10 : Day
    {
        override public void Solve()
        {
            Asteroid[,] asteroidMap = new Asteroid[Input[0].Length, Input.Count];
            List<Asteroid> asteroids = new List<Asteroid>();
            for (int i = 0; i < Input.Count; i++)
            {
                for (int k = 0; k < Input[i].Length; k++)
                {
                    if (Input[i][k] == '#')
                    {
                        asteroidMap[k, i] = new Asteroid(new Point(k, i));
                        asteroids.Add(asteroidMap[k, i]);
                    }
                    else
                    {
                        asteroidMap[k, i] = null;
                    }
                }
            }

            foreach (Asteroid a in asteroids)
            {
                foreach (Asteroid a1 in asteroids)
                {
                    if (a != a1)
                    {
                        int dx = a1.Position.X - a.Position.X;
                        int dy = a1.Position.Y - a.Position.Y;
                        int gcd = GCD(dx, dy);
                        int intermediateSteps = gcd - 1;
                        dx /= gcd;
                        dy /= gcd;
                        bool pathClear = true;
                        while(intermediateSteps > 0)
                        {
                            if (asteroidMap[a.Position.X + intermediateSteps * dx, a.Position.Y + intermediateSteps * dy] != null)
                            {
                                pathClear = false;
                                break;
                            }
                            intermediateSteps--;
                        }
                        if (pathClear)
                        {
                            a.VisibleAsteroids++;
                        }
                    }
                }
            }

            int mostVisible = int.MinValue;
            foreach(Asteroid a in asteroids)
            {
                mostVisible = Math.Max(mostVisible, a.VisibleAsteroids);
            }
            Part1Solution = mostVisible.ToString();
            Part2Solution = "TBD";
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (Math.Abs(a) > Math.Abs(b))
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a == 0 ? Math.Abs(b) : Math.Abs(a);
        }
    }

    class Asteroid
    {
        public int VisibleAsteroids { get; set; }
        public Point Position { get; set; }

        public Asteroid(Point p)
        {
            Position = new Point(p.X, p.Y);
        }
    }
}
